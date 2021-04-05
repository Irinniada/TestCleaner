using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NMFileClasses;

namespace TestCleaner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindTemp findTemp = new FindTemp();
            listBox1.Items.Clear();
            findTemp.listOfFiles.ForEach(delegate (String name)
            {
                listBox1.Items.Add(name);
            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTemp clearTemp = new ClearTemp(listBox1, progressBar1);
        }
    }
}
