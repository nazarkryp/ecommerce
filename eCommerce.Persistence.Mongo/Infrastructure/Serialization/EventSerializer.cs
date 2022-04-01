using System;
using System.Collections.Generic;
using System.Text.Json;

using eCommerce.Domain.Common;

namespace eCommerce.Persistence.Mongo.Infrastructure.Serialization
{
    public interface IEventSerializer
    {
        StoredEvent Serialize(Guid streamId, Event @event);

        Event Deserialize(StoredEvent resolvedEvent);
    }

    internal class EventSerializer : IEventSerializer
    {
        private readonly Dictionary<string, Type> _eventTypes;

        public EventSerializer(Dictionary<string, Type>? eventTypes)
        {
            _eventTypes = eventTypes ?? throw new ArgumentNullException(nameof(eventTypes), "Event types missing.");
        }

        public Event Deserialize(StoredEvent storedEvent)
        {
            if (!_eventTypes.TryGetValue(storedEvent.Type, out var type))
            {
                throw new ArgumentNullException(nameof(type), $"Could not resolve type '{storedEvent.Type}'");
            }

            var @event = JsonSerializer.Deserialize(storedEvent.Data, type) as Event;

            if (@event == null)
            {
                throw new ArgumentNullException($"Could not resolve type '{storedEvent.Type}'");
            }

            return @event;
        }

        public StoredEvent Serialize(Guid streamId, Event @event)
        {
            return new StoredEvent
            {
                StreamId = streamId,
                Data = JsonSerializer.Serialize(@event, @event.GetType()),
                Type = @event.GetType().Name,
                TimeStamp = DateTime.UtcNow,
                Version = 1
            };
        }
    }
}
