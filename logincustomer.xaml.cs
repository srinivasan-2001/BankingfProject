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
    /// Interaction logic for logincustomer.xaml
    /// </summary>
    public partial class logincustomer : Window
    {
        public static string cusName;
        public static string AccountNum;
       
        public logincustomer()
        {
            InitializeComponent();
        }

        private void btn_pushregc_Click(object sender, RoutedEventArgs e)
        {
            cusregitration obj = new cusregitration();
            obj.Show();
        }

        private void btn_cuslogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring.strcon);
            string query ="select Name,AccountNum,UserId,Password from tbl_custreg";
            SqlDataAdapter adp=new SqlDataAdapter(query,con);
            DataSet ds=new DataSet();
            adp.Fill(ds);
            int check = 0;
            for(int i = 0; i < ds.Tables[0].Rows.Count;i++)
            {
                if (txt_cusuid.Text == (ds.Tables[0].Rows[i]["UserId"]).ToString() && txt_cuspwd.Password == (ds.Tables[0].Rows[i]["Password"]).ToString())
                {
                    check = 1;
                    MessageBox.Show("Login Successfull");
                    cusName= ds.Tables[0].Rows[i]["Name"].ToString();
                    AccountNum = ds.Tables[0].Rows[i]["AccountNum"].ToString();
                  
                }
            }
            if(check == 1)
            {
                MessageBox.Show("Welcome" + " " + cusName);
                customerhomepage obj = new customerhomepage();
                obj.lbl_showmyname.Content = cusName.ToString();
                obj.lbl_showaccno.Content = AccountNum.ToString();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username/Password");
                txt_cusuid.Text = "";
                txt_cuspwd.Password = "";
            }



        }
    }
}
