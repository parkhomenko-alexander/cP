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
        experimetalHashTable eht1 = new experimetalHashTable(0);
        experimetalHashTable eht2 = new experimetalHashTable(0);
        public int usedCreate = 0;
        int ins = 0;
        string path;

        public hashFunctionExperimental()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox6.Text = "не было";
            if (Convert.ToInt32(this.textBox1.Text) > Convert.ToInt32(this.textBox2.Text))
            {
                MessageBox.Show("Число записей не может быть больше размера хеш-таблицы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            this.chart1.Series[0].Points.Clear();
            this.dataGridView1.Rows.Clear();
            this.chart2.Series[0].Points.Clear();
            this.dataGridView2.Rows.Clear();
            ins = 0;

            if (eht1.mapSize == 0)
            {
                eht1 = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
                eht2 = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
            }

            int a = 0;
            int b = Convert.ToInt32(this.textBox1.Text);
            int step = 1;
            usedCreate = 1;
            eht1 = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
            eht2 = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                StreamReader sr = new StreamReader(ofd.FileName);
                string fromFile = "";
                while (fromFile != null)
                {
                    fromFile = sr.ReadLine();
                    if (fromFile == null)
                    {
                        break;
                    }
                    eht1.pushBackArray(fromFile);
                    eht2.pushBackArray(fromFile);
                }
                sr.Close();

                sr = new StreamReader(ofd.FileName);
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
                    var y = eht1.calcHashAndInsertion(fromFile, i, dataGridView1,chart1, ref  x, step, ins);
                    eht2.calcHashAndInsertion_1(fromFile, i, dataGridView2, chart2, ref x, step, ins);
                    ins++;
                    if(y.Item2 != "")
                    {
                        textBox6.Text = "было";
                    }
                }
                sr.Close();
                this.chart1.Titles[0].Text = "Всего коллизиий " + eht1.collisionCounter;
                this.chart2.Titles[0].Text = "Всего коллизиий " + eht2.collisionCounter;
            }
        }

        private void hashFunctionExperimental_Load(object sender, EventArgs e)
        {
            this.Width = 1400;
            this.Height = 780;
            this.Location = new Point(100, 35);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                return;
            }

            if (eht1.validator(textBox5.Text) == 1)
            {
                return;
            }

            foreach (string s in eht1.array)
            {
                if (s == textBox5.Text)
                {
                    MessageBox.Show("Такая запись уже содержится в справочнике", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (eht1.mapSize == 0)
            {
                eht1 = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
                eht2 = new experimetalHashTable(Convert.ToInt32(this.textBox2.Text));
            }

            eht1.pushBackArray(textBox5.Text);
            eht2.pushBackArray(textBox5.Text);
            int y = 0;
            Tuple<int, string, int> x = eht1.calcHashAndInsertion(textBox5.Text, eht1.arraySize - 1, dataGridView1, chart1, ref y, 1, ins);
            eht2.calcHashAndInsertion_1(textBox5.Text, eht2.arraySize - 1, dataGridView2, chart2, ref y, 1, ins);
            if (x.Item2 != "")
            {
                textBox6.Text = "было";
                this.chart1.Titles[0].Text = "Всего коллизиий " + eht1.collisionCounter;
                this.chart2.Titles[0].Text = "Всего коллизиий " + eht2.collisionCounter;
            }
            else
            {
                textBox6.Text = "не было";
                this.chart1.Titles[0].Text = "Всего коллизиий " + eht1.collisionCounter;
                this.chart2.Titles[0].Text = "Всего коллизиий " + eht2.collisionCounter;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usedCreate == 1)
            {
                StreamWriter sr = new StreamWriter(path, false);
                for (int i = 0; i < eht1.arraySize - 1; i++)
                {
                    if (i == eht1.arraySize - 2)
                    {
                        sr.Write(eht1.array[i]);
                        sr.Close();
                        return;
                    }
                    sr.WriteLine(eht1.array[i]);
                }
                sr.Close();
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sfd.FileName, false);
                for (int i = 0; i < eht1.arraySize - 1; i++)
                {
                    if (i == eht1.arraySize - 2)
                    {
                        sr.Write(eht1.array[i]);
                        sr.Close();
                        return;
                    }
                    sr.WriteLine(eht1.array[i]);
                }
                sr.Close();
            }
            else
            {
                return;
            }
        }
    }
}
