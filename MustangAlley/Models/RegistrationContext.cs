using MustangAlley.ViewModels.Registration;
using Microsoft.EntityFrameworkCore;


namespace MustangAlley.Models
{
    public class RegistrationContext : BaseDbContext
    {
        public RegistrationContext(DbContextOptions options) : base(options)
    {
        }

        public DbSet<RegistrationViewModel> RegistrationRecords { get; set; }
    }

    public class BaseDbContext : DbContext
    {

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
