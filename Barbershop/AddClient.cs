using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Barbershop
{
    public partial class AddClient : Form
    {
        public string clientName = "";
        public string clientPhone = "";
        public AddClient()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "")
            {
                MessageBox.Show("Введи данные");
                this.DialogResult = DialogResult.Abort;
                return;
            }
            clientName = this.textBox1.Text;
            clientPhone = this.textBox2.Text;
        }
    }
}
