using Contracts.Abstractions.Messages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infratructure.EventStore.Contexts.Converters
{
    public class EventConverter : ValueConverter<IDomainEvent?, string>
    {
        public EventConverter()
            : base(
                @event => JsonConvert.SerializeObject(@event),
                jsonString => JsonConvert.DeserializeObject<IDomainEvent>(jsonString))
        { }

        private static string SerializerSettings()
        {
            return "123";
        }

        private static string DeserializerSettings()
        {
            return "456";
        }
    }
}
