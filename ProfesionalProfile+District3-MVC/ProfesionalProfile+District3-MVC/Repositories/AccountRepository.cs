using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class AccountRepository : IRepoInterface<Account>
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Account item)
        {
            _context.Account.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var account = _context.Account.Find(id);
            if (account != null)
            {
                _context.Account.Remove(account);
                _context.SaveChanges();
            }
        }

        public ICollection<Account> GetAll()
        {
            return _context.Account.ToList();
        }

        public Account GetById(int id)
        {
            return _context.Account.Find(id);
        }

        public void Update(Account item)
        {
            _context.Account.Update(item);
            _context.SaveChanges();
        }
    }
}