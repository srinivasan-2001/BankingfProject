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

namespace entering_sheet
{
    /// <summary>
    /// Interaction logic for EmployeeRegistration.xaml
    /// </summary>
    public partial class EmployeeRegistration : Window
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
        }

        private void btn_empregister_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection con = new SqlConnection(constring.strcon);
            SqlCommand cmd = new SqlCommand();
            string regQur = string.Format("insert into empl_registration(Name,PhoneNumber,empUserId,empPassword) values('{0}','{1}','{2}','{3}')", txt_empname.Text, txt_empphonenumber.Text, txt_emploginid.Text, txt_emppassword.Text);
            cmd.CommandText = regQur;
            cmd.Connection = con;
            con.Open();
            if (cmd.ExecuteNonQuery() != 0)
            {
                MessageBox.Show("New user resistered");
                loginemployee obj = new loginemployee();
                obj.lbl_pushreg.Visibility = Visibility.Hidden;
                obj.btn_pushreg.Visibility = Visibility.Hidden;
                obj.Show();
            }

            con.Close();
            con.Dispose();
            this.Hide();
        }
       
    }
}
