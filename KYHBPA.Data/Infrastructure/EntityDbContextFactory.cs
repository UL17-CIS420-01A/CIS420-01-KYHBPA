using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHBPA.Data.Infrastructure
{
    class EntityDbContextFactory : IDbContextFactory<EntityDbContext>
    {
        public EntityDbContextFactory()
        {
        }

        public EntityDbContext Create() => EntityDbContext.Create();
    }
}
