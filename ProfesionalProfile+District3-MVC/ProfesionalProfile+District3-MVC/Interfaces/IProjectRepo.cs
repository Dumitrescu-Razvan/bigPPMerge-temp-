﻿using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IProjectRepo
    {
        public Project GetById(int id);
        public ICollection<Project> GetAll();
        public void Add(Project item);
        public void Update(Project item);
        public void Delete(int id);
    }
}
