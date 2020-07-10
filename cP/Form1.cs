using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
            }
           
            string tmp = objRW.reader.ReadLine();
            string[] tmpArr;

            while (tmp[0] != '2')
            {
                payInfo payInfoObj = new payInfo();
                bynaryTreeNode bynTreeNodeObj = new bynaryTreeNode();
                tmpArr = objRW.readerPars(tmp);
                tmpArr[0] = tmpArr[0].Remove(0, 2);
                payInfoObj.initInfo(tmpArr);
                bynTreeNodeObj.initNode(payInfoObj);
                tree.addNode(bynTreeNodeObj);
                this.listPayInfo.Rows.Add(tmpArr);
                tmp = objRW.reader.ReadLine();
            }

            while (tmp != null && tmp[0] != '3')
            {
                tmpArr = objRW.readerPars(tmp);
                tmpArr[0] = tmpArr[0].Remove(0, 2);
                this.listBonusInfo.Rows.Add(tmpArr);
                tmp = objRW.reader.ReadLine();
            }

            objRW.closeReader();
        }

        private void initPersonnelInfo_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
            }

            string tmp = objRW.reader.ReadLine();
            string[] tmpArr;

            while (tmp[0] != '2')
            {
                tmp = objRW.reader.ReadLine();
            }
            while (tmp != null && tmp[0] != '3')
            {
                tmp = objRW.reader.ReadLine();
            }

            while (tmp[0] != '4')
            {
                tmpArr = objRW.readerPars(tmp);
                tmpArr[0] = tmpArr[0].Remove(0, 2);
                this.listPersonnelInfo.Rows.Add(tmpArr);
                tmp = objRW.reader.ReadLine();
            }
            while (tmp != null)
            {
                tmpArr = objRW.readerPars(tmp);
                tmpArr[0] = tmpArr[0].Remove(0, 2);
                this.listEmployeeInfo.Rows.Add(tmpArr);
                tmp = objRW.reader.ReadLine();
            }
            objRW.closeReader();
        }

        private void getPayInfo_Click(object sender, EventArgs e)
        {
            findPayInfo fpi = new findPayInfo();
            fpi.Show();
        }
    }
}
