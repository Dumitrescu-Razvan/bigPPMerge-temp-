using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Interfaces
{
    public interface INotificationRepoInterface<T> : IRepoInterface<T>
    {
        public List<T> GetAllByUserId(int userId);
    }
}
