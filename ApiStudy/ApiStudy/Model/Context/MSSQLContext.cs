using Microsoft.EntityFrameworkCore;

namespace ApiStudy.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
