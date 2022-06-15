using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB4
{
    public partial class PlaylistName : Form
    {
        public PlaylistName()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public const string ConnectionString = @"Data Source=DESKTOP-7HK7ORN\SQLSERVER;Initial Catalog=TrainingHelper;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            ZaprosInsert(ConnectionString, textBox1);
            this.Hide();
        }
        private void ZaprosInsert(string ConnectionString, TextBox tb)
        {
            int index = ZaprosCount(ConnectionString) + 1;
            string zapros = $"INSERT INTO Playlist(Playlist_Id, Playlist_Name) VALUES ({index},'{tb.Text}')";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                
                DataTable dt = new DataTable();
                oda.Fill(dt);
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
        private int ZaprosCount(string ConnectionString)
        {
            string zapros = $"SELECT COUNT(Playlist_Id) FROM Playlist";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);

                DataTable dt = new DataTable();
                oda.Fill(dt);
                int res = (int)dt.Rows[0].ItemArray[0];
                sqlconn.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
            return 0;
        }

        private void PlaylistName_Load(object sender, EventArgs e)
        {

        }
    }
}
