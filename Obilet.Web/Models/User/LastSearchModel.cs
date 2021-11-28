using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web.Models.User
{
    public class LastSearchModel
    {
        public LastSearchModel()
        {
            LastOriginId = default;
            LastDestinationId = default;
            LastDepartureDate = default;
        }
        public long LastOriginId { get; set; }

        public long LastDestinationId { get; set; }

        public DateTimeOffset LastDepartureDate { get; set; }
    }
}
