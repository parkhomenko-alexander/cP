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

namespace cP
{
    public partial class mainWindow : Form
    {
        bynaryTreePay tree = new bynaryTreePay();
        public mainWindow()
        {
            InitializeComponent();
        }

        private void initBynTreePay_Click(object sender, EventArgs e)
        {
            string fileName = "bynTreePay.txt";
            string path = @"C:\Users\al\source\repos\cP\cP\";
            if (tree.checkDirectory(path + fileName) == false)
            {
                initFile notID = new initFile();
                notID.inputText = "Файл " + fileName + " не найден в директории" + System.Environment.NewLine + System.Environment.NewLine;
                notID.inputText += path;
                notID.Show();
            }
            else
            {
                tree.getReader(path + fileName);
                string tmp = tree.reader.ReadLine();
                string[] tmpArr;
        
                while (tmp != null)
                {
                    tmpArr = tree.readerPars(tmp);
                    this.listPayInfo.Rows.Add(tmpArr);
                    tmp = tree.reader.ReadLine();

                }
                initFile notID = new initFile();
                notID.inputText = "Файл " + fileName + " найден в директории" + System.Environment.NewLine;
                notID.inputText += path + System.Environment.NewLine + "Дерево инициализировано успешно";
                notID.Show();
            }
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
