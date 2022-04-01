using System.Collections.Generic;

namespace eCommerce.Domain.Common
{
    public abstract class AggregateRoot
    {
        private readonly List<Event> _events = new List<Event>();

        public Event[] Events => _events.ToArray();

        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }

        public void Apply(Event @event)
        {
            When(@event);
        }

        public abstract void When(Event @event);
    }
}
