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
    public partial class initFile : Form
    {
        public initFile()
        {
            InitializeComponent();
        }

        //чтобы можно было образаться к текст боксу
        public string inputText
        {
            get { return infoBox.Text; }
            set { infoBox.Text = value; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
