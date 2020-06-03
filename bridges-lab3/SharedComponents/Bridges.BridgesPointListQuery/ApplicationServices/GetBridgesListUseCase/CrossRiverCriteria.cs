using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bridges.ApplicationServices.GetBridgesPointListUseCase
{
    public class CrossRiverCriteria : ICriteria<BridgesPoint>
    {
        public string CrossRiver { get; }

        public CrossRiverCriteria (string crossriver)
            => CrossRiver = crossriver;

        public Expression<Func<BridgesPoint, bool>> Filter
            => (b => b.CrossRiver == CrossRiver);
    }
}
