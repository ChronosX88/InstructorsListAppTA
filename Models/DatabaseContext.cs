using Microsoft.EntityFrameworkCore;

namespace InstructorsListApp.Models {
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        { }
 
        public DbSet<Instructor> Instructors { get; set; }
    }
}