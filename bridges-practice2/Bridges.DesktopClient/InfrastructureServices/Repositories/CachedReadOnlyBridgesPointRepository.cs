using Bridges.ApplicationServices.Ports.Cache;
using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using Bridges.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bridges.InfrastructureServices.Repositories
{
    public class CachedReadOnlyBridgesPointRepository : ReadOnlyBridgesPointRepositoryDecorator
    {
        private readonly IDomainObjectsCache<BridgesPoint> _bridgespointsCache;

        public CachedReadOnlyBridgesPointRepository(IReadOnlyBridgesPointRepository bridgespointRepository, 
                                             IDomainObjectsCache<BridgesPoint> bridgespointsCache)
            : base(bridgespointRepository)
            => _bridgespointsCache = bridgespointsCache;

        public async override Task<BridgesPoint> GetBridgesPoint(long id)
            => _bridgespointsCache.GetObject(id) ?? await base.GetBridgesPoint(id);

        public async override Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints()
            => _bridgespointsCache.GetObjects() ?? await base.GetAllBridgesPoints();

        public async override Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(ICriteria<BridgesPoint> criteria)
            => _bridgespointsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryBridgesPoints(criteria);

    }
}
