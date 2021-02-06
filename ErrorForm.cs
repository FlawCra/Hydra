using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hydra
{
    public partial class ErrorForm : DarkForm
    {
        public ErrorForm(string message = "", string exception = "")
        {
            InitializeComponent();
            richTextBox1.Text = exception;
            this.ShowDialog();
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
