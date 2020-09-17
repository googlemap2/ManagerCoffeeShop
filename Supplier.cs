using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCoffeeShop
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
            ResizeForm();
            LoadDataSupplier();
            CreateEventControl();
        }

        public void ResizeForm()
        {
            Core.DefaultSize(this, 490, 315);
            cb_supplier.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadDataSupplier()
        {
            DataSet dataSet = new DataSet();
            string selectSupplier = "select * from supplier";
            Core.CheckConnecteClosed(User.conn);
            SqlCommand command = new SqlCommand(selectSupplier, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill( dataSet,"supplier");

            cb_supplier.DataSource = dataSet.Tables["supplier"];
            cb_supplier.DisplayMember = "supplier";
            cb_supplier.ValueMember = "id_supplier";


        }

        public void CreateEventControl()
        {
            btn_back.Click += (sender,e) =>
            {
                Core.ShowDesktop(this, new Home(), true);
            };
            btn_insert.Click += (sender, e) =>
            {
                if (!Core.CheckEmty(tb_insertSupplier.Text))
                {
                    string insertSupplier = $"insert into supplier values ('{Core.UniqueId(Core.convertToUnSign3(tb_insertSupplier.Text)).Substring(10)}',N'{tb_insertSupplier.Text}')";
                    Core.CheckConnecteClosed(User.conn);
                    SqlCommand command = new SqlCommand(insertSupplier, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        Core.WarnningBox("Thêm nhà cung cấp thành công");
                        LoadDataSupplier();

                    }
                    catch (SqlException ex )
                    {

                        if (ex.Number == 2627)
                        {
                            Core.WarnningBox("Đã tồn tại nhà cung cấp");
                        }
                    }
                }
                else
                {
                    Core.WarnningBox("Không được để trống thông tin");
                }
            };

            btn_del.Click += (sender, e) =>
            {
                string insertSupplier = $"delete from supplier where id_supplier='{cb_supplier.GetItemText(cb_supplier.SelectedValue)}'";
                Core.CheckConnecteClosed(User.conn);
                SqlCommand command = new SqlCommand(insertSupplier, User.conn);
                try
                {
                    command.ExecuteNonQuery();
                    Core.WarnningBox("Xóa thành công");
                    cb_supplier.Text=null;
                    LoadDataSupplier();
                }
                catch (SqlException ex)
                {

                    if (ex.Number == 547)
                    {
                        Core.WarnningBox("Xóa thất bại");
                    }
                }
            
            };

            btn_update.Click += (sender, e) => {
                if (!Core.CheckEmty(tb_insertSupplier.Text) && !Core.CheckEmty(cb_supplier.Text))
                {
                    string insertSupplier = $"update supplier set supplier ='{tb_insertSupplier.Text}' where id_supplier ='{cb_supplier.GetItemText(cb_supplier.SelectedValue)}'";
                    Core.CheckConnecteClosed(User.conn);
                    SqlCommand command = new SqlCommand(insertSupplier, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        Core.WarnningBox("Cập nhật thành công");
                        LoadDataSupplier();

                    }
                    catch (SqlException ex)
                    {

                        if (ex.Number == 2627)
                        {
                            Core.WarnningBox("Đã tồn tại nhà cung cấp");
                        }
                    }
                }
                else
                {
                    Core.WarnningBox("Không được để trống thông tin");
                }
            };
        }

 
    }
}
