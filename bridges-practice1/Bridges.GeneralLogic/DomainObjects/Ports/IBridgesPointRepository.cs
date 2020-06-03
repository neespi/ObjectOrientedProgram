using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Bridges.DomainObjects.Ports
{
    public interface IReadOnlyBridgesPointRepository
    {
        Task<BridgesPoint> GetBridgesPoint(long id);

        Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints();

        Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(ICriteria<BridgesPoint> criteria);

    }

    public interface IBridgesPointRepository
    {
        Task AddBridgesPoint(BridgesPoint bridgespoint);

        Task RemoveBridgesPoint(BridgesPoint bridgespoint);

        Task UpdateBridgesPoint(BridgesPoint bridgespoint);
    }
}
