using Microsoft.EntityFrameworkCore;
using Ordering.Core.Common;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }
        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    //case EntityState.Detached:
                    //    break;
                    //case EntityState.Unchanged:
                    //    break;
                    //case EntityState.Deleted:
                    //    break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now; //TODO: Replace with auth server
                        entry.Entity.LastModifiedBy = "rahul";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "rahul";  //TODO: Replace with auth server
                        break;
                    //default:
                    //    break;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken);
        }
        
    }
}
