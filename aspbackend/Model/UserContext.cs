using Microsoft.EntityFrameworkCore;

namespace aspbackend.model{
    public class UserContext : DbContext{
        public UserContext(DbContextOptions<UserContext> options) : base(options){}
        public DbSet<User> Users {get; set;}
        public DbSet<StoredPassword> StoredPasswords {get; set;}
    }
}