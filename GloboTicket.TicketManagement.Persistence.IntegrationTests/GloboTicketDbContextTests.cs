using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GloboTicketDbContextTests : DbContext
    {
        private readonly Mock<ILoggedInUserService> _loggedInUserService;

        public GloboTicketDbContextTests(DbContextOptions<GloboTicketDbContext> options) : base(options)
        {

        }
        public GloboTicketDbContextTests(DbContextOptions<GloboTicketDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}