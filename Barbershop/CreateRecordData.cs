using Barbershop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Barbershop
{
    public partial class CreateRecordData : Form
    {
        public DateTime start;
        public DateTime end;
        public CreateRecordData()
        {
            InitializeComponent();
            var context = new BarbershopDBContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = this.dateTimePicker1.Value;
            end = this.dateTimePicker2.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}
