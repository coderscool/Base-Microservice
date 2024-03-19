using Domain.Abstractions.Aggregates;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.EventStore.Contexts.Converters
{
    public class AggregateConverter : ValueConverter<IAggregateRoot?, string>
    {
        public AggregateConverter()
            : base(
                @event => JsonConvert.SerializeObject(@event),
                jsonString => JsonConvert.DeserializeObject<IAggregateRoot>(jsonString))
        { }
    }
}
