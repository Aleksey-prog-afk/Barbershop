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
    public partial class Records : Form
    {
        private DateTime start;
        private DateTime end;
        private BarbershopDBContext context;
        public Records(DateTime start, DateTime end)
        {
            InitializeComponent();
            string[] records = { "Мастера", "Услуги" };
            this.comboBox1.Items.AddRange(records);
            this.comboBox1.SelectedItem = this.comboBox1.Items[0];
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            this.start = start;
            this.end = end;

            context = new BarbershopDBContext();
            LoadMastersRecord();

           
        }
        private void LoadMastersRecord()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            int ordersCount = context.Orders.Where(order => order.Date >= start)
                                      .Where(order => order.Date <= end)
                                      .Count();
            var orderDetails = context.OrderDetails
                                       .Where(orderDetail => orderDetail.Order.Date >= start)
                                       .Where(orderDetail => orderDetail.Order.Date <= end)
                                       .GroupBy(orderDetail => orderDetail.MasterId)
                                       .Select(detail => new { id = detail.Key, count = detail.Count() })
                                       .ToList();

            this.dataGridView1.Columns.Add("1", "1");
            this.dataGridView1.Columns.Add("1", "1");
            this.dataGridView1.Columns.Add("1", "1");
            this.dataGridView1.Rows.Add();

            this.dataGridView1.Columns[0].HeaderText = "Общее количество заказов";
            this.dataGridView1.Rows[0].Cells[0].Value = ordersCount;
            this.dataGridView1.Columns[1].HeaderText = "Имя мастера";
            this.dataGridView1.Columns[2].HeaderText = "Количество оказанных услуг";
            for (int i = 0; i < orderDetails.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                var master = context.Masters.FirstOrDefault(master => master.Id == orderDetails[i].id);
                this.dataGridView1.Rows[i + 1].Cells[1].Value = master.Name;
                this.dataGridView1.Rows[i + 1].Cells[2].Value = orderDetails[i].count;
            }
            //orderDetails.GroupBy(orderDetail => orderDetail.Master);
        }
        private void LoadServicesRecord()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            var orderDetails = context.OrderDetails
                                       .Where(orderDetail => orderDetail.Order.Date >= start)
                                       .Where(orderDetail => orderDetail.Order.Date <= end)
                                       .GroupBy(orderDetail => orderDetail.ServiceId)
                                       .Select(detail => new { id = detail.Key, count = detail.Count() })
                                       .ToList();

            this.dataGridView1.Columns.Add("1", "Наименование услуги");
            this.dataGridView1.Columns.Add("2", "Количество заказов");

            for (int i = 0; i < orderDetails.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                var service = context.Services.FirstOrDefault(master => master.Id == orderDetails[i].id);
                this.dataGridView1.Rows[i].Cells[0].Value = service.Title;
                this.dataGridView1.Rows[i].Cells[1].Value = orderDetails[i].count;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == "Мастера")
            {
                LoadMastersRecord();
            }
            if (this.comboBox1.SelectedItem == "Услуги")
            {
                LoadServicesRecord();
            }
        }

    }
}
