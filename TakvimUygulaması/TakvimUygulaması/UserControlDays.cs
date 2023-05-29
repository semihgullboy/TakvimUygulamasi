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
    public partial class UserControlDays : UserControl
    {
        String connString = "server=localhost; user id =root; database =takvimuygulamasi ; sslmode= none";
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            labeldays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = labeldays.Text;
            timer1.Start();
            OlayTanımlamaForm form = new OlayTanımlamaForm();
            form.Show();
        }

        public void displayEvent()
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "SELECT * FROM planliste where date = ?";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", TakvimForm.static_year + "-" + TakvimForm.static_month + "-" + labeldays.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label1.Text = reader["event"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }
    }
}
