using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonTask1_Click(object sender, EventArgs e)
        {
            FormTask1 f1 = new FormTask1();
            f1.Show();
        }

        private void ButtonTask2_Click(object sender, EventArgs e)
        {
            FormTask2 f2 = new FormTask2();
            f2.Show();
        }

        private void ButtonTask3_Click(object sender, EventArgs e)
        {
            FormTask3 f3 = new FormTask3();
            f3.Show();
        }
    }
}
