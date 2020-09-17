using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ManagerCoffeeShop
{
    public partial class Login : Form
    {
        SqlConnection conn ;
        Permission permission;

        public Login()
        {
            InitializeComponent();
            ResizeForm();
            ControlEvent();
        }

        public void ResizeForm()
        {
            Core.DefaultSize(this, 575, 300);
        }

        public void ControlEvent()
        {
            btn_login.Click += (sender, e) =>
            {
                if (!Core.CheckEmty(tb_idUser.Text) && !Core.CheckEmty(tb_passowrd.Text))
                {
                   var permission = new Permission(tb_idUser.Text);
                    if (permission.Connect(out conn))
                    {
                        User.id_user = tb_idUser.Text;
                        User.conn = conn;
                        permission.ExcuteConnect(permission, conn,this, tb_passowrd.Text,User.id_user);
                    }
                    else
                    {
                        Core.WarnningBox("Đăng nhập không thành công");
                    }
                }

                else
                {
                    Core.WarnningBox("Không được để trống thông tin");
                }

            };

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.KeyDown += (sender, e) =>
                    {
                        if (e.KeyCode.Equals(Keys.Enter))
                        {
                            e.SuppressKeyPress = true;
                        }
                    };
                }
              
            }

            this.FormClosing += (sener, e) =>
            {
                if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình","Warnning",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!=DialogResult.OK)
                {
                    e.Cancel = true;
                }
            };
        }

    }
}
