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
        private BarbershopDBContext context;
        public CreateOrder()
        {
            InitializeComponent();
            this.context = new BarbershopDBContext();
            var clients = context.Clients.ToList();
            this.comboBox1.DataSource = clients;
            this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker1.MinDate = DateTime.Today;

            var masters = context.Masters.ToList();
            this.listBox1.DataSource = masters;

            var services = context.Services.ToList();
            this.checkedListBox1.DataSource = services;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();

            addClient.ShowDialog(this);
            if (addClient.DialogResult == DialogResult.OK)
            {
                Client newClient = new Client();
                newClient.Name = addClient.clientName;
                newClient.Phone = addClient.clientPhone;
                context.Clients.Add(newClient);
                context.SaveChanges();
                this.comboBox1.DataSource = context.Clients.ToList();
                this.comboBox1.SelectedItem = newClient;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckOnErrors())
            {
                MessageBox.Show("Проверьте данные");
            }
            else
            {
                Order order = new Order();
                order.Client = this.comboBox1.SelectedItem as Client;
                order.Date = this.dateTimePicker1.Value;
                context.Orders.Add(order);
                foreach (Service service in this.checkedListBox1.CheckedItems)
                {
                    OrderDetail detail = new OrderDetail();
                    detail.Order = order;
                    detail.Master = this.listBox1.SelectedItem as Master;
                    detail.Service = service;
                    detail.Cost = service.Price;
                    context.OrderDetails.Add(detail);
                }
                context.SaveChanges();
                MessageBox.Show("Запись сохранена");
            }
        }
        private bool CheckOnErrors()
        {
            bool flag = true;
            if (this.comboBox1.SelectedItem == null)
            {
                flag = false;
            }
            if (this.listBox1.SelectedItem == null)
            {
                flag = false;
            }
            if (this.checkedListBox1.CheckedItems.Count == 0)
            {
                flag = false;
            }

            Master master = this.listBox1.SelectedItem as Master;
            if (this.dateTimePicker1.Value.TimeOfDay < master.WorkBegins 
                || this.dateTimePicker1.Value.TimeOfDay > master.WorkEnds)
            {
                flag = false;
            }
            return flag;
        }
    }
}
