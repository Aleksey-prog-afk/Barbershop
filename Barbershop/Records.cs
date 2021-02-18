using Barbershop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;

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
            string[] records = { "Общий","Мастера", "Услуги" };
            this.comboBox1.Items.AddRange(records);
            this.comboBox1.SelectedItem = this.comboBox1.Items[0];
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            this.start = start;
            this.end = end;

            context = new BarbershopDBContext();
            LoadMainRecord();


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
        private void LoadMainRecord()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            var orders = (from order in context.Orders
                          where order.IsCanceled == false
                          join client in context.Clients on order.ClientId equals client.Id
                          join orderDetail in context.OrderDetails on order.Id equals orderDetail.OrderId
                          join master in context.Masters on orderDetail.MasterId equals master.Id
                          select new
                          {
                              orderId = order.Id,
                              clientName = client.Name,
                              clientPhone = client.Phone,
                              masterName = master.Name,
                              orderDate = order.Date,
                          }).Distinct().ToList();

            this.dataGridView1.Columns.Add("1", "Номер заказа");
            this.dataGridView1.Columns.Add("2", "Имя клиента");
            this.dataGridView1.Columns.Add("3", "Телефон клиента");
            this.dataGridView1.Columns.Add("4", "Имя мастера");
            this.dataGridView1.Columns.Add("5", "Дата заказа");

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
            if (this.comboBox1.SelectedItem == "Общий")
            {
                LoadMainRecord();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("Record.pdf", FileMode.Create));
            doc.Open();

            //Определение шрифта необходимо для сохранения кириллического текста
            //Иначе мы не увидим кириллический текст
            //Если мы работаем только с англоязычными текстами, то шрифт можно не указывать
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            
            //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
            PdfPTable table = new PdfPTable(this.dataGridView1.Columns.Count);
            //Добавим в таблицу общий заголовок
            PdfPCell cell = new PdfPCell(new Phrase(this.comboBox1.SelectedItem.ToString()));

            cell.Colspan = this.dataGridView1.Columns.Count;
            cell.HorizontalAlignment = 1;
            //Убираем границу первой ячейки, чтобы балы как заголовок
            cell.Border = 0;
            table.AddCell(cell);
            //Сначала добавляем заголовки таблицы
            for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
            {
                  cell = new PdfPCell(new Phrase(new Phrase(this.dataGridView1.Columns[j].HeaderText, font)));
                  //Фоновый цвет (необязательно, просто сделаем по красивее)
                  cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                  table.AddCell(cell);
            }

            //Добавляем все остальные ячейки
            for (int j = 0; j < this.dataGridView1.Rows.Count - 1; j++)
            {
                for (int k = 0; k < this.dataGridView1.Columns.Count; k++)
                {
                    try
                    {
                        table.AddCell(new Phrase(this.dataGridView1.Rows[j].Cells[k].Value.ToString(), font));
                    }
                    catch (System.NullReferenceException ex)
                    {
                        table.AddCell(new Phrase("", font));
                    }
                }
            }
                //Добавляем таблицу в документ
                doc.Add(table);
            
            //Закрываем документ
            doc.Close();

            MessageBox.Show("Pdf-документ сохранен");
        }
    }
}
