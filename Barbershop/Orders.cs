using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Barbershop.Models;

namespace Barbershop
{

    public partial class Orders : Form
    {
        private BarbershopDBContext context;
        public Orders()
        {
            InitializeComponent();
            this.context = new BarbershopDBContext();
            var orders = (from order in context.Orders
                         where order.IsCanceled == false
                         join client in context.Clients on order.ClientId equals client.Id
                         join orderDetail in context.OrderDetails on order.Id equals orderDetail.OrderId
                         join master in context.Masters on orderDetail.MasterId equals master.Id
                         select  new
                         {
                             orderId = order.Id,
                             clientName = client.Name,
                             clientPhone = client.Phone,
                             masterName = master.Name,
                             orderDate = order.Date
                         }).Distinct().ToList();

            this.dataGridView1.Columns.Add("0", "ID Записи");
            this.dataGridView1.Columns.Add("1", "Клиент");
            this.dataGridView1.Columns.Add("2", "Телефон клиента");
            this.dataGridView1.Columns.Add("3", "Мастер");
            this.dataGridView1.Columns.Add("4", "Дата записи");
            for (int i = 0; i < orders.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].Cells[0].Value = orders[i].orderId;
                this.dataGridView1.Rows[i].Cells[1].Value = orders[i].clientName;
                this.dataGridView1.Rows[i].Cells[2].Value = orders[i].clientPhone;
                this.dataGridView1.Rows[i].Cells[3].Value = orders[i].masterName;
                this.dataGridView1.Rows[i].Cells[4].Value = orders[i].orderDate;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                var order = context.Orders.FirstOrDefault(order => order.Id == (int)row.Cells[0].Value);
                order.IsCanceled = true;
                context.Orders.Update(order);
                count++;
            }
            context.SaveChanges();
            MessageBox.Show($"Отменено {count} записей");
            this.DialogResult = DialogResult.OK;
        }
    }
}
