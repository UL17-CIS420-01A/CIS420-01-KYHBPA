namespace KYHBPA.Data.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KYHBPA.Data.Entity;

    public class Entities : KYHBPAEntities
    {
        private Entities() : base()
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
