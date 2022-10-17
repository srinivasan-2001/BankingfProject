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
    /// Interaction logic for cusregitration.xaml
    /// </summary>
    public partial class cusregitration : Window
    {
        public cusregitration()
        {
            InitializeComponent();
        }

        private void btn_cusreg_Click(object sender, RoutedEventArgs e)
        {
            string query;
            SqlConnection con = new SqlConnection(constring.strcon);
            con.Open();

            if (rdo_savingacc.IsChecked == true)
            {
                query = string.Format("insert into tbl_custreg (Name,PhoneNum,AccountNum,DOB,PanNum,Gender,SelectAcc,MPIN,UserId,Password,Balance) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',0)", txy_cusname.Text, txt_cusphonenumber.Text, txt_acountnumber.Text, dt_dob.Text, txy_pannuber.Text, txt_gender.Text, rdo_savingacc.Content.ToString(), txy_mpin.Text, txt_cususerid.Text, txt_cuspassword.Text);

                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Registered Successfully");
                }
            }
            else if (rdo_currentacc.IsChecked == true)
            {
                query = string.Format("insert into tbl_custreg (Name,PhoneNum,AccountNum,DOB,PanNum,Gender,SelectAcc,MPIN,UserId,Password) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", txy_cusname.Text, txt_cusphonenumber.Text, txt_acountnumber.Text, dt_dob.Text, txy_pannuber.Text,txt_gender.Text, rdo_currentacc.Content.ToString(), txy_mpin.Text, txt_cususerid.Text, txt_cuspassword.Text);

                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Registered Successfully");
                }
            }

            con.Close();
            logincustomer obj = new logincustomer();
            obj.lbl_pushregc.Visibility = Visibility.Hidden;
            obj.btn_pushregc.Visibility = Visibility.Hidden;
            obj.Show();
            this.Hide();
        }
    }
}

