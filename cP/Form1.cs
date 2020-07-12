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
using pMap;
using avlTree;

namespace cP
{
    public partial class mainWindow : Form
    {
        bynaryTree bynaryTreeSourceData = new bynaryTree();
        fileRW objRW = new fileRW();
        payMap pMap = new payMap();
        AVL avl = new AVL();

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
            string[] parsedStringForHashTable = new string[3];

            while (tmpStringFromFile != null && tmpStringFromFile[0] != '2')
            {   
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = pMap.getHash(parsedStringForHashTable[1]).ToString();
                this.listBonusInfo.Rows.Add(parsedStringForHashTable);
                pMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                pMap.info record = new pMap.info(parsedStringForHashTable[2], parsedStringForHashTable[1], parsedStringForHashTable[3]);
                pMap.addInArrayForReport(record);
                tmpStringFromFile = objRW.reader.ReadLine();
            }

            string[] parsedString = new string[2];
            while (tmpStringFromFile[0] != '3')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                this.listPayInfo.Rows.Add(parsedString);
                bynaryTreeSourceData.pushBackArray(parsedString[0], parsedString[1], parsedString[2]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            parsedString = null;

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

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array = new int[16];
            string str = "Директор";
            for(int i = 0; i < 16; i++)
            {
                array[i] = (pMap.hFunction1(str) + i * pMap.hFunction2(str))%16;
            }
        }
    }
}
