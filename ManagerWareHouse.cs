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
    public partial class ManagerWareHouse : Form
    {
        DataSet dataSet;
        SqlDataAdapter bill_import;
        public ManagerWareHouse()
        {
            InitializeComponent();
            ResizeForm();
            LoadTableWareHouse();
            LoadDataUnit();
            LoadDataSupplier();
            LoadDataMaterial();
            CreateController();
        }
        public void ResizeForm()
        {
            Core.DefaultSize(this, 780, 510);
            foreach (ComboBox item in this.Controls.OfType<ComboBox>())
            {
                item.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void LoadTableWareHouse()
        { dataSet = new DataSet();
            Core.CheckConnecteClosed(User.conn);
            string select = "select * from bill_import";
            SqlDataAdapter bill_import = new SqlDataAdapter(select,User.conn);
            bill_import.Fill(dataSet, "bill_import");

            dataGridView1.DataSource = dataSet.Tables["bill_import"];

            User.conn.Close();
        }

        public void LoadDataUnit()
        {
            dataSet = new DataSet();
            Core.CheckConnecteClosed(User.conn);
            string sqlSelectUnit = "select * from unit";
            SqlCommand command = new SqlCommand(sqlSelectUnit, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, "unit");

            cb_unit.DataSource = dataSet.Tables["unit"];
            cb_unit.DisplayMember = "unit_name"; 
            cb_unit.ValueMember = "id_unit";

            User.conn.Close();
        }

        public void LoadDataSupplier()
        {
            dataSet = new DataSet();
            Core.CheckConnecteClosed(User.conn);
            string sqlSelectUnit = "select * from supplier";
            SqlCommand command = new SqlCommand(sqlSelectUnit, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, "supplier");

            cb_suppliers.DataSource = dataSet.Tables["supplier"];
            cb_suppliers.DisplayMember = "supplier";
            cb_suppliers.ValueMember = "id_supplier";

            User.conn.Close();
        }

        public void LoadDataMaterial()
        {
            dataSet = new DataSet();
            Core.CheckConnecteClosed(User.conn);
            string sqlSelectUnit = "select * from material";
            SqlCommand command = new SqlCommand(sqlSelectUnit, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, "material");

            cb_material.DataSource = dataSet.Tables["material"];
            cb_material.DisplayMember = "material_name";
            cb_material.ValueMember = "id_material";

            User.conn.Close();
        }

        public void CreateController()
        {
            btn_back.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Home(), true);
            };

            btn_import.Click += (sender, e) =>
            {
                string sqlInsert = "";
                try
                {
                    sqlInsert = $"insert into bill_import values ('{User.id_user}','{cb_suppliers.GetItemText(cb_suppliers.SelectedValue)}','{cb_material.GetItemText(cb_material.SelectedValue)}','{cb_unit.GetItemText(cb_unit.SelectedValue)}','{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:FFF")}',{int.Parse(tb_amount.Text)},{int.Parse(tb_prices.Text)})";
                }
                catch (Exception)
                {

                    Core.WarnningBox("Nhập đúng định dạng dữ liệu");
                    return;
                }
                
                Core.CheckConnecteClosed(User.conn);
                if (!Core.CheckEmty(tb_amount.Text) && !Core.CheckEmty(tb_prices.Text))
                {
                    SqlCommand command = new SqlCommand(sqlInsert, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        Core.WarnningBox("Nhập thành công");
                        LoadTableWareHouse();
                    }
                    catch (Exception)
                    {

                        Core.WarnningBox("Nhập thất bại");
                    }
                   
                }
                else
                {
                    Core.WarnningBox("Không được để trống thông tin");
                }
                User.conn.Close();
            };
        }

    }
}
