using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionviewModels;

namespace ProfessionalProfile.SectionCommands
{
    public class AddSkillCommand : SectionCommandBase
    {
        private readonly SkillviewModel skillviewModel;
        private readonly SkillRepo skillRepo;
        private readonly int userId;

        public AddSkillCommand(SkillviewModel skillviewModel, SkillRepo skillRepo, int userId)
        {
            this.skillviewModel = skillviewModel;
            this.skillRepo = skillRepo;
            this.userId = userId;
            skillviewModel.PropertyChanged += OnviewModelPropertyChanged;
        }
        public override void Execute(object parameter)
        {
            string modifiedSkillName = skillviewModel.SkillName.ToLower().Replace(" ", string.Empty);
            Skill skill = new Skill(4, modifiedSkillName);

            skillRepo.Add(skill);
            MessageBox.Show("Skill added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(skillviewModel.SkillName) &&
                base.CanExecute(parameter);
        }

        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SkillviewModel.SkillName))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
