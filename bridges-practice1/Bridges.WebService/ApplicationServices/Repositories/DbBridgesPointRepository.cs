using Bridges.ApplicationServices.Ports.Gateways.Database;
using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bridges.ApplicationServices.Repositories
{
    public class DbBridgesPointRepository : IReadOnlyBridgesPointRepository,
                                     IBridgesPointRepository
    {
        private readonly IBridgesDatabaseGateway _databaseGateway;

        public DbBridgesPointRepository(IBridgesDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<BridgesPoint> GetBridgesPoint(long id)
            => await _databaseGateway.GetBridgesPoint(id);

        public async Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints()
            => await _databaseGateway.GetAllBridgesPoints();

        public async Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(ICriteria<BridgesPoint> criteria)
            => await _databaseGateway.QueryBridgesPoints(criteria.Filter);

        public async Task AddBridgesPoint(BridgesPoint bridgespoint)
            => await _databaseGateway.AddBridgesPoint(bridgespoint);

        public async Task RemoveBridgesPoint(BridgesPoint bridgespoint)
            => await _databaseGateway.RemoveBridgesPoint(bridgespoint);

        public async Task UpdateBridgesPoint(BridgesPoint bridgespoint)
            => await _databaseGateway.UpdateBridgesPoint(bridgespoint);
    }
}
