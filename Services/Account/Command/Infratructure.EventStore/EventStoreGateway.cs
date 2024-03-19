using Application.Abstractions.Gateways;
using Domain.Abstractions.Aggregates;
using Domain.Abstractions.EventStore;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.EventStore
{
    public class EventStoreGateway : IEventStoreGateway
    {
        private readonly IEventStoreRepository _repository;
        private const int SnapshotInterval = 5;
        public EventStoreGateway(IEventStoreRepository repository) 
        { 
            _repository = repository;
        }
        public async Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            foreach (var @event in aggregate.UncommittedEvents)
            {
                var _event = StoreEvent.Create(aggregate, @event);
                Console.WriteLine(_event);
                await _repository.AppendEventAsync(_event, cancellationToken);
                //if (@event.Version % SnapshotInterval is 0)
                    //await _repository.AppendSnapshotAsync(Snapshot.Create(aggregate, _event), cancellationToken);
            }
        }

        public async Task<TAggregate> LoadAggregateAsync<TAggregate>(string aggregateId, CancellationToken cancellationToken) where TAggregate : IAggregateRoot, new()
        {
            //var snapshot = await _repository.GetSnapshotAsync(aggregateId, cancellationToken);
            //var events = await _repository.GetStreamAsync(aggregateId, 1, cancellationToken);
            var aggregate = new TAggregate();
            //aggregate.LoadFromHistory(events);
            return (TAggregate)aggregate;
        }
    }
}
