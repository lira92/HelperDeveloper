using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using NpgsqlTypes;
using System.IO;
using System.Reflection;

namespace HelpDeveloperDB.Classes
{
    class Funcoes
    {
        public const int DBSQLSERVER = 0;
        public const int DBPOSTGRESQL = 1;

        private static SqlConnection conn = null;

        public static SqlConnection retornaConexaoSqlServer(string host, string dataBase, string user, string senha)
        {
            try
            {
                if (conn == null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = host;
                    builder.InitialCatalog = dataBase;
                    builder.UserID = user;
                    builder.Password = senha;
                    builder.PersistSecurityInfo = true;

                    conn = new SqlConnection();
                    conn.ConnectionString = builder.ToString();
                    conn.Open();
                }
                else if(conn.State != ConnectionState.Open)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = host;
                    builder.InitialCatalog = dataBase;
                    builder.UserID = user;
                    builder.Password = senha;
                    builder.PersistSecurityInfo = true;

                    conn = new SqlConnection();
                    conn.ConnectionString = builder.ToString();
                    conn.Open();
                }
                
                return conn;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static NpgsqlConnection retornaConexaoPostgres(string server, string dataBase, string user, string senha, int porta)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection();
                String conexao = "Server = " + server + "; Port = "+porta+"; Database = "+dataBase+"; User Id = "+user+"; Password = "+senha;
                conn.ConnectionString = conexao;
                conn.Open();
                return conn;
            }
            catch (Exception erro)
            {
                throw (new Exception(erro.Source + " - " + erro.Message));
            }
        }

        public static Boolean testarConexao(int Banco, string host, string dataBase, string user, string senha, int porta)
        {
            try
            {
                switch (Banco)
                {
                    case DBSQLSERVER:
                        retornaConexaoSqlServer(host, dataBase, user, senha);
                        return true;
                    case DBPOSTGRESQL:
                        retornaConexaoPostgres(host, dataBase, user, senha, porta);
                        return true;
                    default:
                        return false;
                }
                
            }
            catch
            {
                return false;
            }
        }

        public static string retornaTipoC(string tipoBanco)
        {
            try
            {
                switch (tipoBanco)
                {
                    case "nvarchar":
                    case "nchar":
                    case "varchar":
                    case "char":
                    case "ntext":
                    case "text":
                    {
                        return "string";
                    }
                    case "int":
                    case "numeric":
                    case "integer":
                    {
                        return "int";
                    }
                    case "money":
                    case "real":
                    {
                        return "decimal";
                    }
                    case "bit":
                    case "boolean":
                    {
                        return "Boolean";
                    }
                    case "date":
                    case "datetime":
                    {
                        return "DateTime";
                    }
                    default:
                    return "";
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static string retornaTipoFlex(string tipoBanco)
        {
            try
            {
                switch (tipoBanco)
                {
                    case "nvarchar":
                    case "nchar":
                    case "varchar":
                    case "char":
                    case "ntext":
                        {
                            return "String";
                        }
                    
                    case "numeric":
                    case "money":
                    case "real":
                        {
                            return "Number";
                        }
                    case "int":
                    case "integer":
                        {
                            return "int";
                        }
                    case "bit":
                    case "boolean":
                        {
                            return "Boolean";
                        }
                    case "date":
                    case "datetime":
                        {
                            return "Date";
                        }
                    default:
                        return "";
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static string retornaTipoConversao(string tipoBanco)
        {
            try
            {
                switch (tipoBanco)
                {
                    case "nvarchar":
                    case "nchar":
                    case "varchar":
                    case "char":
                    case "ntext":
                        {
                            return "ToString";
                        }
                    case "int":
                    case "numeric":
                        {
                            return "ToInt32";
                        }
                    case "money":
                    case "real":
                        {
                            return "ToDecimal";
                        }
                    case "bit":
                        {
                            return "ToBoolean";
                        }
                    case "date":
                    case "datetime":
                        {
                            return "ToDateTime";
                        }
                    default:
                        return "";
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message + "\nretornaTipoConversao");
            }
        }

        public static string retornaSqlDbType(string dbType, int banco)
        {
            try
            {
                switch (dbType)
                {
                    case "nvarchar":
                    case "varchar":
                        {
                            if (banco == Funcoes.DBSQLSERVER)
                            {
                                return "NVarChar";
                            }
                            else
                            {
                                return "Varchar";
                            }
                        }
                    case "char":
                    case "nchar":
                        {
                            if (banco == Funcoes.DBSQLSERVER)
                            {
                                return "NChar";
                            }
                            else
                            {
                                return "Char";
                            }
                        }
                    case "int":
                    case "numeric":
                    case "integer":
                        {
                            if (banco == Funcoes.DBSQLSERVER)
                            {
                                return "Int";
                            }
                            else
                            {
                                return "Integer";
                            }
                        }
                    case "money":
                        {
                            return "Money";
                        }
                    case "real":
                        {
                            return "Real";
                        }
                    case "bit":
                        {
                            return "Bit";
                        }
                    case "datetime":
                        {
                            return "DateTime";
                        }
                    case "boolean":
                        {
                            return "Boolean";
                        }
                    case "date":
                        {
                            return "Date";
                        }
                    case "ntext":
                    case "text":
                        {
                            if (banco == Funcoes.DBSQLSERVER)
                            {
                                return "NText";
                            }
                            else
                            {
                                return "Text";
                            }
                        }
                    default:
                        return "";
                        
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message + "\nretornaSqlDbType");
            }
        }


        public static List<string> retornarValoresConfig(string arquivo, string key)
        {
            try
            {
                List<string> valores = new List<string>();
                string[] linhasArquivo = File.ReadAllLines(@"" + arquivo, Encoding.GetEncoding("iso-8859-15"));

                Boolean encontrado = false;
                for (int i = 0; i < linhasArquivo.Length; i++)
                {
                    if (linhasArquivo[i].Trim() == "[" + key + "]")
                    {
                        encontrado = true;
                        i++;
                        while (i < linhasArquivo.Length)
                        {
                            if (!linhasArquivo[i].Contains('['))
                            {
                                valores.Add(linhasArquivo[i]);
                                i++;
                            }
                            if (i == linhasArquivo.Length || linhasArquivo[i].Contains('[')) break;
                        }
                    }
                    if (encontrado) break;
                }
                return valores;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message + "\nretornarValoresConfig");
            }
        }

        public static void escreverConfig(string diretorio, string key, string text)
        {
            string[] arquivo = File.ReadAllLines(diretorio);
            Boolean incluir = true;
            Boolean haAlteracoes = false;
            int primeiraLinha = 0;
            for (int i = 0; i < arquivo.Length; i++)
            {
                if (arquivo[i].Trim() == "[" + key + "]")
                {
                    primeiraLinha = i;
                    while (i < arquivo.Length)
                    {
                        if (arquivo[i] == text)
                        {
                            incluir = false;
                            break;
                        }
                        if ((i + 1) < arquivo.Length)
                        {
                            if (arquivo[i + 1].Contains('['))
                            {
                                break;
                            }
                        }
                        i++;
                    }
                    if (incluir)
                    {
                        arquivo[primeiraLinha] += "\r\n" + text;
                        haAlteracoes = true;
                        break;
                    }
                    break;
                }
            }
            if (haAlteracoes) System.IO.File.WriteAllLines(diretorio, arquivo);
        }


       
    }
}
