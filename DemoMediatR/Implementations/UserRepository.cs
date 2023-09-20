using DemoMediatR.Data;
using DemoMediatR.Interfaces;
using DemoMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMediatR.Implementations
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<User>> GetAll() => await _db.Users.Include(u => u.Role).ToListAsync();

        public async Task<User> GetById(int id) => await _db.Users.FirstOrDefaultAsync(u => u.Id == id);

        public void Create(User entity)
        {
            _db.Users.Add(entity);

            _db.Entry(entity).Reference(u => u.Role).Load();
        }

        public void Delete(User entity) => _db.Users.Remove(entity);

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
