using DarkUI.Forms;
using System;

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
