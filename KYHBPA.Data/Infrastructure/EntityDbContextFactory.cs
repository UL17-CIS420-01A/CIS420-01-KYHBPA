using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHBPA.Data.Infrastructure
{
    public class EntityDbContextFactory : IDbContextFactory<EntityDbContext>
    {
        public EntityDbContext Create() => EntityDbContext.Create();
    }
}
