using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Quiz.Models;

namespace Quiz.DBL
{
    public class DBClass
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["Sakthimudra"].ConnectionString;

        public string CheckLogin(Users user)
        {
            string Query = "select * from UserDetails where UserName = '"+user.UserName+"' and UserPassword = '"+user.UserPassword+"'";
           using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.Read() ? reader.GetValue(1).ToString():null;
            }
        }
    }
}