using Barbershop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            var administartor = context.Administrators.FirstOrDefault(admin => admin.Login == this.loginBox.Text);
            if (administartor == null)
            {
                MessageBox.Show("Неверные данные");
            }
            else
            {
                if (GetPasswordHash(this.passwordBox.Text, administartor.Salt) == administartor.Password)
                {
                    this.Hide();
                    Form form = Application.OpenForms.Cast<Form>().Where<Form>((Func<Form, bool>)(x => x.Name == "Menu")).FirstOrDefault<Form>();
                    (!(form is Menu) ? (Control)new Menu(administartor) : (Control)form).Show();
                }
                else
                {
                    MessageBox.Show("Неверные данные");
                }
            }
        }
        private string GetPasswordHash(string password, string salt)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            string hashed = Convert.ToBase64String(sha1.ComputeHash(Encoding.Unicode.GetBytes(password + salt)));
            return hashed;
        }

        private byte[] GetPassSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}
