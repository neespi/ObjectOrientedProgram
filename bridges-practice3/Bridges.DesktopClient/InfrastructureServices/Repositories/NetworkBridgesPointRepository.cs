using Bridges.ApplicationServices.Ports.Cache;
using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bridges.InfrastructureServices.Repositories
{
    public class NetworkBridgesPointRepository : NetworkRepositoryBase, IReadOnlyBridgesPointRepository
    {
        private readonly IDomainObjectsCache<BridgesPoint> _bridgespointCache;

        public NetworkBridgesPointRepository(string host, ushort port, bool useTls, IDomainObjectsCache<BridgesPoint> bridgespointCache)
            : base(host, port, useTls)
            => _bridgespointCache = bridgespointCache;

        public async Task<BridgesPoint> GetBridgesPoint(long id)
            => CacheAndReturn(await ExecuteHttpRequest<BridgesPoint>($"bridgespoints/{id}"));

        public async Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<BridgesPoint>>($"bridgespoints"), allObjects: true);

        public async Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(ICriteria<BridgesPoint> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<BridgesPoint>>($"bridgespoints"), allObjects: true)
               .Where(criteria.Filter.Compile());


        private IEnumerable<BridgesPoint> CacheAndReturn(IEnumerable<BridgesPoint> bridgespoints, bool allObjects = false)
        {
            if (allObjects)
            {
                _bridgespointCache.ClearCache();
            }
            _bridgespointCache.UpdateObjects(bridgespoints, DateTime.Now.AddDays(1), allObjects);
            return bridgespoints;
        }

        private BridgesPoint CacheAndReturn(BridgesPoint bridgespoint)
        {
            _bridgespointCache.UpdateObject(bridgespoint, DateTime.Now.AddDays(1));
            return bridgespoint;
        }
    }
}
