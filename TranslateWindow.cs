using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NextMinuteT9Paxton
{
    public partial class TranslateWindow : Form
    {
        public TranslateWindow()
        {
            InitializeComponent();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (string line in txtInput.Lines)
                {
                    int index = txtInput.Lines.ToList().IndexOf(line);

                    if (index > 0)
                        txtOutput.Text += "Case#" + (index).ToString() + ": " + T9Translator.TranslateLine(line) + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

    }
}
