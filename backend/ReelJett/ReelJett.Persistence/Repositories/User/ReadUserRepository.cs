using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadUserRepository : ReadGenericRepository<User>, IReadUserRepository {

    // Constructor

    public ReadUserRepository(ReelJettDbContext context) : base(context) { }

    // Methods

    public async Task<User?> GetUserByEmail(string email) {
        return await _table.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<User?> GetUserByUserName(string userName) {
        return await _table.FirstOrDefaultAsync(p => p.UserName == userName);
    }
}