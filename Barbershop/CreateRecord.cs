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
    public partial class CreateRecord : Form
    {
        public CreateRecord()
        {
            InitializeComponent();
            var context = new BarbershopDBContext();
            var items = context.Services.Find();
            //this.comboBox1.
        }
    }
}
