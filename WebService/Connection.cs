using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WSData
{
    public class Connection
    {
        //מחלקת התחברות

        //  private SqlDataAdapter adapter;
        private static string connectionString = @"Server= DESKTOP-K1J6P5T\SQLEXPRESS; Database=Gamee;Integrated Security=SSPI";
        // SqlConnection connection;

        //public Connection()
        //{
        //    connectionString = @"Server= DESKTOP-K1J6P5T\SQLEXPRESS; Database=Game;Integrated Security=SSPI";
        //    //  this.connection = new SqlConnection(connectionString);
        //}
        //  public DataTable getDataSet(string sqlStr)
        //{
        //    SqlCommand command = new SqlCommand(sqlStr, this.connection);
        //    connOpen();
        //    this.adapter = new SqlDataAdapter(command);
        //    //DataSet dataset = new DataSet();
        //    DataTable dt = new DataTable();
        //    //this.adapter.Fill(dataset, "Users");
        //    this.adapter.Fill(dt);
        //    connClose();
        //    return dt;
        //}
        //public SqlDataReader getDataReader(string sqlStr)
        //{
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(sqlStr, this.connection);
        //    return command.ExecuteReader();
        //}
        //public void connClose()
        //{
        //    this.connection.Close();
        //}
        //public void connOpen()
        //{
        //    this.connection.Open();
        //}
        //public bool NonQuery(string sqlStr)
        //{
        //    connOpen();
        //    SqlCommand command = new SqlCommand(sqlStr, connection);
        //    int a = command.ExecuteNonQuery();
        //    connClose();
        //    return (a > 0);
        //}
        //public void UpdateDataSet(DataSet dataset)
        //{
        //    this.adapter.Fill(dataset, "Users");
        //    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        //    adapter.UpdateCommand = builder.GetUpdateCommand();
        //    adapter.InsertCommand = builder.GetInsertCommand();
        //    adapter.DeleteCommand = builder.GetDeleteCommand();
        //    adapter.Update(dataset, "Users");
        //}

            
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