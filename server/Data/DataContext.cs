using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

    }
}
