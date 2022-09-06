
namespace dbContext.Database
{
    public class Efcontext : DbContext
    {
        public Efcontext(DbContextOptions<Efcontext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

