using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HelpDeveloperDB.Classes;
using System.IO;

namespace HelpDeveloperDB
{
    public partial class formConexao : Form
    {
        public formConexao()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (txtHost.Text == "" || txtDataBase.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("Informe os campos necessários", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            switch (cbBanco.SelectedIndex)
            {
                case 0:
                    if (Funcoes.testarConexao(Funcoes.DBSQLSERVER,txtHost.Text, txtDataBase.Text, txtUser.Text, txtSenha.Text, 0))
                    {
                        MessageBox.Show("Conexão Bem sucedida!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Problema ao tentar conectar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1:
                    break;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (txtHost.Text == "" || txtDataBase.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("Informe os campos necessários", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            switch (cbBanco.SelectedIndex)
            {
                case Funcoes.DBSQLSERVER:
                    if (Funcoes.testarConexao(Funcoes.DBSQLSERVER,txtHost.Text, txtDataBase.Text, txtUser.Text, txtSenha.Text, 0))
                    {
                        try
                        {
                            if (txtHost.SelectedIndex == -1)
                            {
                                Funcoes.escreverConfig("Config.ini", "Servidores", txtHost.Text);
                            }
                            if (txtDataBase.SelectedIndex == -1)
                            {
                                Funcoes.escreverConfig("Config.ini", "Bases", txtDataBase.Text);
                            }
                            if (txtUser.SelectedIndex == -1)
                            {
                                Funcoes.escreverConfig("Config.ini", "Users", txtUser.Text);
                            }
                        }
                        catch(Exception erro)
                        {
                            MessageBox.Show("Erro ao Salvar configurações!, tente Executar o programa como administrador!\n" + 
                                erro.Message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ExibeCampos exibeCampos = new ExibeCampos();
                        exibeCampos.banco = Funcoes.DBSQLSERVER;
                        exibeCampos.host = txtHost.Text;
                        exibeCampos.dataBase = txtDataBase.Text;
                        exibeCampos.usuario = txtUser.Text;
                        exibeCampos.senha = txtSenha.Text;
                        exibeCampos.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Problema ao tentar conectar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case Funcoes.DBPOSTGRESQL:
                    if (Funcoes.testarConexao(Funcoes.DBPOSTGRESQL, txtHost.Text, txtDataBase.Text, txtUser.Text, txtSenha.Text, Convert.ToInt32(txtPorta.Text)))
                    {
                        try
                        {
                            if (txtHost.SelectedIndex == -1)
                            {
                                Funcoes.escreverConfig("Config.ini", "Servidores", txtHost.Text);
                            }
                            if (txtDataBase.SelectedIndex == -1)
                            {
                                Funcoes.escreverConfig("Config.ini", "Bases", txtDataBase.Text);
                            }
                            if (txtUser.SelectedIndex == -1)
                            {
                                Funcoes.escreverConfig("Config.ini", "Users", txtUser.Text);
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Erro ao Salvar configurações!, tente Executar o programa como administrador!\n" +
                                erro.Message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ExibeCampos exibeCampos = new ExibeCampos();
                        exibeCampos.banco = Funcoes.DBPOSTGRESQL;
                        exibeCampos.host = txtHost.Text;
                        exibeCampos.dataBase = txtDataBase.Text;
                        exibeCampos.usuario = txtUser.Text;
                        exibeCampos.senha = txtSenha.Text;
                        exibeCampos.porta = Convert.ToInt32(txtPorta.Text);
                        exibeCampos.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Problema ao tentar conectar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void formConexao_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists("Config.ini"))
                {
                    File.Create("Config.ini").Close();
                    TextWriter arquivo = File.AppendText("Config.ini");
                    arquivo.WriteLine("[Servidores]\n[Bases]\n[Users]\n[Diretorios]");
                    arquivo.Close();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao criar arquivo de configuração, tente Executar o programa como administrador!\n"+
                    erro.Message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            txtHost.DataSource = Funcoes.retornarValoresConfig("Config.ini", "Servidores");
            if (txtHost.Items.Count > 0) txtHost.SelectedIndex = 0;
            txtDataBase.DataSource = Funcoes.retornarValoresConfig("Config.ini", "Bases");
            if (txtDataBase.Items.Count > 0) txtDataBase.SelectedIndex = 0;
            txtUser.DataSource = Funcoes.retornarValoresConfig("Config.ini", "Users");
            if (txtDataBase.Items.Count > 0) txtUser.SelectedIndex = 0;
            cbBanco.SelectedIndex = 0;
        }

        private void cbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanco.SelectedIndex == 1)
            {
                txtPorta.Visible = true;
                lbPorta.Visible = true;
            }
            else
            {
                txtPorta.Visible = false;
                lbPorta.Visible = false;
            }
        }

        private void formConexao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }


    }
}
