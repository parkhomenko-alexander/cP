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
    public partial class addBonusInfo : Form
    {
        DataGridView dgw;
        public addBonusInfo(DataGridView dgw)
        {
            InitializeComponent();
            this.dgw = dgw;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавление данных может повлечь нарушение целостности информации\n" +
                   "Все равно добавить?", "Добавление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes)
            {
                bynTree.info record = new bynTree.info(this.textBox2.Text, this.textBox1.Text, this.textBox3.Text);
                int dataValid = record.validator(this.textBox2.Text, this.textBox1.Text, this.textBox3.Text);
                if (dataValid != 0)
                {
                    this.textBox4.Text = record.errorHandler(dataValid);
                    return;
                }
                int result = mainWindow.bynaryTreeSourceData.findInArray(record);
                if (result == -1)
                {
                    string[] infoToGrid = new string[3];
                    infoToGrid[0] = this.textBox1.Text;
                    infoToGrid[1] = this.textBox2.Text;
                    infoToGrid[2] = this.textBox3.Text;
                    dgw.Rows.Add(infoToGrid);
                    mainWindow.bynaryTreeSourceData.pushBackArray(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                    bynTree.node node = new bynTree.node(this.textBox2.Text, this.textBox1.Text, this.textBox3.Text);
                    mainWindow.bynaryTreeSourceData.addNode(node);

                    this.textBox4.Text = "Запись успешно добавлена в справочник";
                }
                else
                {
                    this.textBox4.Text = "Запись с такими данные уже находится в справочнике";
                }
            }
            else
            {
                return;
            }
        }
    }
}
