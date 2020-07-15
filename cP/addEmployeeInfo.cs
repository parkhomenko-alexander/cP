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
    public partial class addEmployeeInfo : Form
    {
        DataGridView dgv;
        public addEmployeeInfo(DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Добавление данных может повлечь нарушение целостности информации?\n" +
                   "Все равно добавить?", "Добавление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes)
            {
                HashTable.info record = new HashTable.info(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                int dataValid = record.validator(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                if (dataValid != 0)
                {
                    this.textBox4.Text = record.errorHandler(dataValid);
                    return;
                }
                int result = mainWindow.employeeMap.findInArray(record);
                if (result == -1)
                {
                    string[] infoToGrid = new string[4];
                    infoToGrid[0] = mainWindow.employeeMap.getHash(this.textBox1.Text).ToString();
                    infoToGrid[1] = this.textBox1.Text;
                    infoToGrid[2] = this.textBox2.Text;
                    infoToGrid[3] = this.textBox3.Text;
                    dgv.Rows.Add(infoToGrid);
                    mainWindow.employeeMap.pushBackArray(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                    mainWindow.employeeMap.addHashTable(record);

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
