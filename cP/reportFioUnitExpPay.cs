using repClass;
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

namespace cP
{
    public partial class reportFioUnitExpPay : Form
    {
        reportClass rC;

        public reportFioUnitExpPay(reportClass rC)
        {
            InitializeComponent();
            this.rC = rC;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Title = "Сохранение отчета";
            sfd1.CreatePrompt = true;
            sfd1.AddExtension = true;
            sfd1.DefaultExt = "txt";
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter flWR = new System.IO.StreamWriter(sfd1.FileName);
                flWR.WriteLine("Отчет о подразделении, стаже, зп сотрудников" + "\n" + "ФИО \\ подразделение \\ стаж \\ зп\n");
                for (int i = 0; i < rC.arraySize - 1; i++)
                {
                    string strForWrite = rC.array[i].field1 + " \\ ";
                    strForWrite += rC.array[i].field2 + " \\ ";
                    strForWrite += rC.array[i].field3 == null ? "не найдены данные о стаже" + " \\ " : rC.array[i].field3 + " \\ ";
                    strForWrite += rC.array[i].field4 == null ? "не найдены данные о зп" + " \\ " : rC.array[i].field4;
                    flWR.WriteLine(strForWrite);
                }
                flWR.Close();
            }
            else
            {
                return;
            }
        }
    }
}
