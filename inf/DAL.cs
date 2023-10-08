using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace inf
{
    class DAL
    {




        // static string DatabaseConnectionString = @"Server=DELTA\SQLEXPRESS;Database=materialsRequest;Trusted_Connection = True;";
        static string DatabaseConnectionString = @"Server=GAMMA\SQLEXPRESS;Database=infinityDB;Trusted_Connection = True;";

        //static string DatabaseConnectionString = @"Data Source=DELTA\SQLEXPRESS;Initial Catalog=materialsRequest";

        public static DataTable ExecuteSelectCommand(SqlCommand command)
        {
            command.Connection.Open();
            DataTable table;
            SqlDataAdapter ad = new SqlDataAdapter(command);
            table = new DataTable();
            ad.Fill(table);
            command.Connection.Close();
            return table;
        }
        public static SqlDataAdapter ExecuteSelectCommandAD(SqlCommand command)
        {
            command.Connection.Open();
            DataTable table;
            SqlDataAdapter ad = new SqlDataAdapter(command);
            table = new DataTable();
            ad.Fill(table);
            command.Connection.Close();
            return ad;
        }

        public static IDataReader ExecuteReader(SqlCommand command)
        {
            command.Connection.Open();
            DbDataReader reader = command.ExecuteReader();
            return reader;
        }
        public static bool ExecuteCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
                return true;
            }
            catch
            {
                return false;


            }


        }
        public static int ExecuteScalar(SqlCommand command)
        {

            command.Connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return count;

        }


        public static SqlCommand CreateCommand()
        {
            try
            {

                SqlConnection conn = new SqlConnection(DatabaseConnectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                conn.Close();
                return comm;
            }
            catch
            {
                return null;


            }
        }









        public static SqlConnection CreatConn()
        {



            SqlConnection ConStr = null;
            try
            {
                ConStr = new SqlConnection(DatabaseConnectionString);

                ConStr.Open();


            }
            catch
            {
                ErrorMsg();
                ConStr = null;
            }

            return ConStr;
        }
        public static void ErrorMsg()
        {
            // MessageBox.Show("Hello, world!", "My App");


        }



    }
}
