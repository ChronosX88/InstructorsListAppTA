using Microsoft.EntityFrameworkCore;

namespace InstructorsListApp.Models {
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options)
        { }
 
        public DbSet<Instructor> Instructors { get; set; }
    }
}