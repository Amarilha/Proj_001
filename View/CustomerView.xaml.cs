using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using gerenciamento_NET_wpf.Models;


using System.Windows.Forms;
using gerenciamento_NET_wpf.Repositories;

namespace gerenciamento_NET_wpf.View
{

    /// <summary>
    /// Interação lógica para CustomerView.xam
    /// </summary>
    public partial class CustomerView : System.Windows.Controls.UserControl
    {
        UserRepository con = new UserRepository();
        
        string sql;
        SqlCommand cmd;

        public CustomerView()
        {
            InitializeComponent();
        }
        private void FormatarGD()
        {
            //dataGridView1.Columns[0].HeaderText = "Código";
            // dataGridView1.Columns[1].HeaderText = "Nome";
            //dataGridView1.Columns[2].HeaderText = "End";
            //dataGridView1.Columns[3].HeaderText = "CPF";
            //dataGridView1.Columns[4].HeaderText = "Tel.:";
            //dataGridView1.Columns[5].HeaderText = "foto";
            //DataGrid.Columns[0].HeaderText = "Name";
            //dataGridView1.Columns[0].Visible = false;

        }
        private void ListarGrid()
        {
            con.Abrir_conexao();
            sql = "SELECT * From App";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGrid.DataContext = dt;
            con.fecha_conexao();
            FormatarGD();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListarGrid();





            ////pegar foto 
            ////ftBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //if (dataGridView1.CurrentRow.Cells[5].Value != DBNull.Value)
            //{
            //    byte[] imagem = (byte[])dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            //    MemoryStream ms = new MemoryStream(imagem);

            //    ftBox.Image = System.Drawing.Image.FromStream(ms);
            //}
            //else
            //{
            //    ftBox.Image = Properties.Resources.sem_imagem;
            //}

           
            //return validUser;



        }

        private IDisposable GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
