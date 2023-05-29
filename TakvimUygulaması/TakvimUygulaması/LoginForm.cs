using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TakvimUygulaması
{
    public partial class LoginForm : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabelkayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void buttongirisyap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxkullaniciad.Text) || string.IsNullOrEmpty(textBoxpassword.Text))
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Girin", "Hata");
            }
            else
            {
                connection.Open();
                string selectQuery = "SELECT * FROM takvimuygulamasi.kayitlistesi  WHERE KullaniciAdi = '" + textBoxkullaniciad.Text + "' AND Sifre = '" + textBoxpassword.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    MessageBox.Show("Giriş Başarılı!");
                    this.Hide();
                    this.Hide();
                    TakvimForm frm2 = new TakvimForm();
                    frm2.ShowDialog();

                }
                else
                { }
                MessageBox.Show("Yanlış Giriş Bilgileri! Tekrar deneyin.");
            }
            connection.Close();
        }
    }
}
