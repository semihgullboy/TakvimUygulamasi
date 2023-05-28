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
    public partial class RegisterForm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void linkLabeldonuslogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonkayitol_Click(object sender, EventArgs e)
        {
            if (!this.textBoxemail.Text.Contains('@') || !this.textBoxemail.Text.Contains('.'))
            {
                MessageBox.Show("Lütfen Geçerli Bir E-posta Girin", "Geçersiz E-posta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxpassword.Text != textBoxpassword2.Text)
            {
                MessageBox.Show("Şifre eşleşmiyor!", "Hata");
                return;
            }

            if (string.IsNullOrEmpty(textBoxad.Text) || string.IsNullOrEmpty(textBoxsoyad.Text) || string.IsNullOrEmpty(textBoxkullaniciad.Text) || string.IsNullOrEmpty(textBoxpassword.Text) || string.IsNullOrEmpty(textBoxpassword2.Text) || string.IsNullOrEmpty(textBoxtcno.Text) || string.IsNullOrEmpty(textBoxtelno.Text) || string.IsNullOrEmpty(textBoxemail.Text) || string.IsNullOrEmpty(textBoxadres.Text))
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun!", "Hata");
                return;
            }

            else
            {
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM takvimuygulamasi.kayitlistesi WHERE KullaniciAdi = @KullaniciAdi", connection),
                cmd2 = new MySqlCommand("SELECT * FROM takvimuygulamasi.kayitlistesi WHERE Email = @Email", connection);
                cmd1.Parameters.AddWithValue("@KullaniciAdi", textBoxkullaniciad.Text);
                cmd2.Parameters.AddWithValue("@Email", textBoxemail.Text);
                bool userExists = false, mailExists = false;
                using (var dr1 = cmd1.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Kullanıcı adı mevcut değil!");

                using (var dr2 = cmd2.ExecuteReader())
                    if (mailExists = dr2.HasRows) MessageBox.Show("Email mevcut değil!");

                if (!(userExists || mailExists))
                {
                    string iquery = "INSERT INTO  takvimuygulamasi.kayitlistesi(`ID`,`Ad`,`Soyad`,`KullaniciAdi`,`Sifre`,`SifreTekrar`,`TcKimlikNo`, `TelNo` , `Email` , `Adres`) VALUES (NULL, '" + textBoxad.Text + "', '" + textBoxsoyad.Text + "', '" + textBoxkullaniciad.Text + "', '" + textBoxpassword.Text + "', '" + textBoxpassword2.Text + "', '" + textBoxtcno.Text + "', '" + textBoxtelno.Text + "', '" + textBoxemail.Text + "', '" + textBoxadres.Text + "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                    commandDatabase.CommandTimeout = 120;
                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Hesap Başarıyla Oluşturuldu!");
                    this.Hide();
                    LoginForm form = new LoginForm();
                    form.ShowDialog();
                }
                connection.Close();
            }
        }
    }
}
