using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Repo
{
    public class EndorsementRepo : IRepoInterface<Endorsement>
    {
        public void Add(Endorsement item)
        {
        }

        public void Delete(int id)
        {
        }

        public List<Endorsement> GetAll()
        {
            List<Endorsement> endorsements = new List<Endorsement>();
            return endorsements;
        }

        public Endorsement GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Endorsement item)
        {
        }
    }
}
