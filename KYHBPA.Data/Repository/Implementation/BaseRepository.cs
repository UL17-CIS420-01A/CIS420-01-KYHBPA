using System;
using KYHBPA.Data.Infrastructure;

namespace KYHBPA.Data.Repository
{
    public class BaseRepository
    {
        protected readonly Entities context;

        public BaseRepository(Entities context)
        {
            if (context == null) throw new ArgumentNullException("context");
            this.context = context;
        }
    }
}
