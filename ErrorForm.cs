using DarkUI.Forms;
using Sentry;
using System;

namespace Hydra
{
    public partial class ErrorForm : DarkForm
    {
        public ErrorForm(Exception exception)
        {
            InitializeComponent();
            SentrySdk.CaptureException(exception);
            richTextBox1.Text = exception.StackTrace;
            this.ShowDialog();
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
