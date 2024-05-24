using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Business
{
    public class PremiumUsersService
    {
        public IRepoInterface<int> PremiumUsersRepo { get; set; }

        public PremiumUsersService(IRepoInterface<int> repo = null)
        {
            PremiumUsersRepo = repo ?? new PremiumUsersRepo();
        }

        public List<int> GetPremiumUsers()
        {
            return PremiumUsersRepo.GetAll();
        }

        public bool IsPremiumUser(int userId)
        {
            return this.PremiumUsersRepo.GetAll().Contains(userId);
        }

        public void AddPremiumUser(int userId)
        {
            this.PremiumUsersRepo.Add(userId);
        }
    }
}
