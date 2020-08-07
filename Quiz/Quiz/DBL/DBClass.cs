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
            string Query = "select * from UserDetails where UserName = @UserName and UserPassword = @UserPassword";
           using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Query, Connection);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                    Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read() ? reader.GetValue(1).ToString() : null;
                }

                catch (Exception Ex)
                {
                    Console.WriteLine("Error in Login is" + Ex);
                    return null;
                }
            }
        }

        public string RegisterUser(Users user)
        {
            string Query = "insert into UserDetails([Name],UserName,Email,MobileNumber,UserPassword,DOB,Gender) values(@Name, @UserName, @Email, @MobileNumber, @UserPassword, @Dob, @Gender)";
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Query, Connection);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@MobileNumber", Convert.ToInt32(user.MobileNumber));
                    cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                    cmd.Parameters.AddWithValue("@Dob", user.DOB);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    return "Success";
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Register error is" +Ex);
                    return null;
                }
            }
        }
    }
}