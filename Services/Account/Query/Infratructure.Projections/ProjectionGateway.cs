using Application.Abstractions;
using Contracts.Abstractions.Messages;
using Contracts.Services.Account;
using Infratructure.Projections.Abstractions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.Projections
{
    public class ProjectionGateway<TProjection> : IProjectionGateway<TProjection>
        where TProjection : IProjection
    {
        private readonly IMongoCollection<TProjection> _collection;
        private const int pageSize = 2;

        public ProjectionGateway(IMongoDbContext context)
        {
            _collection = context.GetCollection<TProjection>();
        }

        public async Task DeleteAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.DeleteManyAsync(predicate, cancellationToken);

        public async Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync(cancellationToken)!;

        public async Task<List<TProjection?>> FindPaginatonAsync(int pageIndex, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Skip(pageIndex*pageSize).Take(pageSize).ToListAsync();

        public async ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken)
            => await _collection.InsertOneAsync(replacement);

        public async Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken)
            => await _collection.ReplaceOneAsync(predicate, projection);
    }
}
