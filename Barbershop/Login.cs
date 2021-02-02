using Barbershop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barbershop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (this.loginBox.Text == "" || this.passwordBox.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            BarbershopDBContext context = new BarbershopDBContext();
            var administartor = context.Administrators.FirstOrDefault(admin => admin.Login == this.loginBox.Text && admin.Password == this.passwordBox.Text);
            if (administartor == null)
            {
                MessageBox.Show("Неверные данные");
            }
            else
            {
                this.Hide();
                Form form = Application.OpenForms.Cast<Form>().Where<Form>((Func<Form, bool>)(x => x.Name == "Menu")).FirstOrDefault<Form>();
                (!(form is Menu) ? (Control)new Menu(administartor) : (Control)form).Show();
            }
        }
    }
}
