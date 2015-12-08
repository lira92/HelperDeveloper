using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HelpDeveloperDB.Classes;

namespace HelpDeveloperDB
{
    public partial class ConfiguraCodeFlex : Form
    {
        private string tabela = "";
        private List<ConfigurarGeraCode.Coluna> colunasAtributos = new List<ConfigurarGeraCode.Coluna>();

        public void setTabela(string tabela)
        {
            this.tabela = tabela;
        }

        public void setColunas(List<ConfigurarGeraCode.Coluna> colunas)
        {
            this.colunasAtributos = colunas;
        }

        public ConfiguraCodeFlex()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtDiretorio.Text == "")
            {
                MessageBox.Show("Informe o diretório!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiretorio.SelectedIndex == -1)
            {
                Funcoes.escreverConfig("Config.ini", "Diretorios", txtDiretorio.Text);
            }
            if (rbPadrao.Checked)
            {
                colunasAtributos = ConfigurarGeraCode.converteColunaToAtributo(colunasAtributos);
            }

            string nome_arquivo = txtDiretorio.Text + "//" + tabela + ".as";

            if (File.Exists(nome_arquivo))
            {
                if (MessageBox.Show("O arquivos já existe! Deseja Substitui-lo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(nome_arquivo);
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro ao substituir o arquivo! \n" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    this.Close();
                    return;
                }
            }
            //if (chkAddRemoteCall.Checked)
            //{
            //    File.Copy(Application.StartupPath + "//arquivos//RemoteCall.as", txtDiretorio.Text + "//RemoteCall.as");
            //}
            File.Create(nome_arquivo).Close();
            TextWriter arquivo = File.AppendText(nome_arquivo);
            arquivo.WriteLine("package " + txtPackage.Text + "\n{ \n\t[RemoteClass(alias=\"" + tabela + "\")] \n\t[Bindable]");
            arquivo.WriteLine("\n\tpublic class "+tabela+" \n\t{");
            arquivo.WriteLine(montaAtributos(colunasAtributos));
            arquivo.WriteLine("\n\t\tpublic function "+tabela+"(){}");
            if (chkPadraoRemoting.Checked)
            {
                //arquivo.WriteLine(escreverRemote());
                if (chkMetodoGravar.Checked) arquivo.WriteLine(escreveGravar());
                if (chkMetodoListar.Checked) arquivo.WriteLine(escreverListar());
                if (chkMetodoExcluir.Checked) arquivo.WriteLine(escreverDeletar());
                arquivo.WriteLine(escreverFault());
            }
            arquivo.WriteLine("\n\t}\n}");
            arquivo.Close();

            MessageBox.Show("Classe AS criada com sucesso!", "informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Método responsável por gerar os atributos
        /// </summary>
        /// <param name="colunas"></param>
        /// <param name="padrao"></param>
        /// <returns></returns>
        private string montaAtributos(List<ConfigurarGeraCode.Coluna> colunas)
        {
            string atributos = "";

            for (int i = 0; i < colunas.Count; i++)
            {
                atributos += "\t\tpublic var " + colunas[i].nome + ":" + Funcoes.retornaTipoFlex(colunas[i].tipo) + ";\n";
            }

            return atributos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDiretorio = new FolderBrowserDialog();
            if (fbDiretorio.ShowDialog() == DialogResult.OK)
            {
                txtDiretorio.Text = fbDiretorio.SelectedPath;
            }
        }

        private void ConfiguraCodeFlex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }

        private void ConfiguraCodeFlex_Load(object sender, EventArgs e)
        {
            txtDiretorio.DataSource = Funcoes.retornarValoresConfig("Config.ini", "Diretorios");
        }

        private string escreverRemote()
        {
            return "\n\t\tprivate var _remote:RemoteObject;" +

            "\n\t\tprivate function get remote():RemoteObject" +
            "\n\t\t{" +
                "\n\t\t\t_remote = new RemoteObject(\"fluorine\");" +
                "\n\t\t\t_remote.source = " + tabela + ";" +
                "\n\t\t\t_remote.endpoint = [endpoint];" +
                "\n\t\t\t_remote.addEventListener(FaultEvent.FAULT, fault);" +
                "\n\t\t\treturn _remote;" +
            "\n\t\t}";
        }

        private string escreveGravar()
        {
            return "\n\n\t\tpublic function gravar" + tabela + "(funcaoSucesso:Function):void" +
            "\n\t\t{" +
            "\n\t\t\ttry" +
                "\n\t\t\t{" +
                    "\n\t\t\t\tRemoteDestination.Remote(\""+tabela+"\",\"tokGravar"+tabela+"\", \"gravar" + tabela + "\", fault ,funcaoSucesso, [this]);" +
                "\n\t\t\t} " +
                "\n\t\t\tcatch(error:Error) " +
                "\n\t\t\t{" +
                    "\n\t\t\t\tAlert.show(\"Erro\" + error.message);" +
                "\n\t\t\t}" +
            "\n\t\t}";
        }

        private string escreverListar()
        {
            return "\n\n\t\tpublic function listar" + tabela + "(funcaoSucesso:Function):void" +
            "\n\t\t{" +
                "\n\t\t\ttry" +
                "\n\t\t\t{" +
                    "\n\t\t\t\tRemoteDestination.Remote(\"" + tabela + "\",\"tokListar" + tabela + "\", \"listar" + tabela + "\", fault ,funcaoSucesso, new Array());" +
                "\n\t\t\t}" +
                "\n\t\t\tcatch(error:Error) " +
                "\n\t\t\t{" +
                   "\n\t\t\t\tAlert.show(\"Erro\" + error.message);" +
                "\n\t\t\t}" +
            "\n\t\t}";
        }

        private string escreverDeletar()
        {
            return "\n\n\t\tpublic function excluir" + tabela + "(codigo:int, funcaoSucesso:Function):void" +
            "\n\t\t{" +
                "\n\t\t\ttry" +
                "\n\t\t\t{" +
                    "\n\t\t\t\tRemoteDestination.Remote(\"" + tabela + "\",\"tokExcluir" + tabela + "\",\"excluir" + tabela + "\", fault ,funcaoSucesso, [codigo]);" +
                "\n\t\t\t}" +
                "\n\t\t\tcatch(error:Error) " +
                "\n\t\t\t{" +
                   "\n\t\t\t\tAlert.show(\"Erro\" + error.message);" +
                "\n\t\t\t}" +
            "\n\t\t}";
        }

        private string escreverFault()
        {
            return "\n\n\t\tprivate function fault(event:FaultEvent):void" +
            "\n\t\t{" +
                "\n\t\t\tAlert.show(\"erro: \" + event.fault.message);" +
            "\n\t\t}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPadraoRemoting.Checked)
            {
                chkMetodoListar.Enabled = true;
                chkMetodoGravar.Enabled = true;
                chkMetodoExcluir.Enabled = true;
            }
            else
            {
                chkMetodoListar.Enabled = false;
                chkMetodoGravar.Enabled = false;
                chkMetodoExcluir.Enabled = false;
            }
        }
    }
}
