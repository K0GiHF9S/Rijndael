using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rijndael
{
    public partial class Form1 : Form
    {
        private readonly string salt = @"akfv#oVfktRhrjo!hjm5t";

        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            this.encryptedText.Text = RijndaelWorker.Encrypt(this.sourceText.Text, this.passwordText.Text, salt);
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            this.sourceText.Text = RijndaelWorker.Decrypt(this.encryptedText.Text, this.passwordText.Text, salt);
        }
    }
}
