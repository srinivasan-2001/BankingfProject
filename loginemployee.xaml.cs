using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace entering_sheet
{
    /// <summary>
    /// Interaction logic for loginemployee.xaml
    /// </summary>
    public partial class loginemployee : Window
    {
        public static string empName;
        public loginemployee()
        {
            InitializeComponent();
        }

        private void btn_pushreg_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRegistration obj = new EmployeeRegistration();
            obj.Show();

        }

        private void btn_emplogin_Click(object sender, RoutedEventArgs e)
        {
           
            SqlConnection con = new SqlConnection(constring.strcon);
            SqlCommand cmd = new SqlCommand();
            string logqur = string.Format("select Name,empUserId,empPassword from empl_registration");
            SqlDataAdapter adp = new SqlDataAdapter(logqur, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            int chek = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (txt_empuid.Text == ds.Tables[0].Rows[i]["empUserId"].ToString() && txt_empwd.Password == ds.Tables[0].Rows[i]["empPassword"].ToString())
                {
                    chek = 1;
                    empName = ds.Tables[0].Rows[i]["Name"].ToString();
                }

            }
            if (chek == 1)
            {
                MessageBox.Show("Welcome" + " " + empName);
                employeehomepage obj = new employeehomepage();
                obj.lbl_showmyempname.Content = empName.ToString();
                obj.Show();
            }
            else
            {
                MessageBox.Show("invalid user id");
            }
            this.Hide();
        }
    }
}
