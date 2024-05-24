using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Skill
    {
        private int skillId;
        private string name;

        public Skill(int skillId, string name)
        {
            this.skillId = skillId;
            this.name = name;
        }

        public int SkillId
        {
            get { return skillId; }
            set { skillId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Skill skill &&
                   skillId == skill.skillId &&
                   name == skill.name &&
                   SkillId == skill.SkillId &&
                   Name == skill.Name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
