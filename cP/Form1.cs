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

using bynTree;


namespace cP
{
    public partial class mainWindow : Form
    {
        bynaryTree bynaryTreeSourceData = new bynaryTree();
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

            string tmpStringFromFile = objRW.reader.ReadLine();
            string[] parsedString;

            while (tmpStringFromFile != null && tmpStringFromFile[0] != '2')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                this.listBonusInfo.Rows.Add(parsedString);
                tmpStringFromFile = objRW.reader.ReadLine();
            }

            while (tmpStringFromFile[0] != '3')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                this.listPayInfo.Rows.Add(parsedString);
                bynaryTreeSourceData.pushBackArray(parsedString[0], parsedString[1], parsedString[2]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            bynaryTreeSourceData.initTreeFromePayArray(ref this.bynaryTreeSourceData.array);
            node nd = new node("10", "Менеджер", "33");
            bynaryTreeSourceData.transplantTwoNodes(nd);
            Tuple<node, int> tp = bynaryTreeSourceData.findNode(nd);
            bynaryTreeSourceData.removeNode(tp);
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
