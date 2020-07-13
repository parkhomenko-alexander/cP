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
    public partial class findPayInfo : Form
    {   
        public findPayInfo()
        {
            InitializeComponent();
        }

        //чтобы можно было образаться к текст боксу
        public string inputText
        {
            get { return infoBox.Text; }
            set { infoBox.Text = value; }
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
            string post = infoBox.Text;
            Tuple<int, pMap.info, int, string> result = mainWindow.payInfoMap.findInHashTable(post);
            if (result.Item1 != -1 && result.Item1 != -2)
            {
                this.textBox1.Text = result.Item1.ToString();
                this.textBox2.Text = result.Item2.field2;
                this.textBox3.Text = result.Item2.field1;
                this.textBox4.Text = result.Item2.field3.ToString();
                this.textBox5.Text = result.Item3.ToString();
                this.textBox6.Text = result.Item4.ToString();
            }
            else
            {
                this.textBox1.Text = null;
                this.textBox2.Text = null;
                this.textBox3.Text = null;
                this.textBox4.Text = null;
                this.textBox5.Text = null;
                this.textBox6.Text = result.Item4;
            }
            //mainWindow.payInfoMap.findInHashTable
           // mainWindow.payInfoMap
        }
    }
}
