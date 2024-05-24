using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.RepoMocks
{
    internal class UserRepoMock : IRepoInterface<User>
    {
        List<User> list = new List<User>();

        public void Add(User item)
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

        public List<User> GetAll()
        {
            return list;
        }

        public User? GetById(int id)
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

        public void Update(User item)
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

