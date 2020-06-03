using Bridges.DomainObjects;
using Bridges.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.ApplicationServices.GetBridgesPointListUseCase
{
    public class GetBridgesPointListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<BridgesPoint> BridgesPoints { get; }

        public GetBridgesPointListUseCaseResponse(IEnumerable<BridgesPoint> bridgespoints) => BridgesPoints = bridgespoints;
    }
}
