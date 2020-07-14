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
using HashTable;
using repClass;
using System.IO;

namespace cP
{
    public partial class reportFioPostExp : Form
    {
        reportClass rC;

        public reportFioPostExp(reportClass rC)
        {
            InitializeComponent();
            this.rC = rC;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Title = "Сохранение отчета";
            sfd1.CreatePrompt = true;
            sfd1.AddExtension = true;
            sfd1.DefaultExt= "txt";
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter flWR = new System.IO.StreamWriter(sfd1.FileName);
                flWR.WriteLine("Отчет о стаже и должности сотрудников" + "\n" + "ФИО \\ должность \\ стаж\n");
                for (int i = 0; i < rC.arraySize - 1; i++)
                {
                    string strForWrite = rC.array[i].field1 + " \\ ";
                    strForWrite += rC.array[i].field2 + " \\ ";    
                    strForWrite += rC.array[i].field3 == null ? "не найдены данные о стаже" : rC.array[i].field3;
                    flWR.WriteLine(strForWrite);
                }
                flWR.Close();
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
