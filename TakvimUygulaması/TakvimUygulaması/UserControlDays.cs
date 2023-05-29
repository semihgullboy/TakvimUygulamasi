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

        private void timer1_Tick(object sender, EventArgs e)
        {
    
        }
    }
}
