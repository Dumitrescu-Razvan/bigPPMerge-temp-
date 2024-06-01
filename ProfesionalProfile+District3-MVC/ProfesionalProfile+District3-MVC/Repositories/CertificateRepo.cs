using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class CertificateRepo : ICertificateRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public CertificateRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Add(Certificate item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Certificates.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var certificate = context.Certificates.Find(id);
                    context.Certificates.Remove(certificate);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<Certificate> GetAll()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Certificates.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Certificate GetById(int id)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Certificates.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Certificate certificate)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Certificates.Update(certificate);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}