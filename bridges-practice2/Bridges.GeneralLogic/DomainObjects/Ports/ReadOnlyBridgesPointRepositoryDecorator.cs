using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bridges.DomainObjects.Repositories
{
    public abstract class ReadOnlyBridgesPointRepositoryDecorator : IReadOnlyBridgesPointRepository
    {
        private readonly IReadOnlyBridgesPointRepository _bridgespointRepository;

        public ReadOnlyBridgesPointRepositoryDecorator(IReadOnlyBridgesPointRepository bridgespointRepository)
        {
            _bridgespointRepository = bridgespointRepository;
        }

        public virtual async Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints()
        {
            return await _bridgespointRepository?.GetAllBridgesPoints();
        }

        public virtual async Task<BridgesPoint> GetBridgesPoint(long id)
        {
            return await _bridgespointRepository?.GetBridgesPoint(id);
        }

        public virtual async Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(ICriteria<BridgesPoint> criteria)
        {
            return await _bridgespointRepository?.QueryBridgesPoints(criteria);
        }
    }
}
