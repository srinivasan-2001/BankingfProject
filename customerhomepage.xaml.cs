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
using System.Data;
using System.Data.SqlClient;

namespace entering_sheet
{
    /// <summary>
    /// Interaction logic for customerhomepage.xaml
    /// </summary>
    public partial class customerhomepage : Window
    {
        public customerhomepage()
        {
            InitializeComponent();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Hide();
        }

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring.strcon);

           

            string query = string.Format("select Balance from tbl_custreg where AccountNum='{0}'  select * from tbl_loan where AccountNum='{0}'", logincustomer.AccountNum);

            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            
            DataSet ds = new DataSet();
            adp.Fill(ds);
            lbl_showBalance.Content = ds.Tables[0].Rows[0]["Balance"].ToString();
            if ((MessageBox.Show("Show loan", "comfirmation", MessageBoxButton.OKCancel, MessageBoxImage.Information)).ToString() == (MessageBoxButton.OK).ToString())
            {
                dtg_Mytrans.ItemsSource = ds.Tables[1].DefaultView;
            }



        }

        private void btn_transaction_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring.strcon);
            string regQur = string.Format("select TransactionNum,AccountNum,TranDate,Transferfrom,Amount,TranDC,Transfer_to from tbl_transaction Where AccountNum='{0}'", logincustomer.AccountNum);
            SqlDataAdapter adp = new SqlDataAdapter(regQur, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dtg_Mytrans.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            int chek = 0;
            SqlConnection con = new SqlConnection(constring.strcon);
            string regqur = string.Format("select AccountNum from tbl_custreg where Accountnum='{0}'", txt_recustAccnum.Text);
            SqlDataAdapter adp = new SqlDataAdapter(regqur, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                if(txt_recustAccnum.Text== (ds.Tables[0].Rows[i]["AccountNum"]).ToString())
                {
                     chek = 1;
                    txt_mpin.Visibility = Visibility.Visible;
                    btn_confirm.Visibility = Visibility.Visible;
                }
               
            }
            if(chek==1)
            {
                MessageBox.Show("Account is preset \n Please enter Your MPIN");
            }
            else
            {
                
                txt_mpin.Visibility = Visibility.Hidden;
                btn_confirm.Visibility = Visibility.Hidden;
                MessageBox.Show("Invalid Account");
            }
            

        }

        private void btn_confirm_Click(object sender, RoutedEventArgs e)
        {
            float senderamount ;
            SqlConnection con = new SqlConnection(constring.strcon);
            string regqur = string.Format("select MPIN from tbl_custreg where Accountnum='{0}'", logincustomer.AccountNum);
            SqlDataAdapter adp = new SqlDataAdapter(regqur, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            senderamount = float.Parse(txt_sendamount.Text);

            if (txt_mpin.Password == (ds.Tables[0].Rows[0]["MPIN"]).ToString())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string regQur = string.Format("Select Balance from tbl_custreg where AccountNum='{0}'", logincustomer.AccountNum);
                cmd.Connection = con;
                cmd.CommandText = regQur;
                double bal =(double) cmd.ExecuteScalar();
                if (bal < float.Parse(txt_sendamount.Text))
                {
                    MessageBox.Show("Insufficient Balance");
                }
                else
                {
                    CusTransaction.transaction(logincustomer.AccountNum, txt_recustAccnum.Text, senderamount);
                }
                   
                MessageBox.Show("Transaction is completed");

            }
            else
            {
                MessageBox.Show("Incorrect MPIN");
            }
        }
    }                                                   
}
