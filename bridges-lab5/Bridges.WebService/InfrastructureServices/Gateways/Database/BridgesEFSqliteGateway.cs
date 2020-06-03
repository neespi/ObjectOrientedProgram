using Bridges.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Bridges.ApplicationServices.Ports.Gateways.Database;

namespace Bridges.InfrastructureServices.Gateways.Database
{
    public class BridgesEFSqliteGateway : IBridgesDatabaseGateway
    {
        private readonly BridgesContext _bridgesContext;

        public BridgesEFSqliteGateway(BridgesContext BridgesContext)
            => _bridgesContext = BridgesContext;

        public async Task<BridgesPoint> GetBridgesPoint(long id)
           => await _bridgesContext.BridgesPoints.Where(b => b.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints()
            => await _bridgesContext.BridgesPoints.ToListAsync();
          
        public async Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(Expression<Func<BridgesPoint, bool>> filter)
            => await _bridgesContext.BridgesPoints.Where(filter).ToListAsync();

        public async Task AddBridgesPoint(BridgesPoint bridgespoint)
        {
            _bridgesContext.BridgesPoints.Add(bridgespoint);
            await _bridgesContext.SaveChangesAsync();
        }

        public async Task UpdateBridgesPoint(BridgesPoint bridgespoint)
        {
            _bridgesContext.Entry(bridgespoint).State = EntityState.Modified;
            await _bridgesContext.SaveChangesAsync();
        }

        public async Task RemoveBridgesPoint(BridgesPoint bridgespoint)
        {
            _bridgesContext.BridgesPoints.Remove(bridgespoint);
            await _bridgesContext.SaveChangesAsync();
        }

    }
}
