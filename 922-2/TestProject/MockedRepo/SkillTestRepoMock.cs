using ProfessionalProfile.Domain;
using ProfessionalProfile.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockedRepo
{
    internal class SkillTestRepoMock :ISkillRepoInterface<Skill>
    {
        List<Skill> skills;

        public SkillTestRepoMock()
        {
            skills = new List<Skill>();
        }

        public void Add(Skill item)
        {
            skills.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetAll()
        {
            return this.skills;
        }

        public Skill GetById(int id)
        {
            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].SkillId == id)
                {
                    return skills[i];
                }
            }
            return null;
        }

        public int GetIdByName(string skillName)
        {
            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].Name == skillName)
                {
                    return skills[i].SkillId;
                }
            }
            return -1;
        }

        public void Update(Skill item)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
