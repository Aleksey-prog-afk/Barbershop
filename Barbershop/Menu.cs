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
    public partial class Menu : Form
    {
        private Administrator administrator;
        public Menu(Administrator administrator)
        {
            InitializeComponent();
            this.administrator = administrator;
            this.label1.Text = $"Вы вошли как: {administrator.Name}";
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CreateOrder>().Count() > 0)
                return;
            CreateOrder newForm = new CreateOrder();
            newForm.Show();
        }

        private void changeScheduleButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ChangeShedule>().Count() > 0)
                return;
            ChangeShedule newForm = new ChangeShedule();
            newForm.Show();
        }

        private void createRecordButton_Click(object sender, EventArgs e)
        {
            CreateRecord createRecord = new CreateRecord();
            createRecord.ShowDialog();
            if (createRecord.DialogResult == DialogResult.OK)
            {

            }
        }
    }
}
