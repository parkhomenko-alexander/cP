using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cP
{
    public partial class findPersonnelInfo : Form
    {
        public findPersonnelInfo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox3.Text = null;
            this.textBox4.Text = null;
            this.textBox5.Text = null;
            this.textBox6.Text = null;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FIO = infoBox.Text;
            Tuple<int, string, string, string, int, string> findedInfo = mainWindow.personnelMap.findInHashTable(FIO);
            if (findedInfo.Item5 != -1 && findedInfo.Item5 != -2)
            {
                this.textBox1.Text = findedInfo.Item1.ToString();
                this.textBox2.Text = findedInfo.Item2;
                this.textBox3.Text = findedInfo.Item3;
                this.textBox4.Text = findedInfo.Item4;
                this.textBox5.Text = findedInfo.Item5.ToString();
                this.textBox6.Text = findedInfo.Item6;
            }
            else
            {
                this.textBox1.Text = null;
                this.textBox2.Text = null;
                this.textBox3.Text = null;
                this.textBox4.Text = null;
                this.textBox5.Text = null;
                this.textBox6.Text = findedInfo.Item6 + " (или справочник не сожержит записей)";
            }
        }
    }
}
