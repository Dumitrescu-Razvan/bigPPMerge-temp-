using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.RepoInterfaces;

namespace TestProject.Mocks
{
    public class SkillRepoMock : ISkillRepoInterface<Skill>
    {
        private List<Skill> _skillList;
        private List<User> _userList;
        public SkillRepoMock()
        {
            _skillList = new List<Skill>();
            _userList = new List<User>();
        }
        
        public void Add(Skill item)
        {
            _skillList.Add(item);
        }

        public void Delete(int id)
        {
            _skillList.RemoveAll(x => x.SkillId == id);
        }

        public List<Skill> GetAll()
        {
            return _skillList;
        }

        public List<Skill> GetByUserId(int userId)
        {
            if(_userList.Any(x => x.UserId == userId))
            {
                return _skillList;
            }
            return null;
        }
        public Skill GetById(int id)
        {

            return _skillList.Find(x => x.SkillId == id);

        }
        
        public int GetIdByName(string name)
        {
            return _skillList.Find(x => x.Name == name).SkillId;
        }

        public void Update(Skill item)
        {
           Skill skill = _skillList.Find(x => x.SkillId == item.SkillId);
            skill.Name = item.Name;
            skill.SkillId = item.SkillId;
        }
    }
}
