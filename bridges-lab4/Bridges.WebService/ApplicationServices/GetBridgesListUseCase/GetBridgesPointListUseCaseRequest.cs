using Bridges.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.ApplicationServices.GetBridgesPointListUseCase
{
    public class GetBridgesPointListUseCaseRequest : IUseCaseRequest<GetBridgesPointListUseCaseResponse>
    {
        public string CrossRiver { get; private set; }
        public long? BridgesPointId { get; private set; }

        private GetBridgesPointListUseCaseRequest()
        { }

        public static GetBridgesPointListUseCaseRequest CreateAllBridgesPointsRequest()
        {
            return new GetBridgesPointListUseCaseRequest();
        }

        public static GetBridgesPointListUseCaseRequest CreateBridgesPointRequest(long bridgespointId)
        {
            return new GetBridgesPointListUseCaseRequest() { BridgesPointId = bridgespointId };
        }
        public static GetBridgesPointListUseCaseRequest CreateBridgesPointsRequest(string crossriver)
        {
            return new GetBridgesPointListUseCaseRequest() { CrossRiver = crossriver };
        }
    }
}
