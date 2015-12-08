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
    public partial class ConfigurarGeraCode : Form
    {
        public struct Coluna
        {
            public string nome;
            public string tipo;
        }

        private string tabela = "";
        private int banco = 0;
        private List<Coluna> colunasAtributos = new List<Coluna>();
        private List<Coluna> colunasBanco = new List<Coluna>();

        private string nomeSqlConnection = "";
        private string nomeSqlCommand = "";
        private string nomeSqlDataReader = "";
        private string usings = "";
        private string dbType = "";

        public void setTabela(string tabela)
        {
            this.tabela = tabela;
        }

        public void setColunas(List<Coluna> colunas)
        {
            this.colunasBanco = colunas;
        }

        public void setBanco(int banco)
        {
            if (banco == Funcoes.DBSQLSERVER)
            {
                this.banco = banco;
                nomeSqlCommand = "SqlCommand";
                nomeSqlConnection = "SqlConnection";
                nomeSqlDataReader = "SqlDataReader";
                usings = "using System.Data; \nusing System.Data.SqlClient;";
                dbType = "SqlDbType";
            }
            else if (banco == Funcoes.DBPOSTGRESQL)
            {
                this.banco = banco;
                nomeSqlCommand = "NpgsqlCommand";
                nomeSqlConnection = "NpgsqlConnection";
                nomeSqlDataReader = "NpgsqlDataReader";
                usings = "using Npgsql; \nusing NpgsqlTypes;";
                dbType = "NpgsqlDbType";
            }
        }


        public ConfigurarGeraCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDiretorio = new FolderBrowserDialog();
            if (fbDiretorio.ShowDialog() == DialogResult.OK)
            {
                txtDiretorio.Text = fbDiretorio.SelectedPath;
            }
        }

        private void chkMetGravacao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMetGravacao.Checked)
            {
                chkRedGravacao.Enabled = true;
            }
            else
            {
                chkRedGravacao.Enabled = false;
            }
        }

        private void chkMetListagem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMetListagem.Checked)
            {
                chkRedListagem.Enabled = true;
            }
            else
            {
                chkRedListagem.Enabled = false;
            }
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
            string nome_arquivo = txtDiretorio.Text + "\\" + tabela + ".cs";

            if (File.Exists(nome_arquivo))
            {
                if (MessageBox.Show("O arquivos já existe! Deseja Substituí-lo?", "Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(nome_arquivo);
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível substituir o arquivo! Verifique se ele não está sendo usado em outra Aplicação.",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    File.Create(nome_arquivo).Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                File.Create(nome_arquivo).Close();
            }
            if (rbPadrao.Checked)
            {
                colunasAtributos = converteColunaToAtributo(colunasBanco);
            }
            else
            {
                colunasAtributos = colunasBanco;
            }
                
            TextWriter arquivo = File.AppendText(nome_arquivo);

            //Adicionando as referencias
            arquivo.WriteLine("using System; \nusing System.Collections.Generic;\nusing System.ComponentModel;\nusing System.Drawing;\nusing System.Linq;\nusing System.Text;\n"+usings);

            arquivo.WriteLine("\npublic class " + tabela + " \n{ \n");

            arquivo.WriteLine(montaAtributos(colunasAtributos));

            if (chkMetGravacao.Checked)
            {
                arquivo.WriteLine(montaMetodoGravacao(chkRedGravacao.Checked,colunasAtributos,colunasBanco, tabela));
            }

            if (chkMetListagem.Checked)
            {
                arquivo.WriteLine(montaMetodoListagem(chkRedListagem.Checked,colunasAtributos, colunasBanco, tabela));
            }

            if (chkMetExclusao.Checked)
            {
                arquivo.WriteLine(montaMetodoExclusao(colunasBanco,colunasAtributos,tabela));
            }

            arquivo.WriteLine("}");
            arquivo.Close();

            if (chkFunc.Checked)
            {
                if (!File.Exists(txtDiretorio.Text + "\\Funcoes.cs"))
                {
                    string diretorio = "";
                    if (banco == Funcoes.DBPOSTGRESQL)
                    {
                        diretorio = Application.StartupPath + "\\arquivos\\FuncoesNpg.txt";
                    }
                    else
                    {
                        diretorio = Application.StartupPath + "\\arquivos\\Funcoes.txt";
                    }
                    System.IO.File.Copy(diretorio, txtDiretorio.Text + "\\Funcoes.cs", true);
                }

            }

            MessageBox.Show("Classe C# criada com sucesso!", "informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void chkRedGravacao_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRedGravacao.Checked && !chkRedListagem.Checked)
            {
                chkFunc.Enabled = false;
            }
            else
            {
                chkFunc.Enabled = true;
            }
        }

        private void chkRedListagem_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRedGravacao.Checked && !chkRedListagem.Checked)
            {
                chkFunc.Enabled = false;
            }
            else
            {
                chkFunc.Enabled = true;
            }
        }

        /// <summary>
        /// Método responsável por gerar os atributos
        /// </summary>
        /// <param name="colunas"></param>
        /// <param name="padrao"></param>
        /// <returns></returns>
        private string montaAtributos(List<Coluna> colunas)
        {
            string atributos = "";

            for (int i = 0; i < colunas.Count; i++)
            {
                atributos += "\tpublic " + Funcoes.retornaTipoC(colunas[i].tipo) + " " + colunas[i].nome + ";\n";
            }
            
            return atributos;
        }

        /// <summary>
        /// Método que gera o método de gravação
        /// </summary>
        /// <param name="reduzido">Se este parametro for passado como true, o método criará o sql e os parametros chamando um funcao, por isso é importante ter essa classe no projeto</param>
        /// <param name="colunas">Colunas que serão utilizadas no método de gravação</param>
        /// <param name="tabela">Tabela que será utilizada no nome da classe</param>
        /// <returns>retorna uma string com o método de gravação</returns>
        public string montaMetodoGravacao(Boolean reduzido, List<Coluna> colunasAtributos, List<Coluna> colunasBanco, string tabela)
        {
            string metodo = "";
            metodo = "\tpublic int gravar" + tabela + "(" + tabela + " obj" + tabela + ") \n \t{ \n";
            metodo += "\t\t try \n \t\t{ \n\t\t\tusing (" + nomeSqlConnection + " con = new " + nomeSqlConnection + "(Funcoes.conectaBanco())) \n \t\t\t{ \n \t\t\t\tcon.Open();\n \t\t\t\tstring sql = \"\"; \n ";
            metodo += "\t\t\t\tif(obj" + tabela + "." + colunasAtributos[0].nome + " == 0) \n \t\t\t\t{ \n";
            if (reduzido)
            {

                metodo += "\t\t\t\t\tsql = Funcoes.montaSql(\"" + tabela + "\",false, obj" + tabela + ", \"\");\n \t\t\t\t} \n \t\t\t\telse \n \t\t\t\t{ \n " +
                    "\t\t\t\t\tsql = Funcoes.montaSql(\"" + tabela + "\",true, obj" + tabela + ", \"" + colunasBanco[0].nome + " = @" + colunasAtributos[0].nome + "\"); \n \t\t\t\t}\n";
            }
            else
            {
                metodo += "\t\t\t\t\tsql = \"INSERT INTO " + tabela + "(";
                string values = "";
                for (int i = 0; i < colunasAtributos.Count; i++)
                {
                    if (i == (colunasAtributos.Count - 1))
                    {
                        metodo += colunasBanco[i].nome;
                        values += "@" + colunasAtributos[i].nome;
                    }
                    else
                    {
                        metodo += colunasBanco[i].nome + ", ";
                        values += "@" + colunasAtributos[i].nome + ", ";
                    }
                }
                metodo += ") VALUES (";
                metodo += values + ")\";\n";

                metodo += "\t\t\t\t} \n \t\t\t\telse \n \t\t\t\t{\n";
                metodo += "\t\t\t\t\tsql = \"UPDATE " + tabela + " SET ";

                for (int i = 0; i < colunasAtributos.Count; i++)
                {
                    if (i == (colunasAtributos.Count - 1))
                    {
                        metodo += colunasBanco[i].nome + " = @" + colunasAtributos[i].nome;
                    }
                    else
                    {
                        metodo += colunasBanco[i].nome + " = @" + colunasAtributos[i].nome + ", ";
                    }
                }
                metodo += " WHERE " + colunasBanco[0].nome + " = @" + colunasAtributos[0].nome + "\"; \n \t\t\t\t}\n";
            }

            metodo += "\t\t\t\tusing (" + nomeSqlCommand + " cmd = new " + nomeSqlCommand + "(sql, con))\n \t\t\t\t{\n ";

            if (reduzido)
            {
                metodo += "\t\t\t\t\tFuncoes.addParametros(cmd, obj" + tabela + "); \n";
            }
            else
            {
                for (int i = 0; i < colunasAtributos.Count; i++)
                {
                    metodo += "\t\t\t\t\tcmd.Parameters.Add(\"@" + colunasAtributos[i].nome + "\", " + 
                        dbType + "." + Funcoes.retornaSqlDbType(colunasBanco[i].tipo, banco) + ").Value = obj" + tabela + "." + colunasAtributos[i].nome + ";\n";
                }
            }
            metodo += "\t\t\t\t\tcmd.ExecuteNonQuery();\n";
            metodo += "\t\t\t\t\tif(obj" + tabela + "." + colunasBanco[0].nome + " == 0)\n\t\t\t\t\t{\n";
            metodo += "\t\t\t\t\t\tcmd.CommandText = \"SELECT MAX(" + colunasBanco[0].nome + ") FROM " + tabela + "\";\n";
            metodo += "\t\t\t\t\t\tobj" + tabela + "." + colunasAtributos[0].nome + " = " + "Convert.ToInt32(cmd.ExecuteScalar());\n";
            metodo += "\t\t\t\t\t}\n\t\t\t\t}\n \t\t\t}\n";
            metodo += "\t\t\treturn obj" + tabela + "." + colunasAtributos[0].nome + ";\n";
            metodo += "\t\t}";
            metodo += "catch(Exception erro) \n \t\t{ \n \t\t\tthrow new Exception(erro.Message); \n \t\t} \n \t} \n";

            return metodo;
        }

        public string montaMetodoListagem(Boolean reduzido, List<Coluna> colunasAtributos, List<Coluna> colunasBanco, string tabela)
        {
            string metodo = "\tpublic List<"+tabela+"> listar"+tabela+"(string filtro) \n\t{\n";
            metodo += "\t\ttry \n\t\t{\n \t\t\tList<" + tabela + "> list" + tabela + " = new List<" + tabela + ">();\n\t\t\tusing(" + nomeSqlConnection + " conn = new " + nomeSqlConnection + "(Funcoes.conectaBanco())) \n\t\t\t{ \n";
            metodo += "\t\t\t\tconn.Open(); \n";
            metodo += "\t\t\t\tstring sql = \"SELECT * FROM "+tabela+" \";\n";
            metodo += "\t\t\t\tif(filtro != \"\") \n\t\t\t\t{\n";
            metodo += "\t\t\t\t\tsql += \"WHERE \"+filtro; \n\t\t\t\t}\n";
            metodo += "\t\t\t\tusing(" + nomeSqlCommand + " cmd = new " + nomeSqlCommand + "(sql, conn)) \n\t\t\t\t{ \n";
            metodo += "\t\t\t\t\tusing (" + nomeSqlDataReader + " reader = cmd.ExecuteReader()) \n\t\t\t\t\t{";
            metodo += "\n\t\t\t\t\t\twhile (reader.Read()) \n\t\t\t\t\t\t{";
            metodo += "\n\t\t\t\t\t\t\t"+tabela+" "+ tabela.Substring(0,1) + " = new " + tabela+"();\n";

            if(reduzido)
            {
                metodo += "\t\t\t\t\t\t\tFuncoes.preencheObjetos(reader," + tabela.Substring(0, 1) + ");\n";
            }
            else
            {
                for (int i = 0; i < colunasAtributos.Count; i++)
                {
                    metodo += "\t\t\t\t\t\t\t" + tabela.Substring(0, 1) + "." + colunasAtributos[i].nome + " = Convert." + Funcoes.retornaTipoConversao(colunasBanco[i].tipo) + "(reader[\"" + colunasBanco[i].nome + "\"]);\n";
                }
            }

            metodo += "\t\t\t\t\t\t\tlist" + tabela + ".Add(" + tabela.Substring(0, 1) + ");\n";

            metodo += "\t\t\t\t\t\t} \n\t\t\t\t\t} \n\t\t\t\t} \n\t\t\t} \n\t\t\treturn list"+tabela +";\n\t\t} catch(Exception erro) \n\t\t{ \n\t\t\tthrow new Exception(erro.Message); \n\t\t} \n\t}";

            return metodo;
        }

        public string montaMetodoExclusao(List<Coluna> colunasBanco, List<Coluna> colunasAtributos, string tabela)
        {
            string metodo = "\n\tpublic Boolean excluir" + tabela + "(" + Funcoes.retornaTipoC(colunasBanco[0].tipo) + " " + colunasAtributos[0].nome + ") \n\t{";
            metodo += "\n\t\ttry \n\t\t{ \n\t\t\tusing (" + nomeSqlConnection + " con = new " + nomeSqlConnection + "(F.conectaBanco())) \n\t\t\t{ \n\t\t\t\tcon.Open();";
            metodo += "\n\t\t\t\tstring sql =\"DELETE FROM " + tabela + " WHERE " + colunasBanco[0].nome + " = @" + colunasAtributos[0].nome + "\";";
            metodo += "\n\t\t\t\tusing (" + nomeSqlCommand + " cmd = new " + nomeSqlCommand + "(sql, con)) \n\t\t\t\t{";
            metodo += "\n\t\t\t\t\tcmd.Parameters.Add(\"@" + colunasAtributos[0].nome + "\", " + dbType + "." + Funcoes.retornaSqlDbType(colunasBanco[0].tipo, banco) + ").Value = " + colunasAtributos[0].nome + ";\n";
            metodo += "\n\t\t\t\t\tcmd.ExecuteNonQuery(); \n\t\t\t\t} \n\t\t\t} \n\t\t\treturn true;";
            metodo += "\n\t\t} catch(Exception erro) \n\t\t{ \n\t\t\tthrow new Exception(erro.Message); \n\t\t} \n\t}";

            return metodo;
        }

        /// <summary>
        /// Converte todos os atributos da lista para o padrão e retorna a lista alterada
        /// </summary>
        /// <param name="colunas">colunas a ser convertida</param>
        /// <returns>retorna uma lista com os valores convertidos</returns>
        public static List<Coluna> converteColunaToAtributo(List<Coluna> colunas)
        {
            List<Coluna> novaListaColunas = new List<Coluna>();
            for (int i = 0; i < colunas.Count; i++)
            {
                novaListaColunas.Add(new Coluna { nome = converteColunaToAtributo(colunas[i].nome), tipo = colunas[i].tipo });
            }
            return novaListaColunas;
        }

        /// <summary>
        /// Converte uma coluna para o nome do possível objeto
        /// </summary>
        /// <param name="nomeNoBanco">Coluna do Banco</param>
        /// <returns>retorn o possível nome na classe</returns>
        private static string converteColunaToAtributo(string nomeNoBanco)
        {
            String primeiroCaractere = "";

            primeiroCaractere = nomeNoBanco.Substring(0, 1).ToLower();
            return primeiroCaractere + nomeNoBanco.Remove(0, 1).Replace("_", "");
        }

        private void ConfigurarGeraCode_Load(object sender, EventArgs e)
        {
            txtDiretorio.DataSource = Funcoes.retornarValoresConfig("Config.ini", "Diretorios");
            
        }

        private void ConfigurarGeraCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
    }
}
