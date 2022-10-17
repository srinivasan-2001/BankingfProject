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
    /// Interaction logic for employeehomepage.xaml
    /// </summary>
    public partial class employeehomepage : Window
    {
        public employeehomepage()
        {
            InitializeComponent();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Hide();
            
        }

        private void btn_details_Click(object sender, RoutedEventArgs e)
        {
            dtg_showdetails.Visibility = Visibility.Visible;
            btn_showtrans.Visibility = Visibility.Visible;
           
            SqlConnection con = new SqlConnection(constring.strcon);
            
            string regQur = string.Format("select Name,PhoneNum,DOB,PanNum,Gender,SelectAcc,Balance from tbl_custreg Where AccountNum='{0}'", txt_custAccountnum.Text);
            SqlDataAdapter adp = new SqlDataAdapter(regQur,con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dtg_showdetails.ItemsSource = ds.Tables[0].DefaultView;
            if(ds.Tables[0].Rows.Count==0)
            {
                MessageBox.Show("Invalid account number");
            }

            
           
        }

        private void btn_deposit_Click(object sender, RoutedEventArgs e)
        {
            dtg_cusshowtrans.Visibility = Visibility.Visible;
            SqlConnection con = new SqlConnection(constring.strcon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd1.Connection = con;
            SqlTransaction tran= con.BeginTransaction();
             string regQur = string.Format("insert into tbl_transaction(AccountNum,TranDate,Transferfrom,Amount,TranType,TranDC,Transfer_to) values('{0}',GETDATE(),'Bank',{1},1,'Credited','0')", txt_custAccountnum.Text, txt_deposit.Text);
            cmd.CommandText = regQur;
            cmd.Transaction = tran;
            cmd.ExecuteNonQuery();
            String reqBalace = string.Format("Update tbl_custreg set Balance=Balance+{0} where AccountNum='{1}'", txt_deposit.Text, txt_custAccountnum.Text);
            cmd1.CommandText = reqBalace;
            cmd1.Transaction = tran;
            cmd1.ExecuteNonQuery();
            tran.Commit();
            con.Close();
          
           
            MessageBox.Show("Deposited successfully");



        }

        private void btn_widraw_Click(object sender, RoutedEventArgs e)
        {
            dtg_cusshowtrans.Visibility = Visibility.Visible;
            SqlConnection con = new SqlConnection(constring.strcon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd1.Connection = con;
            SqlTransaction tran = con.BeginTransaction();
            string regQur = string.Format("insert into tbl_transaction(AccountNum,TranDate,Transferfrom,Amount,TranType,TranDC,Transfer_to) values('{0}',GETDATE(),'Bank',{1},2,'Debited','0')", txt_custAccountnum.Text, txt_deposit.Text);
            cmd.CommandText = regQur;
            cmd.Transaction = tran;
            cmd.ExecuteNonQuery();
            String reqBalace = string.Format("Update tbl_custreg set Balance=Balance-{0} where AccountNum='{1}'", txt_deposit.Text, txt_custAccountnum.Text);
            cmd1.CommandText = reqBalace;
            cmd1.Transaction = tran;
            cmd1.ExecuteNonQuery();
            tran.Commit();
            con.Close();


            MessageBox.Show("Withdrawal successfully");

        }

        private void btn_showtrans_Click(object sender, RoutedEventArgs e)
        {
            dtg_cusshowtrans.Visibility=Visibility.Visible;
            SqlConnection con = new SqlConnection(constring.strcon);
            string regQur = string.Format("select TransactionNum,AccountNum,TranDate,Transferfrom,Amount,TranType,Transfer_to  from tbl_transaction Where AccountNum='{0}'", txt_custAccountnum.Text);
            SqlDataAdapter adp = new SqlDataAdapter(regQur, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dtg_cusshowtrans.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void btn_creatloan_Click(object sender, RoutedEventArgs e)
        {
            dtg_cusshowtrans.Visibility = Visibility.Visible;
            SqlConnection con = new SqlConnection(constring.strcon);
            SqlCommand cmd = new SqlCommand();
            string regQur = string.Format("insert into tbl_loan(AccountNum,Loanamount) values('{0}',{1})", txt_custAccountnum.Text,txt_loan.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = regQur;
            cmd.ExecuteNonQuery();
            string regloan = string.Format("select * from tbl_loan Where AccountNum='{0}'", txt_custAccountnum.Text);
            SqlDataAdapter adp = new SqlDataAdapter(regloan, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dtg_cusshowtrans.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
            MessageBox.Show("Loan is added");



        }
    }
}
