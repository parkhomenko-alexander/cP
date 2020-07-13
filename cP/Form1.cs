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
        public void rewriteFile()
        {

        }
        public static bynaryTree bynaryTreeSourceData = new bynaryTree();
        fileRW objRW = new fileRW();
        public static payMap payInfoMap = new payMap();
        AVL avl = new AVL();
        string sourceFileName;
        public mainWindow()
        {
            InitializeComponent();
        }

        private void initPersonnelInfo_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
                sourceFileName = openFileDialog.FileName;
            }

            string tmpStringFromFile = objRW.reader.ReadLine();
            string[] parsedString;

            while (tmpStringFromFile[0] != '2')
            {
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            while (tmpStringFromFile[0] != '3')
            {
                tmpStringFromFile = objRW.reader.ReadLine();
            }

            while (tmpStringFromFile[0] != '4')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                avlTree.info record = new avlTree.info(parsedString[0], parsedString[1], parsedString[2]);
                this.listPersonnelInfo.Rows.Add(parsedString);
                avl.pushBackArray(parsedString[0], parsedString[1], parsedString[2]);
                avl.Add(parsedString[1], parsedString[0]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            //while (tmp != null)
            //{
            //    tmpArr = objRW.readerPars(tmp);
            //    tmpArr[0] = tmpArr[0].Remove(0, 2);
            //    this.listEmployeeInfo.Rows.Add(tmpArr);
            //    tmp = objRW.reader.ReadLine();
            //}
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
            string str = "Экономист";
            int ha1 = payInfoMap.hFunction1(str);
            int ha2 = payInfoMap.hFunction2(str);
            for(int i = 0; i < 16; i++)
            {
                array[i] = (ha1 + i * ha2)%16;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
                sourceFileName = openFileDialog.FileName;
            }

            string tmpStringFromFile = objRW.reader.ReadLine();
            string[] parsedStringForHashTable = new string[3];

            while (tmpStringFromFile != null && tmpStringFromFile[0] != '2')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = payInfoMap.getHash(parsedStringForHashTable[1]).ToString();
                this.listBonusInfo.Rows.Add(parsedStringForHashTable);
                payInfoMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                pMap.info record = new pMap.info(parsedStringForHashTable[2], parsedStringForHashTable[1], parsedStringForHashTable[3]);
                payInfoMap.addInArrayForReport(record);
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

        private void button15_Click(object sender, EventArgs e)
        {
            findPayInfo fpi = new findPayInfo();
            //fpi.
            fpi.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int indexRow = listBonusInfo.SelectedCells[0].RowIndex;
            
            if (MessageBox.Show("Удаление может повлечь нарушение целостности информации?\n " +
                "Продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes)
            {
                listBonusInfo.Rows.RemoveAt(indexRow);
            }
            else
            {
                return;
            }

        }

        private void listBonusInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
