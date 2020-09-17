using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ManagerCoffeeShop
{
    public partial class Statistics : Form
    {
        int month = 12;
        int startYear = 2000;
        int endYear = DateTime.Today.Year;
        public Statistics()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadYear();
            LoadMotnh();

            cb_monthStart.SelectedIndex = 0;
            cb_yearStart.SelectedIndex = 0;

            cb_endMonth.SelectedIndex = 0;
            cb_endYear.SelectedIndex = 0;

            CreateController();
            LoadDay(cb_dayStart, DateTime.DaysInMonth( int.Parse(cb_yearStart.Text),int.Parse(cb_monthStart.Text)));
            LoadDay(cb_endDay, DateTime.DaysInMonth(int.Parse(cb_endYear.Text),int.Parse(cb_endMonth.Text)));

            cb_dayStart.SelectedIndex = 0;
           
            cb_endDay.SelectedIndex = 0;

        }

        public void ResizeForm()
        {

            Core.DefaultSize(this, 980, 730);
        }
        public void LoadMotnh()
        {
            for (int i = 1; i <= month; i++)
            {
                cb_monthStart.Items.Add(i);
                cb_endMonth.Items.Add(i);
            }
        }

        public void LoadYear()
        {
            for (int i = startYear; i <= endYear; i++)
            {
                cb_yearStart.Items.Add(i);
                cb_endYear.Items.Add(i);
            }
        }

        public void LoadDay(ComboBox cb,int day)
        {
            for (int i = 1; i <= day; i++)
            {
                cb.Items.Add(i);
            }
        }

        public void FillData(string start, string end)
        {
            DataSet dataSet = new DataSet();

            Core.CheckConnecteClosed(User.conn);

            string select = $"select product.product_name,id_size_glass, SUM(amount) as 'Số lượng',SUM(bill) as 'Tổng tiền' from bill_detail,product,menu where bill_detail.id_menu=menu.id_menu and menu.id_product=product.id_product  and date_export between '{start}' and '{end}' group by product.product_name,id_size_glass";

            SqlDataAdapter adapter = new SqlDataAdapter(select, User.conn);
            adapter.Fill(dataSet, "statistic");

            dataGridView1.DataSource = dataSet.Tables["statistic"];


            User.conn.Close();
        }

        public void CreateController()
        {
            btn_statistic.Click += (sender, e) =>
            {
                string day = DateTime.DaysInMonth(int.Parse(cb_yearStart.Text), int.Parse(cb_monthStart.Text)).ToString();
                string start = $"{cb_yearStart.Text}/{cb_monthStart.Text}/{cb_dayStart.Text}";
                string end = $"{cb_endYear.Text}/{cb_endMonth.Text}/{cb_endDay.Text}";
                try
                {
                    FillData(start, end);
                }
                catch (Exception ex)
                {

                    Core.WarnningBox("Thống kê thất bại");
                }
              
            };

            btn_home.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Home(), true);
            };

            cb_yearStart.TextChanged += (sender, e) =>
            {
                cb_dayStart.Items.Clear();
                LoadDay(cb_dayStart, DateTime.DaysInMonth( int.Parse(cb_yearStart.Text),int.Parse(cb_monthStart.Text)));
            };

            cb_endYear.TextChanged += (sender, e) =>
            {
                cb_endDay.Items.Clear();
                LoadDay(cb_endDay, DateTime.DaysInMonth(int.Parse(cb_endYear.Text),int.Parse(cb_endMonth.Text)));
            };


            cb_monthStart.TextChanged += (sender, e) =>
            {
                cb_dayStart.Items.Clear();
                LoadDay(cb_dayStart, DateTime.DaysInMonth(int.Parse(cb_yearStart.Text), int.Parse(cb_monthStart.Text)));
            };

            cb_endMonth.TextChanged += (sender, e) =>
            {
                cb_endDay.Items.Clear();
                LoadDay(cb_endDay, DateTime.DaysInMonth(int.Parse(cb_endYear.Text), int.Parse(cb_endMonth.Text)));
            };
        }
    }
}
