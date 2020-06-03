using Bridges.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bridges.ApplicationServices.Ports.Gateways.Database
{
    public interface IBridgesDatabaseGateway
    {
        Task AddBridgesPoint(BridgesPoint bridgespoint);

        Task RemoveBridgesPoint(BridgesPoint bridgespoint);

        Task UpdateBridgesPoint(BridgesPoint bridgespoint);

        Task<BridgesPoint> GetBridgesPoint(long id);

        Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints();

        Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(Expression<Func<BridgesPoint, bool>> filter);

    }
}
