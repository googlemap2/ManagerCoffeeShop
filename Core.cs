using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCoffeeShop
{
    class Core
    {
        public static Boolean CheckEmty(String @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
            {
                return true;
            }
            return false;
        }

        public static void WarnningBox(string error)
        {
            MessageBox.Show(error, "warnning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDesktop(Form formhide, Form formshow,bool hide)
        {
            if (hide)
            {
                formhide.Hide();
            }
            
            formshow.Show();
        }
        public static void DefaultSize(Form form, int Width, int Height)
        {
            form.Size = new Size(Width, Height);
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public static string UniqueId(string @string)
        {
            return string.Format($"{@string}_{Guid.NewGuid().ToString("N").Substring(0,5)}");
        }

        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ","");
        }

        public void ClearCombobox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
        }
        public static void CheckConnecteClosed(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
            {
                 conn.Open();
            }
        }
    }
}
