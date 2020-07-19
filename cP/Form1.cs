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
using HashTable;
using repClass;
using System.IO;
using System.Net.Mail;

namespace cP
{
    public partial class mainWindow : Form
    {
        public static bynaryTree bynaryTreeSourceData = new bynaryTree();
        fileRW objRW = new fileRW();
        public static payMap payInfoMap = new payMap();
        public static hashTable employeeMap = new hashTable();
        public static hashTable personnelMap = new hashTable();
        string sourceFileName;
        public mainWindow()
        {
            InitializeComponent();
        }

        //Загрузка спавочников
        private void initPersonnelInfo_Click(object sender, EventArgs e)
        {
            this.listBonusInfo.Rows.Clear();
            this.listPayInfo.Rows.Clear();
            this.listPersonnelInfo.Rows.Clear();
            this.listEmployeeInfo.Rows.Clear();
            if (bynaryTreeSourceData.arraySize != 1 && bynaryTreeSourceData.array[0].field1 != null)
            {
                bynaryTreeSourceData.root = null;
                bynaryTreeSourceData.arraySize = 1;
                Array.Resize(ref bynaryTreeSourceData.array, bynaryTreeSourceData.arraySize);
                bynaryTreeSourceData.array[0].field1 = null;
                bynaryTreeSourceData.array[0].field2 = null;
                bynaryTreeSourceData.array[0].field3 = null;

                payInfoMap.arraySize = 1;
                Array.Resize(ref payInfoMap.array, payInfoMap.arraySize);
                payInfoMap.array[0].field1 = null;
                payInfoMap.array[0].field2 = null;
                payInfoMap.array[0].field3 = null;
                Array.Resize(ref payInfoMap.arrayForReport, 0);
                payInfoMap.arrayForReportSize = 16;
                Array.Resize(ref payInfoMap.arrayForReport, payInfoMap.arrayForReportSize);

                personnelMap.arraySize = 1;
                Array.Resize(ref personnelMap.array, personnelMap.arraySize);
                personnelMap.array[0].field1 = null;
                personnelMap.array[0].field2 = null;
                personnelMap.array[0].field3 = null;
                Array.Resize(ref personnelMap.arrayRoot, 0);
                personnelMap.arrayRootSize = 16;
                Array.Resize(ref personnelMap.arrayRoot, personnelMap.arrayRootSize);
                for (int i = 0; i < personnelMap.arrayRootSize - 1; i++)
                {
                    personnelMap.arrayRoot[i] = new LinkedList();
                }

                employeeMap.arraySize = 1;
                Array.Resize(ref employeeMap.array, employeeMap.arraySize);
                employeeMap.array[0].field1 = null;
                employeeMap.array[0].field2 = null;
                employeeMap.array[0].field3 = null;
                Array.Resize(ref employeeMap.arrayRoot, 0);
                employeeMap.arrayRootSize = 16;
                Array.Resize(ref employeeMap.arrayRoot, employeeMap.arrayRootSize);
                for (int i = 0; i < employeeMap.arrayRootSize - 1; i++)
                {
                    employeeMap.arrayRoot[i] = new LinkedList();
                }
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
                sourceFileName = openFileDialog.FileName;
            }
            else
            {
                return;
            }
            string tmpStringFromFile = objRW.reader.ReadLine();
            string[] parsedStringForHashTable = new string[3];

            while (tmpStringFromFile != null && tmpStringFromFile[0] == '1')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = payInfoMap.getEmptyHashAddress(parsedStringForHashTable[1]).ToString();
                this.listBonusInfo.Rows.Add(parsedStringForHashTable);
                payInfoMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                pMap.info record = new pMap.info(parsedStringForHashTable[2], parsedStringForHashTable[1], parsedStringForHashTable[3]);
                payInfoMap.addInArrayForReport(record);
                tmpStringFromFile = objRW.reader.ReadLine();
            }

