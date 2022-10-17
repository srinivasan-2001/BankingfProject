using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace entering_sheet
{
    class CusTransaction
    {
        public static void transaction(string myAcc,string senAcc,double amount)
        {
            SqlConnection con = new SqlConnection(constring.strcon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            SqlCommand cmd3 = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd3.Connection = con;
            SqlTransaction tran = con.BeginTransaction();
            string regQur = string.Format("insert into tbl_transaction(AccountNum,TranDate,Transferfrom,Amount,TranType,TranDC,Transfer_to) values('{0}',GETDATE(),'Application',{1},2,'Debited','{2}')", myAcc, amount,senAcc);
            cmd.CommandText = regQur;
            cmd.Transaction = tran;
            cmd.ExecuteNonQuery();
            String reqBalace = string.Format("Update tbl_custreg set Balance=Balance+{0} where AccountNum='{1}'", amount, senAcc);
            cmd1.CommandText = reqBalace;
            cmd1.Transaction = tran;
            cmd1.ExecuteNonQuery();
            String reqBalace1 = string.Format("Update tbl_custreg set Balance=Balance-{0} where AccountNum='{1}'", amount, myAcc);
            cmd2.CommandText = reqBalace1;
            cmd2.Transaction = tran;
            cmd2.ExecuteNonQuery();
            string regQur1 = string.Format("insert into tbl_transaction(AccountNum,TranDate,Transferfrom,Amount,TranType,TranDC,Transfer_to) values('{0}',GETDATE(),'Application',{1},1,'Cridite','{2}')", senAcc, amount, myAcc);
            cmd3.CommandText = regQur1;
            cmd3.Transaction = tran;
            cmd3.ExecuteNonQuery();
            tran.Commit();
            con.Close();
        }
        
    }
}
