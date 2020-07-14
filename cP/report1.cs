using repClass;
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
    public partial class report1 : Form
    {
        reportClass rC;
        fileRW flRW;

        public report1(reportClass rC, fileRW flRW)
        {
            InitializeComponent();
            this.rC = rC;
            this.flRW = flRW; 
        }

        private void ОК_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.DefaultExt = ".txt";
            if(sfd1.ShowDialog() == DialogResult.OK)
            {
                flRW.openWriter(sfd1.FileName);
                flRW.writer.WriteLine("Отчет о заработных платах и премиях по подолжностям" + "\n\n");
                for (int i = 0; i < rC.arraySize - 1; i++)
                {
                    flRW.writer.WriteLine(rC.array[i].field1 + " " + rC.array[i].field2 +
                        " " + rC.array[i].field3 + " " + rC.array[i].field4 + " ");
                }
            }
            else
            {
                return;
            }
        }
    }
}
