using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHBPA
{
    using System;
    using System.Text;

    /// <summary>
    /// This class is a utility class for encoding string values for transfer.
    /// </summary>
    /// <remarks>
    /// I.E. sending data to other pages using query strings.
    /// </remarks>
    public static class GuidExtensions
    {
        /// <summary>
        /// Checks if value has not been assigned.
        /// </summary>
        /// <param name="value">Guid</param>
        /// <returns>bool</returns>
        public static bool IsEmpty(this Guid value) => value == Guid.Empty;
    }
}
