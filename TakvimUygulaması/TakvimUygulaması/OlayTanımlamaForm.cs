using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace TakvimUygulaması
{
    public partial class OlayTanımlamaForm : Form
    {
        String connString = "server=localhost; user id =root; database =takvimuygulamasi ; sslmode= none";

        public OlayTanımlamaForm()
        {
            InitializeComponent();
        }

        private void OlayTanımlamaForm_Load(object sender, EventArgs e)
        {
            textDate.Text = TakvimForm.static_year + "/" + TakvimForm.static_month + "/" + UserControlDays.static_day;
            display();
        }

        private void display()
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "SELECT * FROM planliste where date = ?";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", textDate.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textsaat.Text = reader["saatbaslangic"].ToString();
                textsaatbitis.Text = reader["saatbitis"].ToString();
                textEvent.Text = reader["event"].ToString();
                texteventbilgi.Text = reader["eventbilgi"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            connection.Close();
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            String sql = "INSERT INTO planliste(date,saatbaslangic,saatbitis,event,eventbilgi) values(?,?,?,?,?)";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", textDate.Text);
            cmd.Parameters.AddWithValue("saatbaslangic", textsaat.Text);
            cmd.Parameters.AddWithValue("saatbitis", textsaatbitis.Text);
            cmd.Parameters.AddWithValue("event", textEvent.Text);
            cmd.Parameters.AddWithValue("eventbilgi", texteventbilgi.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kaydedildi!");
            cmd.Dispose();
            connection.Close();
            alarm();
        }

        private void buttongüncelle_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "UPDATE planliste SET  saatbaslangic= ? , saatbitis = ? ,event = ? , eventbilgi= ? where date ='" + textDate.Text.ToString() + "' ";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("saatbaslangic", textsaat.Text);
            cmd.Parameters.AddWithValue("saatbitis", textsaatbitis.Text);
            cmd.Parameters.AddWithValue("event", textEvent.Text);
            cmd.Parameters.AddWithValue("eventbilgi", texteventbilgi.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Güncellendi!");
            cmd.Dispose();
            connection.Close();
            alarm();
        }

        private void buttonsil_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "DELETE FROM planliste where event ='" + textEvent.Text.ToString() + "'";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete");
            cmd.Dispose();
            connection.Close();
            this.Hide();
            TakvimForm frm = new TakvimForm();
            frm.ShowDialog();
        }
        static void BildirimGonder(string baslik, string icerik)
        {
            NotifyIcon bildirim = new NotifyIcon();
            bildirim.Icon = SystemIcons.Exclamation;
            bildirim.Visible = true;
            bildirim.BalloonTipTitle = baslik;
            bildirim.BalloonTipText = icerik;
            bildirim.ShowBalloonTip(5000);
        }
        private void alarm()
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            String sql = "SELECT *FROM planliste";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> gunler = new List<string>();
            List<string> saatler = new List<string>();
            List<string> mesajlar = new List<string>();
            List<string> aciklamalar = new List<string>();
            while (reader.Read())
            {
                string data = reader.GetString(1);
                string saat = reader.GetString(2);
                string mesaj = reader.GetString(4);
                string aciklama = reader.GetString(5);
                gunler.Add(data);
                saatler.Add(saat);
                mesajlar.Add(mesaj);
                aciklamalar.Add(aciklama);
            }
            string[] gunlers = gunler.ToArray();
            string[] saatlers = saatler.ToArray();
            string[] mesajlars = mesajlar.ToArray();
            int boyut = saatlers.Length;
            reader.Close();
            connection.Close();
            DateTime dateTime = DateTime.Now;
            string datestr = dateTime.ToString("dd.MM.yyyy" + " 00:00:00");
            int[,] saatdakika = new int[boyut, 2];
            for (int i = 0; i < boyut; i++)
            {
                string[] timeParts = saatlers[i].Split(':');


                saatdakika[i, 0] = Convert.ToInt32(timeParts[0]);

                saatdakika[i, 1] = Convert.ToInt32(timeParts[1]);

            }
            for (int i = 0; i < gunlers.Length; i++)
            {
                if (datestr == gunlers[i])
                {

                    DateTime alarmZamani = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, saatdakika[i, 0], saatdakika[i, 1], 0);
                    TimeSpan kalanSure = alarmZamani - dateTime;
                    int kalanSureSaniye = (int)kalanSure.TotalSeconds;
                    // Geri sayım başlat
                    if (kalanSureSaniye > 0)
                    {
                        Thread.Sleep(kalanSureSaniye * 1000);
                        BildirimGonder("Alarm: " + mesajlars[i], "AÇIKLAMA: " + aciklamalar[i]);
                    }
                    else
                    {
                        MessageBox.Show("Bir sorun tespit edildi bir dakika beklemeniz rica ediliyor:");
                        continue;
                    }
                }
            }
        }


    }
}