            string[] parsedString = new string[2];
            while (tmpStringFromFile[0] == '2')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                this.listPayInfo.Rows.Add(parsedString);
                bynaryTreeSourceData.pushBackArray(parsedString[0], parsedString[1], parsedString[2]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            bynaryTreeSourceData.initTreeFromePayArray(ref bynaryTreeSourceData.array);

            parsedString = null;

            while (tmpStringFromFile[0] == '3')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = personnelMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listPersonnelInfo.Rows.Add(parsedStringForHashTable);
                personnelMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            personnelMap.initHashTableFromArray();

            while (tmpStringFromFile != null)
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = employeeMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listEmployeeInfo.Rows.Add(parsedStringForHashTable);
                employeeMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            employeeMap.initHashTableFromArray();

            objRW.closeReader();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.listBonusInfo.Rows.Clear();
            this.listPayInfo.Rows.Clear();
            this.listPersonnelInfo.Rows.Clear();
            this.listEmployeeInfo.Rows.Clear();
            if (bynaryTreeSourceData.arraySize != 1 && bynaryTreeSourceData.array[0].field1 != null)
            {
                bynaryTreeSourceData.root = null;
                bynaryTreeSourceData.arraySize = 1;
                Array.Resize(ref bynaryTreeSourceData.array, bynaryTreeSourceData.arraySize);
                bynaryTreeSourceData.array[0].field1 = null;
                bynaryTreeSourceData.array[0].field2 = null;
                bynaryTreeSourceData.array[0].field3 = null;

                payInfoMap.arraySize = 1;
                Array.Resize(ref payInfoMap.array, payInfoMap.arraySize);
                payInfoMap.array[0].field1 = null;
                payInfoMap.array[0].field2 = null;
                payInfoMap.array[0].field3 = null;
                Array.Resize(ref payInfoMap.arrayForReport, 0);
                payInfoMap.arrayForReportSize = 16;
                Array.Resize(ref payInfoMap.arrayForReport, payInfoMap.arrayForReportSize);

                personnelMap.arraySize = 1;
                Array.Resize(ref personnelMap.array, personnelMap.arraySize);
                personnelMap.array[0].field1 = null;
                personnelMap.array[0].field2 = null;
                personnelMap.array[0].field3 = null;
                Array.Resize(ref personnelMap.arrayRoot, 0);
                personnelMap.arrayRootSize = 16;
                Array.Resize(ref personnelMap.arrayRoot, personnelMap.arrayRootSize);
                for (int i = 0; i < personnelMap.arrayRootSize; i++)
                {
                    personnelMap.arrayRoot[i] = new LinkedList();
                }

                employeeMap.arraySize = 1;
                Array.Resize(ref employeeMap.array, employeeMap.arraySize);
                employeeMap.array[0].field1 = null;
                employeeMap.array[0].field2 = null;
                employeeMap.array[0].field3 = null;
                Array.Resize(ref employeeMap.arrayRoot, 0);
                employeeMap.arrayRootSize = 16;
                Array.Resize(ref employeeMap.arrayRoot, employeeMap.arrayRootSize);
                for (int i = 0; i < employeeMap.arrayRootSize; i++)
                {
                    employeeMap.arrayRoot[i] = new LinkedList();
                }
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                objRW.openReader(openFileDialog.FileName);
                sourceFileName = openFileDialog.FileName;
            }
            else
            {
                return;
            }
            string tmpStringFromFile = objRW.reader.ReadLine();
            string[] parsedStringForHashTable = new string[3];

            while (tmpStringFromFile != null && tmpStringFromFile[0] == '1')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = payInfoMap.getEmptyHashAddress(parsedStringForHashTable[1]).ToString();
                this.listBonusInfo.Rows.Add(parsedStringForHashTable);
                payInfoMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                pMap.info record = new pMap.info(parsedStringForHashTable[2], parsedStringForHashTable[1], parsedStringForHashTable[3]);
                payInfoMap.addInArrayForReport(record);
                tmpStringFromFile = objRW.reader.ReadLine();
            }

