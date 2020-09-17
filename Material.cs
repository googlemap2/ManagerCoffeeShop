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
    public partial class Material : Form
    {
        DataSet dataSet;
        public Material()
        {
            InitializeComponent();
            ResizeForm();
            LoadDataSupplier();
            CreateController();
        }
        public void ResizeForm()
        {
            Core.DefaultSize(this, 570, 350);
            foreach (ComboBox item in this.Controls.OfType<ComboBox>())
            {
                item.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            cb_material.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LoadDataSupplier()
        {
            dataSet = new DataSet();
            string sqlSelectMaterial = "select * from material";
            Core.CheckConnecteClosed(User.conn);
            SqlCommand command = new SqlCommand(sqlSelectMaterial, User.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet, "material");

            cb_material.DataSource = dataSet.Tables["material"];
            cb_material.DisplayMember = "material_name";
            cb_material.ValueMember = "id_material";

            User.conn.Close();
        }

        public void CreateController()
        {
            btn_home.Click += (sender, e) =>
            {
                Core.ShowDesktop(this, new Home(), true);
            };

            btn_insert.Click += (sender, e) =>
            {
                Core.CheckConnecteClosed(User.conn);
                if (!Core.CheckEmty(tb_material.Text))
                {
                    string sqlInsertMaterial = $"insert into material values ('{ Core.UniqueId(Core.convertToUnSign3(tb_material.Text))}',N'{tb_material.Text}')";
                    SqlCommand command = new SqlCommand(sqlInsertMaterial, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        Core.WarnningBox("Thêm vật liệu thành công");
                        LoadDataSupplier();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            Core.WarnningBox("Vật liệu Đã tồn tại");
                        }

                    }
                }
                else
                {

                    Core.WarnningBox("Không được để trống thông tin");
                }
                User.conn.Close();
            };

            btn_del.Click += (sender, e) =>
            {
                Core.CheckConnecteClosed(User.conn);

                    string sqlInsertMaterial = $"delete from material where id_material='{cb_material.GetItemText(cb_material.SelectedValue)}'";
                    SqlCommand command = new SqlCommand(sqlInsertMaterial, User.conn);
                    try
                    {
                        command.ExecuteNonQuery();
                        Core.WarnningBox("Xóa vật liệu thành công");
                        LoadDataSupplier();
                        cb_material.Text = null;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                        {
                            Core.WarnningBox("Xóa thất bại");
                        }

                    }
               
                User.conn.Close();
            };
        }
    }
}
