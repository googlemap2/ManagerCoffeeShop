using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ManagerCoffeeShop
{
    class Permission
    {
        private string permissions;

        public Permission(string permissions)
        {
            this.permissions = permissions;
        }

        public string Permissions { get => permissions; set => permissions = value; }

        public Boolean Connect(out SqlConnection connection)
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-OMCNFL0 ;Initial Catalog=DB_ManagerCoffeeShop;Persist Security Info=True;User ID=sa;Password=123");

            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public void ExcuteConnect(Permission permission,SqlConnection conn,Form form ,string pass,string user)
        {
            if (permission.Connect(out conn))
            {
                conn.Open();
                string login = $"LoginUser @username , @password";
                SqlCommand command = new SqlCommand(login, conn);
                command.Parameters.AddWithValue("@username", user);
                command.Parameters.AddWithValue("@password", pass);

                int row= (int)command.ExecuteScalar();

                conn.Close();
                if (row>0)
                {
                    Core.WarnningBox($"{user} Đăng nhập thành công");
                    Core.ShowDesktop(form, new Home(), true);

                }
                else
                {
                    Core.WarnningBox("Đăng nhập không thành công");
                }

            }
            else
            {
                Core.WarnningBox("Lỗi kết nối");
            }

        }
    }
}
