using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Business
{
    public class PrivacyService
    {
        internal IRepoInterface<Privacy> PrivacyRepo { get; set; }
        public PrivacyService(IRepoInterface<Privacy> privacyRepo = null)
        {
            if (privacyRepo == null)
            {
                PrivacyRepo = privacyRepo;
            }
            else
            {
                PrivacyRepo = privacyRepo;
            }
        }

        public void AddPrivacy(Privacy privacy)
        {
            PrivacyRepo.Add(privacy);
        }

        public void UpdatePrivacy(Privacy privacy)
        {
            PrivacyRepo.Update(privacy);
        }

        public Privacy GetPrivacy(int userId)
        {
            Privacy result = PrivacyRepo.GetById(userId);

            if (result != null)
            {
                return result;
            }
            this.AddPrivacy(new Privacy(userId, true, true, true, true, true, true));
            return PrivacyRepo.GetById(userId);
        }
    }
}
