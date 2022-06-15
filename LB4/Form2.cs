using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string[] arr, string name, string chill, string work)
        {
            InitializeComponent();
            listBox1.Items.AddRange(arr);
            label1.Text = "Тренировка: " + name;
            label3.Text = chill.Substring(0, 2);
            label2.Text = work.Substring(0, 2);
            label2.Visible = false;
            label3.Visible = false;
            timer1.Interval = 1000 * Convert.ToInt32(chill.Substring(0, 2));
            timer2.Interval = 1000 * Convert.ToInt32(work.Substring(0, 2));
            timer3.Interval = 1000;
            label6.Text = arr.Length.ToString();

            
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = "Работа";
            label4.Text = label2.Text;
            timer2.Start();
            timer3.Start();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                listBox1.SelectedIndex = 0;
                SwitchPhoto(listBox1, pictureBox1);

            }
            catch (Exception)
            {
                
            }
        }
        private void SwitchPhoto(ListBox lb, PictureBox pictureBox1)
        {
            switch (lb.SelectedItem.ToString())
            {
                case "Классические отжимания":
                    pictureBox1.Image = Properties.Resources.myshcy_pri_otzhimaniyah;
                    break;
                case "Классический жим лежа":
                    pictureBox1.Image = Properties.Resources.image4_2;
                    break;
                case "Приседания":
                    pictureBox1.Image = Properties.Resources.pravilnoe_dyhanie_pri_prisedaniyah_bez_wesa;
                    break;
                case "Становая тяга":
                    pictureBox1.Image = Properties.Resources._3d295df54a1b3168a0d5f13e18fe03b6;
                    break;
                case "Классические подтягивания":
                    pictureBox1.Image = Properties.Resources.kak_nauchitsya_podtyagivatsya_na_turnike;
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = "Работа";
            label4.Text = label2.Text;
            timer2.Start();
            timer1.Stop();
            SwitchPhoto(listBox1, pictureBox1);

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label4.Text = (Convert.ToInt32(label4.Text) - 1).ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == Convert.ToInt32(label6.Text)-1)
            {
                timer3.Stop();
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Тренировка закончена");
                return;
            }
            label5.Text = "Отдых";
            label4.Text = label3.Text;
            timer2.Stop();
            pictureBox1.Image = null;
            timer1.Start();
            if (listBox1.SelectedIndex < Convert.ToInt32(label6.Text))
            {
                listBox1.SelectedIndex++;
            }

        }
    }
}
