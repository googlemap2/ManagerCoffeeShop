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
    public partial class Product : Form
    {
        DataSet dataSet;
        public Product()
        {
            InitializeComponent();
            DefaultSize();
            LoadDataSize();
            LoadDataProduct();
            CreateEventControl();
        }

        public void DefaultSize()
        {
            Core.DefaultSize(this, 320, 320);
            foreach (ComboBox item in panel1.Controls.OfType<ComboBox>())
            {
                item.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            foreach (Button item in panel1.Controls.OfType<Button>())
            {
                item.Enabled = false;
            }

            btn_back.Enabled = true;

            foreach (TextBox item in panel1.Controls.OfType<TextBox>())
            {
                item.Enabled = false;
            }
            btn_delProduct.Enabled = true;

        }


        public void LoadDataSize()
        {
            dataSet = new DataSet();
            if (User.conn.State == ConnectionState.Closed)
            {
                User.conn.Open();
            }
            string sqlSelect = "select * from size_glass";
            SqlCommand cmd = new SqlCommand(sqlSelect, User.conn);
            SqlDataAdapter adapterSize = new SqlDataAdapter(cmd);
            adapterSize.Fill(dataSet, "size_glass");

            cb_size.DataSource = dataSet.Tables["size_glass"];
            cb_size.DisplayMember = "id_size_glass";

            User.conn.Close();

        }

        private void LoadDataProduct()
        {
            dataSet = new DataSet();
            cb_selectProduct.DataSource = null;
            cb_selectProduct.Items.Clear();


            if (User.conn.State == ConnectionState.Closed)
            {
                User.conn.Open();
            }
            if (!dataSet.Tables.Contains("product"))
            {
                string sqlSelect = "select * from product";
                SqlCommand cmd = new SqlCommand(sqlSelect, User.conn);
                SqlDataAdapter adapterSize = new SqlDataAdapter(cmd);
                adapterSize.Fill(dataSet, "product");

            }


            cb_selectProduct.DataSource = dataSet.Tables["product"];
            cb_selectProduct.DisplayMember = "product_name";
            cb_selectProduct.ValueMember = "id_product";


            User.conn.Close();
        }

        public void CreateEventControl()
        {
            string idProduct = "";
            btn_insertProduct.Click += (sender, e) =>
            {
                Core.CheckConnecteClosed(User.conn);
                if (tb_insertProduct.Enabled)
                {
                    if (!Core.CheckEmty(tb_insertProduct.Text))
                    {
                        idProduct = Core.UniqueId(Core.convertToUnSign3(tb_insertProduct.Text));
                        string sqlInsert1 = $"insert into product values ('{idProduct}',N'{tb_insertProduct.Text}')";
                        SqlCommand command = new SqlCommand(sqlInsert1, User.conn);
                        try
                        {
                            if (command.ExecuteNonQuery() > 0)
                            {
                                Core.WarnningBox("Thêm món thành công");
                                LoadDataProduct();
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                Core.WarnningBox("Món đã tồn tại");
                            }

                        }
                    }
                    else
                    {
                        Core.WarnningBox("Thông tin bị trống");
                    }

                }
                else
                {
                    if (!Core.CheckEmty(tb_sell.Text))
                    {
                        idProduct = cb_selectProduct.GetItemText(cb_selectProduct.SelectedValue);
                        string sqlInsert="";
                        try
                        {
                            if (string.IsNullOrWhiteSpace(tb_sale.Text))
                            {
                                sqlInsert = $"insert into menu values ('{"menu_" + idProduct + cb_size.Text}','{idProduct}','{cb_size.Text}',{0},{int.Parse(tb_sell.Text)})";
                            }
                            else
                            {
                                sqlInsert = $"insert into menu values ('{"menu_" + idProduct + cb_size.Text}','{idProduct}','{cb_size.Text}',{int.Parse(tb_sale.Text)},{int.Parse(tb_sell.Text)})";
                            }
                        }
                        catch (Exception)
                        {

                            Core.WarnningBox("Nhập sai kiểu dữ liệu");
                            return;
                        }
                        

                        SqlCommand command = new SqlCommand(sqlInsert, User.conn);
                        try
                        {
                            if (command.ExecuteNonQuery() > 0)
                            {
                                Core.WarnningBox("Thêm sản phẩm thành công");
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                Core.WarnningBox("Đã tồn tại sản phẩm");
                            }

                        };
                    }
                    else
                    {
                        Core.WarnningBox("Thông tin còn trống");
                    }

                }
                User.conn.Close();
            };

            btn_delProduct.Click += (sender, e) =>
            {
                Core.CheckConnecteClosed(User.conn);
                if (tb_insertProduct.Enabled)
                {
                    string sqlDelProduct = $"delete from product where id_product = '{cb_selectProduct.GetItemText(cb_selectProduct.SelectedValue)}'";
                    Core.CheckConnecteClosed(User.conn);
                    SqlCommand command = new SqlCommand(sqlDelProduct, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        Core.WarnningBox("Xóa thành công");
                        cb_selectProduct.Text = null;
                        LoadDataProduct();
                    }
                    catch (SqlException ex)
                    {

                        if (ex.Number == 547)
                        {
                            Core.WarnningBox("Xóa thất bại");
                        }
                    }
                }
                else
                {
                    string sqlInsert = $"delete from menu where id_size_glass='{cb_size.GetItemText(cb_size.SelectedValue)}' and id_product='{cb_selectProduct.GetItemText(cb_selectProduct.SelectedValue)}' ";
                    SqlCommand command = new SqlCommand(sqlInsert, User.conn);
                    try
                    {
                        if (command.ExecuteNonQuery() > 0)
                        {
                            Core.WarnningBox("Xóa món thành công");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Core.WarnningBox("Xóa thất bại");
                    };

                }
                User.conn.Close();
            };


            btn_back.Click += (sender, e) =>
                {
                    Core.ShowDesktop(this, new Home(), true);
                };

            toolstripbtn_Product.Click += (sender, e) =>
                    {
                        foreach (TextBox item in panel1.Controls.OfType<TextBox>())
                        {
                            item.Enabled = false;
                        }

                        tb_insertProduct.Enabled = true;

                        foreach (Button item in panel1.Controls.OfType<Button>())
                        {
                            item.Enabled = true;
                        }

                        btn_delProduct.Enabled = true;
                    };

            toolstripbtn_Menu.Click += (sender, e) =>
            {
                foreach (TextBox item in panel1.Controls.OfType<TextBox>())
                {
                    item.Enabled = true;
                }

                tb_insertProduct.Enabled = false;

                foreach (Button item in panel1.Controls.OfType<Button>())
                {
                    item.Enabled = true;
                }
            };
        }
    }
}
