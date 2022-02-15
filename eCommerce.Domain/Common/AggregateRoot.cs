using System.Collections.Generic;

namespace eCommerce.Domain.Common
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _events = new List<IEvent>();

        public IEvent[] Events => _events.ToArray();

        public void AddEvent(IEvent @event)
        {
            _events.Add(@event);
        }

        public void Apply(IEvent @event)
        {
            When(@event);
        }

        public abstract void When(IEvent @event);
    }
}
