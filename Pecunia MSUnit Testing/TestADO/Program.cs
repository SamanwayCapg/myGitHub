using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Helpers;
using System.Data.SqlClient;
using System.Data;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;

namespace TestADO
{
    class Program
    {
        [STAThread]
        public static void Main()
        {

            Test.MenuOfPecunia().Wait();
        }

    }

    public class Test
    {
        public static async Task MenuOfPecunia()
        {
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TeamF.Customers", conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            adapter.DeleteCommand = cmd.GetDeleteCommand(true);
            adapter.UpdateCommand = cmd.GetUpdateCommand(true);
            adapter.InsertCommand = cmd.GetInsertCommand(true);

            DataSet ds = new DataSet("Customers");
            adapter.Fill(ds);
            Console.WriteLine(ds.Tables[0].Rows[0][0]);
            ds.Tables[0].AcceptChanges();
            for (int a=0; a<ds.Tables.Count; a++)
            {
                for(int i=0; i<ds.Tables[a].Rows.Count; i++)
                {
                    //for(int j=0; j<ds.Tables[a].Columns.Count; j++)
                    // {
                    //     //Console.WriteLine(ds.Tables[a].Rows[i][j]);
                    // }
                    if (ds.Tables[a].Rows[0][1].Equals("Ayush"))
                    {
                        Console.WriteLine("here");
                        ds.Tables[a].Rows[0].Delete();
                        break;
                    }
                }
            }
            ds.Tables[0].AcceptChanges();
            adapter.Update(ds.Tables[0]);
            conn.Close();
            Console.WriteLine("done");


        //    for (int a = 0; a < ds.Tables.Count; a++)
        //    {
        //        for (int i = 0; i < ds.Tables[a].Rows.Count; i++)
        //        {
        //            for (int j = 0; j < ds.Tables[a].Columns.Count; j++)
        //            {
        //                Console.WriteLine(ds.Tables[a].Rows[i][j]);
        //            }

        //        }
        //    }
        }

    }
}
