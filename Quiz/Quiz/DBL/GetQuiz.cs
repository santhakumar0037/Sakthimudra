using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Quiz.Models;

namespace Quiz.DBL
{
    public class GetQuiz
    {
        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Sakthimudra"].ConnectionString;

        public IEnumerable <Interest> GetInterestQuestions()
        {
            List<Interest> Questions = new List<Interest>();
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                string Querry = "select * from InsertQandA";
                try
                {
                    SqlCommand cmd = new SqlCommand(Querry, Connection);
                    Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var Question = new Interest
                        {
                            InterestId = Convert.ToInt32(reader.GetValue(0)),
                            Questions = reader.GetValue(1).ToString()
                        };
                        Questions.Add(Question);
                    }
                    return Questions;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error is " + Ex);
                    return null;
                }
            }
        }

        public IEnumerable<Personality> GetPersonalityQuestions()
        {
            List<Personality> Questions = new List<Personality>();
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                string Querry = "select * from PersonalityQandA";
                try
                {
                    SqlCommand cmd = new SqlCommand(Querry, Connection);
                    Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var Question = new Personality
                        {
                            personalityId = Convert.ToInt32(reader.GetValue(0)),
                            Questions = reader.GetValue(1).ToString()
                        };
                        Questions.Add(Question);
                    }
                    return Questions;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error is " + Ex);
                    return null;
                }
            }
        }

    }
}