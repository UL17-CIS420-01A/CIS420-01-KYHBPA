using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYHBPA.Data.Entity;

namespace KYHBPA.Data.Infrastructure
{
    public class Entities : KYHBPAEntities
    {
        public Entities() : base()
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        
        public static Entities Create()
        {
            return new Entities();
        }
    }
}
