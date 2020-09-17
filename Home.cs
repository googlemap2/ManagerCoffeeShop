using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCoffeeShop
{
    public partial class Home : Form
    {
        string date = "";
        float billSum = 0;
        DataSet dataSet;
        public Home()
        {
            InitializeComponent();
            ResizeForm();
            LoadProduct();
            LoadListMenu();
            LoadData();
            ViewListView();
            CreateEventControl();
        }

        public void ResizeForm()
        {

            Core.DefaultSize(this, 1061, 751);

            tb_bill.Enabled = false;

            btn_insertProductHome.Visible = true;
            btn_exportWareHouse.Visible = true;
            btn_importWareHouse.Visible = true;
            btn_formMaterial.Visible = true;
            btn_signup.Visible = true;
            btn_staff.Visible = true;

            


            cb_productMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_sizeHome.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LoadProduct()
        {
            dataSet = new DataSet();

            Core.CheckConnecteClosed(User.conn);
            string select = "select * from product";

            SqlCommand command = new SqlCommand(select, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, "product");

            cb_productMenu.DataSource = dataSet.Tables["product"];
            cb_productMenu.DisplayMember = "product_name";
            cb_productMenu.ValueMember = "id_product";

            User.conn.Close();
        }

        public void LoadData()
        {
            cb_productMenu.SelectedValueChanged += (sender, e) =>
            {
                string nowProduct = cb_productMenu.GetItemText(cb_productMenu.SelectedValue);
                cb_sizeHome.Items.Clear();
                Core.CheckConnecteClosed(User.conn);
                string sqlSelect = $"select id_size_glass from menu inner join product on menu.id_product=product.id_product where product.id_product like N'{nowProduct}'";
                SqlCommand cmd = new SqlCommand(sqlSelect, User.conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cb_sizeHome.Items.Add(reader["id_size_glass"]);
                    }

                }
                User.conn.Close();

            };


            lb_product.MouseDoubleClick += (sender, e) =>
            {
                var a = (ListBox)sender;
                cb_productMenu.Text = a.GetItemText(a.SelectedItem);
            };
        }

        public void LoadListMenu()
        {
            Core.CheckConnecteClosed(User.conn);

            string select = "select * from product";
            SqlCommand command = new SqlCommand(select,User.conn);
            using (SqlDataReader reader=command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lb_product.Items.Add(reader[1].ToString());
                }
            }

            User.conn.Close();
        }

        public void ViewListView()
        {

            lv_menu.View = View.Details;
            //Create Header Table
            lv_menu.Columns.Add("Món");
            lv_menu.Columns.Add("Số Lượng");
            lv_menu.Columns.Add("Size");
            lv_menu.Columns.Add("Ngày");
            lv_menu.Columns.Add("Giá");
            lv_menu.Columns.Add("Thành Tiền");
            foreach (ColumnHeader column in lv_menu.Columns)
            {
                column.Width = lv_menu.Width / lv_menu.Columns.Count;
            }

        }

        public string GetIDMenu(string id_product, string id_size_glass)
        {
            string id = "";
            string select = $"select id_menu from menu where id_product='{id_product}' and id_size_glass ='{id_size_glass}'";

            SqlCommand command = new SqlCommand(select, User.conn);
            id = command.ExecuteScalar().ToString();

            return id;
        }
        
        public string GetPriceMenu(string id_product, string id_size_glass)
        {
            string price = "";
            string select = $"select price from menu,product where menu.id_product=product.id_product  and product.id_product='{id_product}' and id_size_glass ='{id_size_glass}'";

            SqlCommand command = new SqlCommand(select, User.conn);

            price = command.ExecuteScalar().ToString();

            return price;
        }

        public string GetStaff(string id_user)
        {
            string staff = "";
            string select = $"select * from staff_info  where id_user = '{id_user}'";

            SqlCommand command = new SqlCommand(select, User.conn);

            staff = command.ExecuteScalar().ToString();

            return staff;
        }

        public void CreateEventControl()
        {
            btn_insertProductHome.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Product(), true);
            };

            btn_exportBill.Click += (sender, e) =>
            {
                if (lv_menu.Items.Count > 0)
                {
                    float sum = 0;
                    foreach (ListViewItem item in lv_menu.Items)
                    {
                        sum += float.Parse(item.SubItems[5].Text);
                    }
                    textBox1.Text = sum.ToString();

                    using (var sw = new System.IO.StreamWriter(@"F:\DoAnNet\ManagerCoffeeShop\Data\bill\bil.txt"))
                    {
                        sw.WriteLine("Hóa Đơn");
                        sw.WriteLine("Ngày: {0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        foreach (ListViewItem item in lv_menu.Items)
                        {
                            sw.WriteLine($"{item.SubItems[0].Text},{item.SubItems[1].Text},{item.SubItems[2].Text},{item.SubItems[3].Text},{item.SubItems[4].Text},{item.SubItems[5].Text}");
                        }
                        sw.WriteLine("Tổng tiền: " + textBox1.Text);
                    }

                    Core.WarnningBox("Tạo bil thành công");
                    tb_amount.Text = "";
                    tb_bill.Text = "";
                    textBox1.Text = "";
                    lv_menu.Items.Clear();
                }
                else
                {
                    Core.WarnningBox("Chưa có sản phẩm nào được bán");
                }
                
               
            };

            cb_sizeHome.TextChanged += (sender, e) =>
            {
                Core.CheckConnecteClosed(User.conn);
                string selectPrice = $"select price from menu where  id_product='{cb_productMenu.GetItemText(cb_productMenu.SelectedValue)}' and id_size_glass ='{cb_sizeHome.Text}'";
                SqlCommand command = new SqlCommand(selectPrice, User.conn);
                try
                {
                    command.ExecuteNonQuery();
                    tb_bill.Text = command.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {

                    Core.WarnningBox("Đặt món thất bại");
                }
                User.conn.Close();
            };

            btn_insertProduct.Click += (sender, e) =>
            {
                Core.CheckConnecteClosed(User.conn);
                if (!Core.CheckEmty(tb_amount.Text) && !Core.CheckEmty(cb_sizeHome.Text) && !Core.CheckEmty(cb_productMenu.Text))
                {
                    float price = 0;
                      date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:FFF");
                    try
                    {
                        price = float.Parse(tb_amount.Text) * float.Parse(GetPriceMenu(cb_productMenu.GetItemText(cb_productMenu.SelectedValue), cb_sizeHome.Text));
                    }
                    catch (Exception)
                    {

                        Core.WarnningBox("Số lượng phải là kiểu số");
                        return;
                    }
                    
                    string insert = $"insert into bill_detail values('{GetStaff(User.id_user)}', '{GetIDMenu(cb_productMenu.GetItemText(cb_productMenu.SelectedValue), cb_sizeHome.Text)}',{int.Parse(tb_amount.Text)},'{date}',{price})";
                    SqlCommand command = new SqlCommand(insert, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        ListViewItem item = new ListViewItem(new[] { cb_productMenu.Text, tb_amount.Text, cb_sizeHome.Text, date, tb_bill.Text,price.ToString() });
                        lv_menu.Items.Add(item);
                        float sum = 0;

                        foreach (ListViewItem item1 in lv_menu.Items)
                        {
                            sum += float.Parse(item1.SubItems[5].Text);
                        }
                        textBox1.Text = sum.ToString();
                    }
                    catch (Exception ex)
                    {

                        Core.WarnningBox("Đặt món thất bại");
                    }
                }

                User.conn.Close();
            };
            btn_billDel.Click += (sender, e) =>
            {
                if (lv_menu.SelectedItems.Count==0)
                {
                    return;
                }
                ListViewItem item = lv_menu.SelectedItems[0];
                /*Core.WarnningBox(item.SubItems[3].Text);*/

                Core.CheckConnecteClosed(User.conn);
                string sqlSelect = $"delete from bill_detail where date_export='{item.SubItems[3].Text}'";
                SqlCommand command = new SqlCommand(sqlSelect,User.conn);
                try
                {
                    command.ExecuteNonQuery();
                    item.Remove();
                }
                catch (Exception ex)
                {

                    Core.WarnningBox("Xóa không thành công");
                }

                User.conn.Close();
            };


            btn_exportWareHouse.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new ManagerWareHouse(), true);
            };

            btn_importWareHouse.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Supplier(), true);
            };

            btn_formMaterial.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Material(), true);
            };

            btn_signup.Click += (sender, e) =>
            {
                User.id_user = null;
                User.conn = null;
                Core.ShowDesktop(this, new Login(), true);
            };

            btn_staff.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Staff(), true);
            };

            btn_statistics.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Statistics(), true);
            };
        }
    }
}
