using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using bynTree;
using pMap;
using avlTree;
using cP;

namespace cP
{
    public partial class findEmployeeInfo : Form
    {
        public findEmployeeInfo()
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
            Tuple<int, string, string, string, int, string> findedInfo = mainWindow.employeeMap.findInHashTable(FIO);
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
                this.textBox6.Text = findedInfo.Item6 + " (или справочник не содержит записей)";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void infoBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
