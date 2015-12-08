using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HelpDeveloperDB.Classes;
using Npgsql;
using NpgsqlTypes;

namespace HelpDeveloperDB
{
    public partial class ExibeCampos : Form
    {
        public int banco = 0;
        public string host = "";
        public string dataBase = "";
        public string usuario = "";
        public string senha = "";
        public int porta = 0;

        public ExibeCampos()
        {
            InitializeComponent();
        }

        private void ExibeCampos_Shown(object sender, EventArgs e)
        {
            switch (banco)
            {
                case Funcoes.DBSQLSERVER:
                    using (SqlConnection con = Funcoes.retornaConexaoSqlServer(host, dataBase, usuario, senha))
                    {
                        string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                dt.Load(cmd.ExecuteReader());
                                listTabelas.Columns.Add("", 250, HorizontalAlignment.Left);
                                listTabelas.View = View.Details;
                                //listTabelas.Sorting = SortOrder.Ascending;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    ListViewItem lvi = new ListViewItem();
                                    lvi.Text = dr["TABLE_NAME"].ToString();
                                    listTabelas.Items.Add(lvi);
                                }
                            }
                        }
                    }
                    listTabelas.Enabled = true;
                    break;
                case Funcoes.DBPOSTGRESQL:
                    using (NpgsqlConnection pgcon = Funcoes.retornaConexaoPostgres(host, dataBase, usuario, senha, porta))
                    {
                        string sql = "SELECT tablename AS tabela FROM pg_catalog.pg_tables WHERE schemaname IN ('public') ORDER BY tablename";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, pgcon))
                        {
                            using (NpgsqlDataReader dr = cmd.ExecuteReader())
                            {
                                listTabelas.Columns.Add("", 250, HorizontalAlignment.Left);
                                listTabelas.View = View.Details;
                                while (dr.Read())
                                {
                                    ListViewItem lvi = new ListViewItem();
                                    lvi.Text = dr["tabela"].ToString();
                                    listTabelas.Items.Add(lvi);
                                }
                            }
                        }
                    }
                    listTabelas.Enabled = true;
                    break;

            }
            
        }

        private void ExibeCampos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Preenche a lista de Colunas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listTabelas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listTabelas.SelectedItems.Count > 0)
            {
                listColunas.Clear();
                string tabela = listTabelas.SelectedItems[0].Text;
                switch (banco)
                {
                    case Funcoes.DBSQLSERVER:
                        using (SqlConnection con = Funcoes.retornaConexaoSqlServer(host, dataBase, usuario, senha))
                        {
                            string sql = "SELECT c.name AS Coluna, t.name AS TipoDados, ISNULL((SELECT ind.is_primary_key FROM sys.indexes ind " +
                                         "INNER JOIN sys.index_columns ic ON  ind.object_id = ic.object_id and ind.index_id = ic.index_id "+
                                         "WHERE ic.object_id = c.object_id AND ic.column_id = c.column_id),0) as pk FROM sys.COLUMNS c "+
                                         "INNER JOIN sys.types t ON t.system_type_id = c.system_type_id WHERE OBJECT_NAME(object_id) = '"+ tabela +"' "+
                                         "AND t.name <> 'sysname' ORDER BY pk DESC";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    listColunas.Columns.Add("Nome", 250, HorizontalAlignment.Left);
                                    listColunas.Columns.Add("Tipo", 100, HorizontalAlignment.Left);
                                    listColunas.View = View.Details;
                                    listColunas.CheckBoxes = true;
                                    while (dr.Read())
                                    {
                                        ListViewItem lvi = new ListViewItem();
                                        lvi.Text = dr["Coluna"].ToString();
                                        lvi.SubItems.Add(dr["TipoDados"].ToString());
                                        lvi.Checked = true;
                                        listColunas.Items.Add(lvi);
                                    }
                                }
                            }
                        }
                        listColunas.Enabled = true;
                        break;
                    case Funcoes.DBPOSTGRESQL:
                        using (NpgsqlConnection con = Funcoes.retornaConexaoPostgres(host, dataBase, usuario, senha, porta))
                        {
                            string sql = "SELECT c.relname, a.attname AS Coluna, pg_catalog.format_type(a.atttypid, a.atttypmod) AS TipoDados FROM pg_catalog.pg_attribute a " +
                                "INNER JOIN pg_stat_user_tables c ON a.attrelid = c.relid WHERE a.attnum > 0 AND  c.relname = '"+tabela+"' AND NOT a.attisdropped ORDER BY c.relname, a.attname";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                            {
                                using (NpgsqlDataReader dr = cmd.ExecuteReader())
                                {
                                    listColunas.Columns.Add("Nome", 250, HorizontalAlignment.Left);
                                    listColunas.Columns.Add("Tipo", 100, HorizontalAlignment.Left);
                                    listColunas.View = View.Details;
                                    listColunas.CheckBoxes = true;
                                    while (dr.Read())
                                    {
                                        ListViewItem lvi = new ListViewItem();
                                        lvi.Text = dr["Coluna"].ToString();
                                        lvi.SubItems.Add(dr["TipoDados"].ToString());
                                        lvi.Checked = true;
                                        listColunas.Items.Add(lvi);
                                    }
                                }
                            }
                        }
                        listColunas.Enabled = true;
                        break;
                }
                
            }   
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            
            List<ConfigurarGeraCode.Coluna> colunas = new List<ConfigurarGeraCode.Coluna>();

            for (int i = 0; i < listColunas.CheckedItems.Count; i++)
            {
                ConfigurarGeraCode.Coluna col = new ConfigurarGeraCode.Coluna();
                col.nome = listColunas.CheckedItems[i].Text;
                col.tipo = listColunas.CheckedItems[i].SubItems[1].Text;
                colunas.Add(col);
            }
            ConfigurarGeraCode configCode = new ConfigurarGeraCode();
            configCode.setTabela(listTabelas.SelectedItems[0].Text);
            configCode.setColunas(colunas);
            configCode.setBanco(this.banco);
            configCode.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ConfigurarGeraCode.Coluna> colunas = new List<ConfigurarGeraCode.Coluna>();

            for (int i = 0; i < listColunas.CheckedItems.Count; i++)
            {
                ConfigurarGeraCode.Coluna col = new ConfigurarGeraCode.Coluna();
                col.nome = listColunas.CheckedItems[i].Text;
                col.tipo = listColunas.CheckedItems[i].SubItems[1].Text;
                colunas.Add(col);
            }
            ConfiguraCodeFlex geraCodeFlex = new ConfiguraCodeFlex();
            geraCodeFlex.setTabela(listTabelas.SelectedItems[0].Text);
            geraCodeFlex.setColunas(colunas);
            geraCodeFlex.ShowDialog();
        }
    }
}
