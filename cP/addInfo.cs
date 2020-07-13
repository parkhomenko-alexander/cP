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
using System.Windows.Forms.VisualStyles;

namespace cP
{
    public partial class addInfo : Form
    {
        DataGridView dgw;

        public addInfo()
        {
            InitializeComponent();
        }

        public addInfo(DataGridView dgw)
        {
            InitializeComponent();
            this.dgw = dgw;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pMap.info record = new pMap.info(this.textBox2.Text, this.textBox1.Text, this.textBox3.Text);
            int dataValid = record.validator(this.textBox2.Text, this.textBox1.Text, this.textBox3.Text);
            if (dataValid != 0)
            {
                this.textBox4.Text = record.errorHandler(dataValid);
                return;
            }
            int result = mainWindow.payInfoMap.findInArray(record);
            if (result == -1)
            {
                string[] infoToGrid = new string[4];
                infoToGrid[0] = mainWindow.payInfoMap.getHash(this.textBox1.Text).ToString();
                infoToGrid[1] = this.textBox1.Text;
                infoToGrid[2] = this.textBox2.Text;
                infoToGrid[3] = this.textBox3.Text;
                dgw.Rows.Add(infoToGrid);
                mainWindow.payInfoMap.pushBackArray(this.textBox2.Text, this.textBox1.Text, this.textBox2.Text);
                mainWindow.payInfoMap.addInArrayForReport(record);

                this.textBox4.Text = "Запись успешно добавлена в справочнике";

            }
            else
            {
                this.textBox4.Text = "Запись с такими данные уже находится в справочнике";
            }
        }
    }
}
