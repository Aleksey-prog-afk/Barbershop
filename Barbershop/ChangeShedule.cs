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
    public partial class ChangeShedule : Form
    {
        private BarbershopDBContext context;
        public ChangeShedule()
        {
            InitializeComponent();
            this.context = new BarbershopDBContext();
            this.dataGridView1.DataSource = context.Masters.ToList();
            this.dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Visible = false;
            for (int i = 0; i < 3; i++)
            {
                this.dataGridView1.Columns[i].ReadOnly = true;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Master master = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Master;
            context.Masters.Update(master);
            context.SaveChanges();
        }
    }
}
