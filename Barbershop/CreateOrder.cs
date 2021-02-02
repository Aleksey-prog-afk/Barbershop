using Barbershop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Barbershop
{
    public partial class CreateOrder : Form
    {
        public CreateOrder()
        {
            InitializeComponent();
            BarbershopDBContext context = new BarbershopDBContext();
            var items = context.Services.ToList();
            foreach(var item in items)
            {
                this.comboBox1.Items.Add(item.Title);
                this.listBox1.Items.Add(item.Title);
            }

        }
    }
}
