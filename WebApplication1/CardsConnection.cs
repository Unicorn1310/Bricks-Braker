using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CardsConnection
    {
        //מחלקת התחברות

        //  private SqlDataAdapter adapter;
        private static string connectionString = @"Server= DESKTOP-K1J6P5T\SQLEXPRESS; Database=CreditCard;Integrated Security=SSPI";

        public static int GetInt(string query)
        { //לקבל מספר שלם
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int rd = (int)cmd.ExecuteScalar();
            conn.Close();
            return rd;
        }

        public static DataTable Select(string query)
        { //לבחור
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;
        }

        public static void Update(string query)
        {
            //לעדכן
            SqlConnection conn;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}