            string[] parsedString = new string[2];
            while (tmpStringFromFile[0] == '2')
            {
                parsedString = objRW.readerPars(tmpStringFromFile);
                parsedString[0] = parsedString[0].Remove(0, 2);
                this.listPayInfo.Rows.Add(parsedString);
                bynaryTreeSourceData.pushBackArray(parsedString[0], parsedString[1], parsedString[2]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            bynaryTreeSourceData.initTreeFromePayArray(ref bynaryTreeSourceData.array);

            parsedString = null;

            while (tmpStringFromFile[0] == '3')
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = personnelMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listPersonnelInfo.Rows.Add(parsedStringForHashTable);
                personnelMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            personnelMap.initHashTableFromArray();

            while (tmpStringFromFile != null)
            {
                parsedStringForHashTable = objRW.readerPars(tmpStringFromFile, 1);
                parsedStringForHashTable[1] = parsedStringForHashTable[1].Remove(0, 2);
                parsedStringForHashTable[0] = employeeMap.getHash(parsedStringForHashTable[1]).ToString();
                HashTable.info record = new HashTable.info(parsedStringForHashTable[0], parsedStringForHashTable[1], parsedStringForHashTable[2]);
                this.listEmployeeInfo.Rows.Add(parsedStringForHashTable);
                employeeMap.pushBackArray(parsedStringForHashTable[1], parsedStringForHashTable[2], parsedStringForHashTable[3]);
                tmpStringFromFile = objRW.reader.ReadLine();
            }
            employeeMap.initHashTableFromArray();

            objRW.closeReader();
        }
        //

        private void button1_Click(object sender, EventArgs e)
        {
            //int[] array = new int[16];
            //string str = "вафельница";
            //int ha1 = payInfoMap.hFunction1(str);
            //int ha2 = payInfoMap.hFunction2(str);
            //for(int i = 0; i < 16; i++)
            //{
            //    array[i] = (ha1 + i * ha2)%16;
            //}
            //classToReport.pushArray("Губенко Иван Геннадьевич", "asdad", null, null);
            //classToReport.pushArray("Доронин Егор Александрович", "asda", null, null);
            //classToReport.pushArray("Жлуткин Роман Валерьевич", "adffa", null, null);
            //classToReport.pushArray("Каймаков Роман Константинович", "asda", null, null);

        }

        //Поиск записей
        private void button15_Click(object sender, EventArgs e)
        {
            findPayInfo fpi = new findPayInfo();
            fpi.Show();
        }

        private void getPayInfo_Click(object sender, EventArgs e)
        {
            findPayInfo fpi = new findPayInfo();
            fpi.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            findEmployeeInfo fei = new findEmployeeInfo();
            fei.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            findPersonnelInfo fpi = new findPersonnelInfo();
            fpi.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            findBonusInfo fbi = new findBonusInfo();
            fbi.Show();
        }

        //

        //Завершение работы
        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sourceFileName != null)
            {
                StreamWriter writer = new StreamWriter(sourceFileName, false);

                string stringForWrite = null;
                for (int i = 0; i < payInfoMap.arraySize - 1; i++)
                {
                    stringForWrite += "1 " + payInfoMap.array[i].field2 + "; " + payInfoMap.array[i].field1 + "; " + payInfoMap.array[i].field3;
                    writer.WriteLine(stringForWrite);
                    stringForWrite = null;
                }

                stringForWrite = null;
                for (int i = 0; i < bynaryTreeSourceData.arraySize - 1; i++)
                {
                    stringForWrite += "2 " + bynaryTreeSourceData.array[i].field2 + "; " + bynaryTreeSourceData.array[i].field1 + "; " + bynaryTreeSourceData.array[i].field3;
                    writer.WriteLine(stringForWrite);
                    stringForWrite = null;
                }

                stringForWrite = null;
                for (int i = 0; i < personnelMap.arraySize - 1; i++)
                {
                    stringForWrite += "3 " + personnelMap.array[i].field1 + "; " + personnelMap.array[i].field2 + "; " + personnelMap.array[i].field3;
                    writer.WriteLine(stringForWrite);
                    stringForWrite = null;
                }

                stringForWrite = null;
                for (int i = 0; i < employeeMap.arraySize - 1; i++)
                {
                    if (i == employeeMap.arraySize - 2)
                    {
                        stringForWrite += "4 " + employeeMap.array[i].field1 + "; " + employeeMap.array[i].field2 + "; " + employeeMap.array[i].field3;
                        writer.Write(stringForWrite);
                        writer.Close();
                        return;
                    }
                    stringForWrite += "4 " + employeeMap.array[i].field1 + "; " + employeeMap.array[i].field2 + "; " + employeeMap.array[i].field3;
                    writer.WriteLine(stringForWrite);
                    stringForWrite = null;
                }
                writer.Close();
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.CreatePrompt = true;
                sfd.DefaultExt = "txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(sfd.FileName, false);

                    string stringForWrite = null;
                    for (int i = 0; i < payInfoMap.arraySize - 1; i++)
                    {
                        stringForWrite += "1 " + payInfoMap.array[i].field2 + "; " + payInfoMap.array[i].field1 + "; " + payInfoMap.array[i].field3;
                        writer.WriteLine(stringForWrite);
                        stringForWrite = null;
                    }

                    stringForWrite = null;
                    for (int i = 0; i < bynaryTreeSourceData.arraySize - 1; i++)
                    {
                        stringForWrite += "2 " + bynaryTreeSourceData.array[i].field2 + "; " + bynaryTreeSourceData.array[i].field1 + "; " + bynaryTreeSourceData.array[i].field3;
                        writer.WriteLine(stringForWrite);
                        stringForWrite = null;
                    }

                    stringForWrite = null;
                    for (int i = 0; i < personnelMap.arraySize - 1; i++)
                    {
                        stringForWrite += "3 " + personnelMap.array[i].field1 + "; " + personnelMap.array[i].field2 + "; " + personnelMap.array[i].field3;
                        writer.WriteLine(stringForWrite);
                        stringForWrite = null;
                    }

                    stringForWrite = null;
                    for (int i = 0; i < employeeMap.arraySize - 1; i++)
                    {
                        if (i == employeeMap.arraySize - 2)
                        {
                            stringForWrite += "4 " + employeeMap.array[i].field1 + "; " + employeeMap.array[i].field2 + "; " + employeeMap.array[i].field3;
                            writer.Write(stringForWrite);
                            writer.Close();
                            return;
                        }
                        stringForWrite += "4 " + employeeMap.array[i].field1 + "; " + employeeMap.array[i].field2 + "; " + employeeMap.array[i].field3;
                        writer.WriteLine(stringForWrite);
                        stringForWrite = null;
                    }
                    writer.Close();
                }
            }
        }
        //

        //Добавление записей
        private void button17_Click(object sender, EventArgs e)
        {
            addPayInfo ai = new addPayInfo(this.listBonusInfo);
            ai.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            addBonusInfo ai = new addBonusInfo(this.listPayInfo);
            ai.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            addPersonnelInfo ai = new addPersonnelInfo(this.listPersonnelInfo);
            ai.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEmployeeInfo ai = new addEmployeeInfo(this.listEmployeeInfo);
            ai.Show();
        }
        //

        //Отчеты
        private void button10_Click(object sender, EventArgs e)
        {
            reportClass classToReport = new reportClass();
            bynaryTreeSourceData.getReport(bynaryTreeSourceData.root, classToReport, payInfoMap);
            reportPayBonus rep = new reportPayBonus(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[4];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2 ?? "не найденны данные о зп";
                toInsert[2] = classToReport.array[i].field3;
                toInsert[3] = classToReport.array[i].field4;
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            AVL bynaryAvlTree = new AVL();
            for (int i = 0; i < personnelMap.arraySize - 1; i++)
            {
                bynaryAvlTree.Add(personnelMap.array[i].field2, personnelMap.array[i].field1, personnelMap.array[i].field3);
            }

            reportClass classToReport = new reportClass();
            bynaryAvlTree.getReport(bynaryAvlTree.root, classToReport, payInfoMap);
            reportFioPay rep = new reportFioPay(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[2];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2 ?? "не найденны данные о зп";
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            reportClass classToReport = new reportClass();
            personnelMap.getReport(classToReport, employeeMap, payInfoMap);
            reportFioUnitExpPay rep = new reportFioUnitExpPay(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[4];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2;
                toInsert[2] = classToReport.array[i].field3 ?? "не найденны данные о стаже";
                toInsert[3] = classToReport.array[i].field4 ?? "не найденны данные о зп";
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button6_Click(object sender, EventArgs e)
        {   reportClass classToReport = new reportClass();
            personnelMap.getReport(classToReport, employeeMap);
            reportFioPostExp rep = new reportFioPostExp(classToReport);
            rep.Show();
            for (int i = 0; i < classToReport.arraySize - 1; i++)
            {
                string[] toInsert = new string[3];
                toInsert[0] = classToReport.array[i].field1;
                toInsert[1] = classToReport.array[i].field2;
                toInsert[2] = classToReport.array[i].field3 ?? "не найденны данные о стаже";
                rep.dataGridView1.Rows.Add(toInsert);
            }
            MessageBox.Show("Обратите внимание - корректность данных может быть нарушена!\n" +
                "Соответсвующие данные будут отмечены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //

        //Удаление
        private void button16_Click(object sender, EventArgs e)
        {
            if (listBonusInfo.Rows.Count == 1)
            {
                return;
            }
            int indexRow = listBonusInfo.SelectedCells[0].RowIndex;

            if (MessageBox.Show("Удаление может повлечь нарушение целостности информации\n" +
                "Продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = listBonusInfo.Rows[indexRow];
                payInfoMap.eraseFromArray(selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[3].Value.ToString());
                pMap.info record = new pMap.info(selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[3].Value.ToString());
                payInfoMap.removeFromHashTable(record);
                listBonusInfo.Rows.RemoveAt(indexRow);

                string msg = mainWindow.payInfoMap.checkForDownReHashing();
                if (msg != null)
                {
                    listBonusInfo.Rows.Clear();
                    string[] infoToGrid = new string[4];
                    for (int i = 0; i < mainWindow.payInfoMap.arraySize - 1; i++)
                    {   
                        infoToGrid[0] = mainWindow.payInfoMap.getHashToRecord(mainWindow.payInfoMap.array[i].field2).ToString();
                        infoToGrid[1] = mainWindow.payInfoMap.array[i].field2;
                        infoToGrid[2] = mainWindow.payInfoMap.array[i].field1;
                        infoToGrid[3] = mainWindow.payInfoMap.array[i].field3;
                        listBonusInfo.Rows.Add(infoToGrid);
                    }
                    MessageBox.Show("Уровень заполнения хеш-таблицы менее 25% - произошло рехеширование\nРазмер уменьшен", "Рехеширование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                return;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (listPayInfo.Rows.Count == 1)
            {
                return;
            }
            int indexRow = listPayInfo.SelectedCells[0].RowIndex;

            if (MessageBox.Show("Удаление может повлечь нарушение целостности информации\n" +
                "Продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = listPayInfo.Rows[indexRow];
                bynaryTreeSourceData.eraseFromArray(selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[2].Value.ToString());
                bynTree.node record = new bynTree.node(selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[2].Value.ToString());
                bynaryTreeSourceData.removeNode(bynaryTreeSourceData.findNode(record));
                listPayInfo.Rows.RemoveAt(indexRow);

            }
            else
            {
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listEmployeeInfo.Rows.Count == 1)
            {
                return;
            }
            int indexRow = listEmployeeInfo.SelectedCells[0].RowIndex;

            if (MessageBox.Show("Удаление может повлечь нарушение целостности информации\n" +
                "Продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = listEmployeeInfo.Rows[indexRow];
                employeeMap.eraseFromArray(selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString());
                employeeMap.removeFromHashTable(selectedRow.Cells[1].Value.ToString());
                listEmployeeInfo.Rows.RemoveAt(indexRow);

            }
            else
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listPersonnelInfo.Rows.Count == 1)
            {
                return;
            }
            int indexRow = listPersonnelInfo.SelectedCells[0].RowIndex;

            if (MessageBox.Show("Удаление может повлечь нарушение целостности информации\n" +
                "Продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = listPersonnelInfo.Rows[indexRow];
                personnelMap.eraseFromArray(selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString());
                personnelMap.removeFromHashTable(selectedRow.Cells[1].Value.ToString());
                listPersonnelInfo.Rows.RemoveAt(indexRow);

            }
            else
            {
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s1 = "инженер";
            int i = payInfoMap.hFunction1(s1);
            string s2 = "менеджер";
            i = payInfoMap.hFunction1(s2);
            string s3 = "инженер";
            i = payInfoMap.hFunction1(s3);
        }

        //
    }
 
}
