﻿using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IProjectionGateway<TProjection>
    where TProjection : IProjection
    {
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken);
        Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken);
        Task DeleteAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task<List<TProjection?>> FindPaginatonAsync(int pageIndex, CancellationToken cancellationToken);

    }
}
