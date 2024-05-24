using System.Collections.Generic;
using ProfessionalProfile.Repo;
using ProfessionalProfile.Domain;

namespace TestProject
{
    public class PremiumUsersRepoMock : IRepoInterface<int>
    {
        private List<int> premiumUsers = new List<int> { };

        public void Add(int item)
        {
           premiumUsers.Add(item);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetAll()
        {
            return premiumUsers;
        }

        public int GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void  Update(int item)
        {
            throw new System.NotImplementedException();
        }
    }
}