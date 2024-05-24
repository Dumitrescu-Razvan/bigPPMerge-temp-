using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Repo
{
    internal class PrivacyRepo : IRepoInterface<Privacy>
    {
        private string connectionString;

        public PrivacyRepo()
        {
            // IsRead connection string from app.config
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Privacy item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Privacy (UserId, CanViewEducation, CanViewWorkExperience, CanViewVolunteering, CanViewProjects, CanViewCertificates, CanViewSkills) " +
                    "VALUES (@UserId, @CanViewEducation, @CanViewWorkExperience, @CanViewVolunteering, @CanViewProjects, @CanViewCertificates, @CanViewSkills)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@CanViewEducation", item.CanViewEducation);
                command.Parameters.AddWithValue("@CanViewWorkExperience", item.CanViewWorkExperience);
                command.Parameters.AddWithValue("@CanViewVolunteering", item.CanViewVolunteering);
                command.Parameters.AddWithValue("@CanViewProjects", item.CanViewProjects);
                command.Parameters.AddWithValue("@CanViewCertificates", item.CanViewCertificates);
                command.Parameters.AddWithValue("@CanViewSkills", item.CanViewSkills);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Privacy> GetAll()
        {
            List<Privacy> list = new List<Privacy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Privacy";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int userId = (int)reader["UserId"];
                    bool canViewEducation = (bool)reader["CanViewEducation"];
                    bool canViewWorkExperience = (bool)reader["CanViewWorkExperience"];
                    bool canViewSkills = (bool)reader["CanViewSkills"];
                    bool canViewProjects = (bool)reader["CanViewProjects"];
                    bool canViewCertificates = (bool)reader["CanViewCertificates"];
                    bool canViewVolunteering = (bool)reader["CanViewVolunteering"];

                    Privacy privacy = new Privacy(userId, canViewEducation, canViewWorkExperience, canViewSkills, canViewProjects, canViewCertificates, canViewVolunteering);
                    list.Add(privacy);
                }
            }

            return list;
        }

        // returns by user id
        public Privacy GetById(int id)
        {
            Privacy privacy = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Privacy WHERE UserId = @UserId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@UserId", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int userId = (int)reader["UserId"];
                    bool canViewEducation = (bool)reader["CanViewEducation"];
                    bool canViewWorkExperience = (bool)reader["CanViewWorkExperience"];
                    bool canViewSkills = (bool)reader["CanViewSkills"];
                    bool canViewProjects = (bool)reader["CanViewProjects"];
                    bool canViewCertificates = (bool)reader["CanViewCertificates"];
                    bool canViewVolunteering = (bool)reader["CanViewVolunteering"];

                    privacy = new Privacy(userId, canViewEducation, canViewWorkExperience, canViewSkills, canViewProjects, canViewCertificates, canViewVolunteering);
                }
            }

            return privacy;
        }

        public void Update(Privacy item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Privacy SET CanViewEducation = @CanViewEducation, CanViewWorkExperience = @CanViewWorkExperience, CanViewVolunteering = @CanViewVolunteering, CanViewProjects = @CanViewProjects, CanViewCertificates = @CanViewCertificates, CanViewSkills = @CanViewSkills WHERE UserId = @UserId";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@CanViewEducation", item.CanViewEducation);
                command.Parameters.AddWithValue("@CanViewWorkExperience", item.CanViewWorkExperience);
                command.Parameters.AddWithValue("@CanViewVolunteering", item.CanViewVolunteering);
                command.Parameters.AddWithValue("@CanViewProjects", item.CanViewProjects);
                command.Parameters.AddWithValue("@CanViewCertificates", item.CanViewCertificates);
                command.Parameters.AddWithValue("@CanViewSkills", item.CanViewSkills);

                command.ExecuteNonQuery();
            }
        }
    }
}
