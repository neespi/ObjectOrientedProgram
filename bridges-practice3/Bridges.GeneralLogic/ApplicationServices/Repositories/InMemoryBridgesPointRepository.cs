using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bridges.ApplicationServices.Repositories
{
    public class InMemoryBridgesPointRepository : IReadOnlyBridgesPointRepository,
                                           IBridgesPointRepository 
    {
        private readonly List<BridgesPoint> _bridgespoints = new List<BridgesPoint>();

        public InMemoryBridgesPointRepository(IEnumerable<BridgesPoint> bridgespoints = null)
        {
            if (bridgespoints != null)
            {
                _bridgespoints.AddRange(bridgespoints);
            }
        }

        public Task AddBridgesPoint(BridgesPoint bridgespoint)
        {
            _bridgespoints.Add(bridgespoint);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<BridgesPoint>> GetAllBridgesPoints()
        {
            return Task.FromResult(_bridgespoints.AsEnumerable());
        }

        public Task<BridgesPoint> GetBridgesPoint(long id)
        {
            return Task.FromResult(_bridgespoints.Where(mp => mp.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<BridgesPoint>> QueryBridgesPoints(ICriteria<BridgesPoint> criteria)
        {
            return Task.FromResult(_bridgespoints.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveBridgesPoint(BridgesPoint bridgespoint)
        {
            _bridgespoints.Remove(bridgespoint);
            return Task.CompletedTask;
        }

        public Task UpdateBridgesPoint(BridgesPoint bridgespoint)
        {
            var foundBridgesPoint = GetBridgesPoint(bridgespoint.Id).Result;
            if (foundBridgesPoint == null)
            {
                AddBridgesPoint(bridgespoint);
            }
            else
            {
                if (foundBridgesPoint != bridgespoint)
                {
                    _bridgespoints.Remove(foundBridgesPoint);
                    _bridgespoints.Add(bridgespoint);
                }
            }
            return Task.CompletedTask;
        }
    }
}
