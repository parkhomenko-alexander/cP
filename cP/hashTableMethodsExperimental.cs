using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using expHashTable;
using guben;

namespace cP
{
    public partial class hashTableMethodsExperimental : Form
    {
        experimetalHashTable eht = new experimetalHashTable(0);
        experimentalHTGuben eHTG = new experimentalHTGuben(0);
        public int usedCreate = 0;
        public string path;
        public int ins = 0;


        public hashTableMethodsExperimental()
        {
            InitializeComponent();
        }

        private void __Load(object sender, EventArgs e)
        {
            this.Width = 1400;
            this.Height = 780;
            this.Location = new Point(100, 35);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (eht.mapSize == 0)
            {
                return;
            }
            if (textBox1.Text == "")
            {
                textBox4.Clear();
                return;
            }
            int compCounterOA = eht.calcHash(textBox1.Text).Item2;
            if (compCounterOA == -1)
            {
                textBox4.Clear();
                textBox4.Text = "не найден";
                return;
            }
            int compCounterCh = eHTG.arrayRoot[eHTG.getHash(textBox1.Text)].Contains(textBox1.Text).Item2;
            textBox4.Text = compCounterOA + " - " + compCounterCh;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            usedCreate = 1;
            if (Convert.ToInt32(this.textBox6.Text) > Convert.ToInt32(this.textBox7.Text))
            {
                MessageBox.Show("Число записей не может быть больше размера хеш-таблицы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox5.Text != "")
            {
                eHTG.constanta = Convert.ToDouble(textBox5.Text);
            }
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();

            if (eht.mapSize == 0)
            {
                eht = new experimetalHashTable(Convert.ToInt32(this.textBox7.Text));
                eHTG = new experimentalHTGuben(Convert.ToInt32(this.textBox7.Text));
            }

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
                    eht.pushBackArray(fromFile);
                    eHTG.pushBackArray(fromFile);
                }
                sr.Close();
                using (sr = new StreamReader(ofd.FileName))
                {
                    for (int i = 0; i < Convert.ToInt32(this.textBox6.Text); i++)
                    {
                        fromFile = sr.ReadLine();
                        if (fromFile == null)
                        {
                            MessageBox.Show("Число записей в справочнике меньше заданного числа для эксперимента\n" +
                            "Проведён эксперимент для " + i + " записей", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        Tuple<int, string, int> y = eht.calcHashAndInsertion(eht.array[i], i, dataGridView1, ins);
                        eHTG.addHashTable(eht.array[i], dataGridView2);
                        ins++;
                    }
                }
                sr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            if (eHTG.validator(textBox2.Text) == 1)
            {
                return;
            }
            foreach(string s in eht.array)
            {
                if (s == textBox2.Text)
                {
                    MessageBox.Show("Такая запись уже содержится в справочнике", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if(eht.mapSize == 0)
            {
                eht = new experimetalHashTable(Convert.ToInt32(this.textBox7.Text));
                eHTG = new experimentalHTGuben(Convert.ToInt32(this.textBox7.Text));
            }
            eht.pushBackArray(textBox2.Text);
            eHTG.pushBackArray(textBox2.Text);
            Tuple <int, string, int> x = eht.calcHashAndInsertion(textBox2.Text, eht.arraySize - 1, dataGridView1, ins);
            textBox8.Text = x.Item1.ToString();
            eHTG.addHashTable(textBox2.Text, dataGridView2);
            if (x.Item2 != "")
            {
                textBox3.Text = "было";
                eHTG.rehashing(dataGridView2, ins);
            }
            else
            {
                textBox3.Text = "не было";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(usedCreate == 1)
            {
                StreamWriter sr = new StreamWriter(path, false);
                for (int i = 0; i < eHTG.arraySize - 1; i++)
                {
                    if (i == eHTG.arraySize - 2)
                    {
                        sr.Write(eHTG.array[i]);
                        sr.Close();
                        return;
                    }
                    sr.WriteLine(eHTG.array[i]);
                }
                sr.Close();
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sfd.FileName, false);
                for (int i = 0; i < eHTG.arraySize - 1; i++)
                {   
                    if(i == eHTG.arraySize - 2)
                    {
                        sr.Write(eHTG.array[i]);
                        sr.Close();
                        return;
                    } 
                    sr.WriteLine(eHTG.array[i]);
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
