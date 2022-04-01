using System;

namespace eCommerce.Domain.Common
{
    public abstract class Event
    {
        public Guid EventId { get; set; }
    }
}
