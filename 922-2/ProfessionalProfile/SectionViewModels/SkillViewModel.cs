using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionCommands;

namespace ProfessionalProfile.SectionviewModels
{
    public class SkillviewModel : SectionviewModelBase
    {
        private string skillName;
        public string SkillName
        {
            get
            {
                return skillName;
            }

            set
            {
                skillName = value;

                OnPropertyChanged("SkillName");
            }
        }

        public ICommand AddSkillButton { get; }

        public SkillviewModel(SkillRepo skillRepo, int userId)
        {
            AddSkillButton = new AddSkillCommand(this, skillRepo, userId);
        }
    }
}
