using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows;

namespace gerenciamento_NET_wpf.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            
            _connectionString = "Server=888888 ; Database=SQL_DB_1; Integrated Security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public SqlConnection con = null;
        public void Abrir_conexao()
        {
            //testar
            try
            {
                con = new SqlConnection(_connectionString);
                con.Open();
            }
            catch (Exception ex)
            {
                //erro
                MessageBox.Show("Erro no Servidor: ++>" + ex.Message);

            }

        }
        //fecha conexao
        public void fecha_conexao()
        {
            try
            {
                con = new SqlConnection(_connectionString);
                con.Close();
            }
            catch (Exception ex)
            {
                //erro
                MessageBox.Show("Erro no Servidor:-->" + ex.Message);

            }
        }
    }
}
