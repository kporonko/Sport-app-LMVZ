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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public const string ConnectionString = @"Data Source=DESKTOP-7HK7ORN\SQLSERVER;Initial Catalog=TrainingHelper;Integrated Security=True";
        string zapros = "SELECT Exercise_Name AS 'Упражнение', STRING_AGG(Muscle.Muscle_Name, ',\n') AS 'Мышцы', Exercise.Exercise_Description AS 'Описание' FROM Exercise JOIN Exercise_Muscle" +
            " ON Exercise.Exercise_Id = Exercise_Muscle.Exercise_Id JOIN Muscle ON Exercise_Muscle.Muscle_Id = Muscle.Muscle_Id GROUP BY Exercise.Exercise_Name,Exercise.Exercise_Description ";
            //"SELECT   DISTINCT Exercise.Exercise_Id,  Exercise.Exercise_Name, Exercise.Exercise_Description, Muscle.Muscle_Name FROM Exercise CROSS JOIN " +
            //"Exercise_Muscle CROSS JOIN Muscle";
        
        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSetPlaylists.Playlist_Exercise". При необходимости она может быть перемещена или удалена.
            this.playlist_ExerciseTableAdapter.Fill(this.trainingHelperDataSetPlaylists.Playlist_Exercise);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSetPlaylists.Playlist". При необходимости она может быть перемещена или удалена.
            this.playlistTableAdapter.Fill(this.trainingHelperDataSetPlaylists.Playlist);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet1.Exercise". При необходимости она может быть перемещена или удалена.
            this.exerciseTableAdapter2.Fill(this.trainingHelperDataSet1.Exercise);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSetPhoto.Exercise". При необходимости она может быть перемещена или удалена.
            this.exerciseTableAdapter1.Fill(this.trainingHelperDataSetPhoto.Exercise);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet.Muscle". При необходимости она может быть перемещена или удалена.
            this.muscleTableAdapter.Fill(this.trainingHelperDataSet.Muscle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet.Exercise_Muscle". При необходимости она может быть перемещена или удалена.
            this.exercise_MuscleTableAdapter.Fill(this.trainingHelperDataSet.Exercise_Muscle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet.Exercise". При необходимости она может быть перемещена или удалена.
            this.exerciseTableAdapter.Fill(this.trainingHelperDataSet.Exercise);
            pictureBox1.Image = Properties.Resources.pravilnoe_dyhanie_pri_prisedaniyah_bez_wesa;
            Zapros(ConnectionString, zapros, dataGridView1);
            ZaprosUprVPlaylist(ConnectionString, dataGridView3, listBox1);
            //dataGridView1.Columns[0].Width *= 2;
            //dataGridView1.Columns[1].Width *= 8;
            //dataGridView1.Columns[2].Width *= 3;
        }
        private void Zapros(string ConnectionString, string zapros, DataGridView dataGridView1)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;


                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
        private void ZaprosUprVPlaylist(string ConnectionString, DataGridView dataGridView, ListBox listBox)
        {
                string zapros = $"SELECT Exercise_Name AS 'Упражнение' FROM Exercise JOIN Playlist_Exercise" +
            $" ON Exercise.Exercise_Id = Playlist_Exercise.Exercise_Id JOIN Playlist ON Playlist_Exercise.Playlist_Id = Playlist.Playlist_Id WHERE Playlist_Name = '{listBox1.SelectedValue.ToString()}' ";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView3.DataSource = dt;


                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.exercise_MuscleTableAdapter.FillBy(this.trainingHelperDataSet.Exercise_Muscle);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView1.CurrentCell.Value.ToString();
            if(value == "Классические отжимания")
            {
                pictureBox1.Image = Properties.Resources.myshcy_pri_otzhimaniyah;
            }
            else if(value == "Классический жим лежа")
            {
                pictureBox1.Image = Properties.Resources.image4_2;
            }
            else if (value == "Приседания")
            {
                pictureBox1.Image = Properties.Resources.pravilnoe_dyhanie_pri_prisedaniyah_bez_wesa;
            }
            else if (value == "Становая тяга")
            {
                pictureBox1.Image = Properties.Resources._3d295df54a1b3168a0d5f13e18fe03b6;
            }
            else if (value == "Классические подтягивания")
            {
                pictureBox1.Image = Properties.Resources.kak_nauchitsya_podtyagivatsya_na_turnike;
            }
        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.muscleTableAdapter.FillBy(this.trainingHelperDataSet.Muscle);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string muscle = comboBox1.SelectedItem.ToString();
            ZaprosFilter(muscle, ConnectionString, dataGridView1);
        }
        private void ZaprosFilter(string muscle, string ConnectionString, DataGridView dataGridView1)
        {
            string zapros = $"SELECT Exercise_Name AS 'Упражнение', Muscle.Muscle_Name AS 'Мышцы', Exercise.Exercise_Description AS 'Описание' FROM Exercise JOIN Exercise_Muscle" +
            $" ON Exercise.Exercise_Id = Exercise_Muscle.Exercise_Id JOIN Muscle ON Exercise_Muscle.Muscle_Id = Muscle.Muscle_Id WHERE Muscle.Muscle_Name = '{muscle}'";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;


                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
        private void ZaprosDobavlUpr(string ConnectionString, DataGridView dataGridView3, ListBox lb, DataGridView datagridview2, ListBox lbindex)
        {
            //string pln = listBox1.SelectedValue.ToString();
            //string exn = datagridview2.CurrentCell.Value.ToString();
            //string zapros = $"INSERT INTO Playlist_Exercise([Playlist_Id], [Exercise_Id]) SELECT Playlist.Playlist_Id, Exercise.Exercise_Id FROM " +
            //    $"Exercise JOIN Playlist_Exercise ON Exercise.Exercise_Id = Playlist_Exercise.Exercise_Id JOIN Playlist ON Playlist_Exercise.Playlist_Id = Playlist.Playlist_Id " +
            //    $"WHERE Playlist.Playlist_Name = '{pln}' AND Exercise.Exercise_Name = '{exn}'";
            // string zapros = "INSERT INTO Playlist_Exercise(Playlist_Id, Exercise_Id) VALUES (1,1)";
            int row = dataGridView2.CurrentCell.RowIndex;
            int pl = Convert.ToInt32(lbindex.SelectedValue.ToString());
            int exe = (int)dataGridView2.Rows[row].Cells[1].Value;
            string zapros = $"INSERT INTO Playlist_Exercise([Playlist_Id], [Exercise_Id]) VALUES('{pl}', '{exe}')";
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
                MessageBox.Show("Ошибка. Это упражнение уже находится в плэйлисте.");
            }
            ZaprosUprVPlaylist(ConnectionString, dataGridView3, lb);
        }
        

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Zapros(ConnectionString, zapros, dataGridView1);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            listBox1.SelectedIndex = 0;
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PlaylistName pn = new PlaylistName();
            pn.Show();
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSetPlaylists.Playlist_Exercise". При необходимости она может быть перемещена или удалена.
            this.playlist_ExerciseTableAdapter.Fill(this.trainingHelperDataSetPlaylists.Playlist_Exercise);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSetPlaylists.Playlist". При необходимости она может быть перемещена или удалена.
            this.playlistTableAdapter.Fill(this.trainingHelperDataSetPlaylists.Playlist);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet1.Exercise". При необходимости она может быть перемещена или удалена.
            this.exerciseTableAdapter2.Fill(this.trainingHelperDataSet1.Exercise);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSetPhoto.Exercise". При необходимости она может быть перемещена или удалена.
            this.exerciseTableAdapter1.Fill(this.trainingHelperDataSetPhoto.Exercise);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet.Muscle". При необходимости она может быть перемещена или удалена.
            this.muscleTableAdapter.Fill(this.trainingHelperDataSet.Muscle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet.Exercise_Muscle". При необходимости она может быть перемещена или удалена.
            this.exercise_MuscleTableAdapter.Fill(this.trainingHelperDataSet.Exercise_Muscle);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "trainingHelperDataSet.Exercise". При необходимости она может быть перемещена или удалена.
            this.exerciseTableAdapter.Fill(this.trainingHelperDataSet.Exercise);
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                playlistTableAdapter.DeleteQuery(listBox1.SelectedValue.ToString());
                listBox1.SelectedIndex = 0;

                playlistTableAdapter.Fill(trainingHelperDataSetPlaylists.Playlist);
                trainingHelperDataSetPlaylists.AcceptChanges();
            }
            else
            {
                return;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ZaprosUprVPlaylist(ConnectionString, dataGridView3, listBox1);
                textBox1.Text = listBox1.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZaprosDobavlUpr(ConnectionString, dataGridView3,listBox1 ,dataGridView2, listBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int row = dataGridView2.CurrentCell.RowIndex;
                int pl = Convert.ToInt32(listBox2.SelectedValue.ToString());
                int exe = (int)dataGridView2.Rows[row].Cells[1].Value;
                playlist_ExerciseTableAdapter.DeleteQuery(pl, exe);
                //playlist_ExerciseTableAdapter.DeleteQueryNorm(dataGridView3.CurrentCell.Value.ToString(), pl);
                ZaprosUprVPlaylist(ConnectionString, dataGridView3, listBox1);
            }
            else
            {
                return;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string zapros = "SELECT Exercise_Name AS 'Упражнение', STRING_AGG(Muscle.Muscle_Name, ',\n') AS 'Мышцы', Exercise.Exercise_Description AS 'Описание' FROM Exercise JOIN Exercise_Muscle" +
            $" ON Exercise.Exercise_Id = Exercise_Muscle.Exercise_Id JOIN Muscle ON Exercise_Muscle.Muscle_Id = Muscle.Muscle_Id WHERE Exercise.Exercise_Name LIKE '%{textBox2.Text}%' " +
            $"GROUP BY Exercise.Exercise_Name,Exercise.Exercise_Description";
            Zapros(ConnectionString, zapros, dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string zapros = "SELECT Exercise_Name AS 'Упражнение', STRING_AGG(Muscle.Muscle_Name, ',\n') AS 'Мышцы', Exercise.Exercise_Description AS 'Описание' FROM Exercise JOIN Exercise_Muscle" +
            //$" ON Exercise.Exercise_Id = Exercise_Muscle.Exercise_Id JOIN Muscle ON Exercise_Muscle.Muscle_Id = Muscle.Muscle_Id WHERE Exercise.Exercise_Name = '{textBox2.Text}' " +
            //$"GROUP BY Exercise.Exercise_Name,Exercise.Exercise_Description";
            string zapros = "SELECT Exercise_Name AS 'Упражнение', STRING_AGG(Muscle.Muscle_Name, ',\n') AS 'Мышцы', Exercise.Exercise_Description AS 'Описание' FROM Exercise JOIN Exercise_Muscle" +
            $" ON Exercise.Exercise_Id = Exercise_Muscle.Exercise_Id JOIN Muscle ON Exercise_Muscle.Muscle_Id = Muscle.Muscle_Id WHERE Exercise.Exercise_Name LIKE '%{textBox2.Text}%' " +
            $"GROUP BY Exercise.Exercise_Name,Exercise.Exercise_Description";
            Zapros(ConnectionString, zapros, dataGridView1);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чтоб добавить упражнение в плэйлист нужно найти упражнение в правой колонке, нужный плэйлист в левой колонке, нажать на них и нажать на кнопку 'Добавить'\n" +
                "Чтоб удалить упражнение из плэйлиста нужно найти упражнение в правой колонке, нужный плэйлист в левой колонке, нажать на них и нажать на кнопку 'Удалить'");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чтоб посмотреть фото упражнения нажмите на название упражнения в списке");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] arr = new string[dataGridView3.Rows.Count - 1];
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                arr[i] = dataGridView3.Rows[i].Cells[0].Value.ToString();
            }
            try
            {
                if(listBox1.SelectedValue == null || listBox3.SelectedItem == null || listBox4.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали время или плэйлист");
                    return;
                }
                Form2 form2 = new Form2(arr, listBox1.SelectedValue.ToString(), listBox3.SelectedItem.ToString(), listBox4.SelectedItem.ToString());
                form2.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Вы не выбрали время или плэйлист");
            } 

        }
    }
}
