using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Models
{
    //this file is used to set up the databse
    //in order to update the database with the new data migration use the "dotnet ef migrations add 'Name'" command
    //to implement the migration use "dotnet ef database update"
    //if the database doesnot exist yet will create a 'Namespace'.db file
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Value> Values { get; set; }
    }
}