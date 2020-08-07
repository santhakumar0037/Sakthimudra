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
        EncryptPasswords EncryptPassword = new EncryptPasswords();
        readonly string connectionString = ConfigurationManager.ConnectionStrings["Sakthimudra"].ConnectionString;

        private bool CheckLogin(string UserName, string UserPassword)
        {
            string Query = "select * from UserDetails where UserName = @UserName and UserPassword = @UserPassword";
            var password = EncryptPassword.EncodePasswordToBase64(UserPassword);
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Query, Connection);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@UserPassword", password);
                    Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.HasRows ? true : false;
                }

                catch (Exception Ex)
                {
                    Console.WriteLine("Error in Login is" + Ex);
                    return false;
                }
            }
        }

        public string GetUser(Users user)
        {
            if (CheckLogin(user.UserName, user.UserPassword))
            {
                string Query = "select Name from UserDetails where UserName = @UserName";
                using (SqlConnection Connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Query, Connection);
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        Connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        return reader.Read() ? reader.GetValue(0).ToString() : null;
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("Error in Read UserName" + Ex);
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public bool RegisterUser(Users user)
        {
            string Query = "insert into UserDetails([Name],UserName,Email,MobileNumber,UserPassword,DOB,Gender) values(@Name, @UserName, @Email, @MobileNumber, @UserPassword, @Dob, @Gender)";
            var password = EncryptPassword.EncodePasswordToBase64(user.UserPassword);
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Query, Connection);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@MobileNumber", Convert.ToInt32(user.MobileNumber));
                    cmd.Parameters.AddWithValue("@UserPassword", password);
                    cmd.Parameters.AddWithValue("@Dob", user.DOB);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error in register is" + Ex);
                    return false;
                }
            }
        }
    }
}