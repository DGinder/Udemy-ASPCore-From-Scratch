using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Models
{
    //this file is used to set up the databse
    //in order to update the database with the new data migration use the "dotnet ef migrations add 'Name'" command
    //to implement the migration use "dotnet ef database update"
    //if the database doesnot exist yet will create a 'Namespace'.db file
    //currently checking database in db browser for sqlite
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Value> Values { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Photo> Photos { get; set;}
        public DbSet<Like> Likes { get; set; }

        // overriding how the db will set up the realtionship for the
        // like table with fluent api
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Like>()
                .HasKey(k => new {k.LikerId, k.LikeeId});

            builder.Entity<Like>()
                .HasOne(u => u.Likee)
                .WithMany(u => u.Likers)
                .HasForeignKey( u => u.LikeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likees)
                .HasForeignKey( u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}