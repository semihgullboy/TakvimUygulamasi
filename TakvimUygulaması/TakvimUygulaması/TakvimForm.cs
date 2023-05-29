using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakvimUygulaması
{
    public partial class TakvimForm : Form
    {
        int month, year, day;
        public static int static_month, static_year, static_day;


        public TakvimForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void TakvimForm_Load(object sender, EventArgs e)
        {
            displaDays();
        }

        private void displaDays()
        {
            DateTime now = DateTime.Now;
            day = now.Day;
            month = now.Month;
            year = now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labeldate.Text = monthname + " " + year;

            static_day = day;
            static_month = month;
            static_year = year;

     
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

        
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                flowLayoutPanel1.Controls.Add(ucblank);
            }
            
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                flowLayoutPanel1.Controls.Add(ucdays);
            }
        }

        private void buttonprevious_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();

            DateTime now = DateTime.Now;
            month--;
            static_month = month;
            static_year = year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labeldate.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                flowLayoutPanel1.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                flowLayoutPanel1.Controls.Add(ucdays);
            }
        }

        private void buttonnext_Click(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.Controls.Clear();
            DateTime now = DateTime.Now;
            month++;
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labeldate.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                flowLayoutPanel1.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                flowLayoutPanel1.Controls.Add(ucdays);
            }
        }

        private void buttoncıkısyap_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm3 = new LoginForm();
            frm3.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
