using bynTree;
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

namespace cP
{
    public partial class findBonusInfo : Form
    {
        public findBonusInfo()
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bynTree.node node = new bynTree.node(this.textBox2.Text, this.textBox1.Text, this.textBox3.Text);
            Tuple<node, int> findedNodeInfo= mainWindow.bynaryTreeSourceData.findNode(node);
            
            if(findedNodeInfo.Item2 == -1)
            {
                this.textBox1.Text = null;
                this.textBox2.Text = null;
                this.textBox3.Text = null;
                this.textBox4.Text = null;
                this.textBox5.Text = "Справочник не содержит записей";
            }
            else if (findedNodeInfo.Item2 == -2)
            {
                this.textBox1.Text = null;
                this.textBox2.Text = null;
                this.textBox3.Text = null;
                this.textBox4.Text = null;
                this.textBox5.Text = "Запись не содержится в справочнике";
            }
            else
            {
                this.textBox1.Text = findedNodeInfo.Item1.field2;
                this.textBox2.Text = findedNodeInfo.Item1.field1;
                this.textBox3.Text = findedNodeInfo.Item1.field3;
                this.textBox4.Text = findedNodeInfo.Item2.ToString();
                this.textBox5.Text = "Запись найдена";
            }

        }
    }
}
