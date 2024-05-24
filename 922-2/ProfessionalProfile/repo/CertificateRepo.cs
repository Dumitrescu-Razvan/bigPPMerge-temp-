using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfessionalProfile.repo
{
    public class CertificateRepo : ICertificateRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public CertificateRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Add(Certificate item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Certificate.Add(item);
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
                    var certificate = context.Certificate.Find(id);
                    context.Certificate.Remove(certificate);
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
                    return context.Certificate.ToList();
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
                    return context.Certificate.Find(id);
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
                    context.Certificate.Update(certificate);
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