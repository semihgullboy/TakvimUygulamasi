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
    }
}
