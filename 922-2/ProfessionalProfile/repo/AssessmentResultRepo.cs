using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.RepoInterfaces;

namespace ProfessionalProfile.Repo
{
    internal class AssessmentResultRepo : IAssessmentResultRepoInterface<AssessmentResult>
    {
        private string connectionString;

        public AssessmentResultRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AssessmentResultRepo()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(AssessmentResult item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO AssessmentResult (AssessmentTestId, Score, UserId, TestDate) " +
                              "VALUES (@AssessmentTestId, @Score, @UserId, @TestDate)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@AssessmentTestId", item.AssessmentTestId);
                command.Parameters.AddWithValue("@Score", item.Score);
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@TestDate", item.TestDate);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
        }

        public List<AssessmentResult> GetAll()
        {
            List<AssessmentResult> assessmentResults = new List<AssessmentResult>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM AssessmentResult";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AssessmentResult assessmentResult = new AssessmentResult(reader.GetInt32(0),
                        reader.GetInt32(1), reader.GetInt32(2),
                        reader.GetInt32(3), reader.GetDateTime(4));

                    assessmentResults.Add(assessmentResult);
                }
            }

            return assessmentResults;
        }

        public List<AssessmentResult> GetAssessmentResultsByUserId(int userId)
        {
            List<AssessmentResult> allResults = this.GetAll();
            return allResults.FindAll(result => result.UserId == userId);
        }

        public AssessmentResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AssessmentResult item)
        {
        }
    }
}
