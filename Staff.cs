using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCoffeeShop
{
    public partial class Staff : Form
    {
        DataSet dataSet;
        int month = 12;
        int day = 0;
        int startYear = 1900;
        int endYear = DateTime.Today.Year;
        public Staff()
        {
            InitializeComponent();
            ResizeForm();
            LoadDataSex();
            LoadDataStaff();

            LoadYear();
            LoadMotnh();
            SetDefaultDate();

            LoadDay();
            
            CreateControls();
        }

        public void ResizeForm()
        {
            Core.DefaultSize(this, 580, 490);
            foreach (ComboBox item in panel1.Controls.OfType<ComboBox>())
            {
                item.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public void SetDefaultDate()
        {
            cb_year.SelectedIndex = 0; 
            cb_month.SelectedIndex = 0;
        }

        public void LoadMotnh()
        {
            for (int i = 1; i <= month; i++)
            {
                cb_month.Items.Add(i);
            }
        }

        public void LoadYear()
        {
            for (int i = startYear; i <= endYear; i++)
            {
                cb_year.Items.Add(i);
            }
        }

        public void LoadDay()
        {
            day =DateTime.DaysInMonth(int.Parse(cb_year.Text), int.Parse(cb_month.Text));
            cb_day.Items.Clear();
            for (int i = 1; i <= day; i++)
            {
                cb_day.Items.Add(i);
            }
            cb_day.SelectedIndex = 0;
        }

        public void LoadDataSex()
        {
            dataSet = new DataSet();
            string sqlSelectSex = "select * from sex";
            Core.CheckConnecteClosed(User.conn);

            SqlCommand command = new SqlCommand(sqlSelectSex, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, "sex");

            cb_sex.DataSource = dataSet.Tables["sex"];
            cb_sex.DisplayMember = "sex_name";
            cb_sex.ValueMember = "id_sex";

            User.conn.Close();
        }

        public void LoadDataStaff()
        {
            dataSet = new DataSet();
            string sqlSelectSex = "select * from staff";
            Core.CheckConnecteClosed(User.conn);

            SqlCommand command = new SqlCommand(sqlSelectSex, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, "staff");

            cb_staff.DataSource = dataSet.Tables["staff"];
            cb_staff.DisplayMember = "staff_name";
            cb_staff.ValueMember = "id_staff";

            User.conn.Close();
        }

        public void CreateControls()
        {
            cb_year.SelectedValueChanged += (sender, e) =>
            {
                LoadDay();
            };

            cb_month.SelectedValueChanged += (sender, e) =>
            {
                LoadDay();
            };

            btn_insert.Click += (sender, e) =>
            {
                Core.CheckConnecteClosed(User.conn);
                if (!Core.CheckEmty(tb_staffName.Text))
                {
                    string sqlInserStaff = $"insert into staff values ('{Core.UniqueId(Core.convertToUnSign3(tb_staffName.Text))}',N'{tb_staffName.Text}','{cb_year.Text}-{cb_month.Text}-{cb_day.Text}','{cb_sex.GetItemText(cb_sex.SelectedValue)}')";

                    SqlCommand command = new SqlCommand(sqlInserStaff, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        Core.WarnningBox("Thêm nhân viên thành công");
                        LoadDataStaff();
                    }
                    catch (Exception ex)
                    {

                        Core.WarnningBox("Thêm nhân viên thất bại");
                    }
                }
                else
                {
                    Core.WarnningBox("Không được dể trống thông tin");
                }
                
               

                User.conn.Close();
            };

            btn_update.Click += (sender, e) => {
                DialogResult result = MessageBox.Show($"Bạn có muốn cập nhật Tên {cb_staff.GetItemText(cb_staff.SelectedValue)}","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result== DialogResult.Yes)
                {
                    if (!Core.CheckEmty(tb_staffName.Text))
                    {
                        string update = $"update staff set staff_name = N'{tb_staffName.Text}' where id_staff='{cb_staff.GetItemText(cb_staff.SelectedValue)}'";
                        Core.CheckConnecteClosed(User.conn);

                        SqlCommand command = new SqlCommand(update, User.conn);
                      
                        try
                        {
                            command.ExecuteNonQuery();
                            Core.WarnningBox("Cập nhật thành công");
                            LoadDataStaff();
                        }
                        catch (SqlException ex)
                        {
                            Core.WarnningBox("Cập nhật không thành công");
                        }

                        User.conn.Close();
                    }
                    else
                    {
                        Core.WarnningBox("Thông tin tên bị trống");
                    }
                }
                
            };

            btn_del.Click += (sender, e) =>
            {
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa nhân viên {cb_staff.GetItemText(cb_staff.SelectedValue)}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string delete = $"delete from staff where id_staff = '{cb_staff.GetItemText(cb_staff.SelectedValue)}'";
                    Core.CheckConnecteClosed(User.conn);

                    SqlCommand command = new SqlCommand(delete, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        LoadDataStaff();
                        Core.WarnningBox("Xóa thành công");
                    }
                    catch (Exception)
                    {
                        Core.WarnningBox("Xóa không thành công");
                    }
                    User.conn.Close();
                }
            };

            btn_home.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Home(), true);
            };
        }

    }
}

