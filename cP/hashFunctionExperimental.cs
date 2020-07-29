using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using expHashTable;

namespace cP
{
    public partial class hashFunctionExperimental : Form
    {
        public hashFunctionExperimental()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.textBox1.Text) > Convert.ToInt32(this.textBox2.Text))
            {
                MessageBox.Show("Число записей не может быть больше размера хеш-таблицы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            this.chart1.Series[0].Points.Clear();
            this.dataGridView1.Rows.Clear();

            int a = 0, b = Convert.ToInt32(this.textBox1.Text), step = 1;
            this.textBox4.Text = textBox2.Text;
            this.textBox3.Text = textBox1.Text;
            experimetalHashTable eht = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.chart1.Series[0].Points.Clear();

                StreamReader sr = new StreamReader(ofd.FileName);
                string[] forGrid = new string[2];
                string fromFile;
                int x = a; /*всем прывет с вами я джокер виктор дудка*/
                for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); i++)
                {
                    fromFile = sr.ReadLine();
                    if (fromFile == null)
                    {
                        MessageBox.Show("Число записей в справочнике меньше заданного числа для эксперимента\n" +
                        "Проведён эксперимент для" + i + " записей", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Tuple<int, string, int> y = eht.calcHashAndInsertion(fromFile, i);
                    forGrid[0] = y.Item3.ToString();
                    forGrid[1] = fromFile;
                    this.dataGridView1.Rows.Add(forGrid);
                    this.chart1.Series[0].Points.AddXY(x, y.Item1);
                    x += step;
                }
                sr.Close();
                this.chart1.Titles[0].Text = "Всего коллизиий " + eht.collisionCounter;
            }
        }

        private void hashFunctionExperimental_Load(object sender, EventArgs e)
        {
            this.Width = 1800;
            this.Height = 780;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.textBox3.Text) > Convert.ToInt32(this.textBox4.Text))
            {
                MessageBox.Show("Число записей не может быть меньше размера хеш-таблицы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.chart2.Series[0].Points.Clear();
            this.dataGridView2.Rows.Clear();

            int a = 0, b = Convert.ToInt32(this.textBox1.Text), step = 1, allCollision = 0;
            this.textBox4.Text = textBox2.Text;
            experimetalHashTable eht = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.chart2.Series[0].Points.Clear();

                StreamReader sr = new StreamReader(ofd.FileName);
                string[] forGrid = new string[2];
                string fromFile;
                int x = a;
                for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); i++)
                {
                    fromFile = sr.ReadLine();
                    if (fromFile == null)
                    {
                        MessageBox.Show("Число записей в справочнике меньше заданного числа для эксперимента\n" +
                        "Проведён эксперимент для" + i + " записей", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Tuple<int, string, int> y = eht.calcHashAndInsertion_1(fromFile, i);
                    forGrid[0] = y.Item3.ToString();
                    forGrid[1] = fromFile;
                    this.dataGridView2.Rows.Add(forGrid);
                    this.chart2.Series[0].Points.AddXY(x, y.Item1);
                    x += step;
                }
                sr.Close();
                this.chart2.Titles[0].Text = "Всего коллизиий " + eht.collisionCounter;
            }
        }
    }
}
