using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace TestProject.RepoMocks
{
    internal class PrivacyRepoMock : IRepoInterface<Privacy>
    {
        List<Privacy> list = new List<Privacy>();

        public void Add(Privacy item)
        {
            list.Add(item);
        }

        public void Delete(int id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].UserId == id)
                {
                    list.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Item not found");

        }

        public List<Privacy> GetAll()
        {
            return list;
        }

        public Privacy? GetById(int id)
        {
            // Go through the list and returned the one with the id found
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].UserId == id)
                {
                    return list[i];
                }
            }

            return null;
        }

        public void Update(Privacy item)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].UserId == item.UserId)
                {
                    list[i] = item;
                    return;
                }
            }
            throw new Exception("Item not found");
        }
    }
}

