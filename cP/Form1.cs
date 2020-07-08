using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using bynaryTreePaySpace;
using fileRWSpace;

namespace cP
{
    public partial class mainWindow : Form
    {
        bynaryTreePay tree = new bynaryTreePay();
        fileRW objRW = new fileRW();

        public mainWindow()
        {
            InitializeComponent();
        }

        private void initBynTreePay_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(OpenFileDialog.FileName);
            }
           
            string tmp = objRW.reader.ReadLine();
            string[] tmpArr;
        
            while (tmp != null)
            {
                tmpArr = objRW.readerPars(tmp);
                this.listPayInfo.Rows.Add(tmpArr);
                tmp = objRW.reader.ReadLine();

            }
            objRW.closeReader();

        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
