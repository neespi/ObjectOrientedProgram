using System.Threading.Tasks;
using System.Collections.Generic;
using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using Bridges.ApplicationServices.Ports;

namespace Bridges.ApplicationServices.GetBridgesPointListUseCase
{
    public class GetBridgesPointListUseCase : IGetBridgesPointListUseCase
    {
        private readonly IReadOnlyBridgesPointRepository _readOnlyBridgesPointRepository;

        public GetBridgesPointListUseCase(IReadOnlyBridgesPointRepository readOnlyBridgesPointRepository) 
            => _readOnlyBridgesPointRepository = readOnlyBridgesPointRepository;

        public async Task<bool> Handle(GetBridgesPointListUseCaseRequest request, IOutputPort<GetBridgesPointListUseCaseResponse> outputPort)
        {
            IEnumerable<BridgesPoint> bridgespoints = null;
            if (request.BridgesPointId != null)
            {
                var bridgespoint = await _readOnlyBridgesPointRepository.GetBridgesPoint(request.BridgesPointId.Value);
                bridgespoints = (bridgespoint != null) ? new List<BridgesPoint>() { bridgespoint } : new List<BridgesPoint>();
                
            }
            else if (request.CrossRiver != null)
            {
                bridgespoints = await _readOnlyBridgesPointRepository.QueryBridgesPoints(new CrossRiverCriteria(request.CrossRiver));
            }
            else
            {
                bridgespoints = await _readOnlyBridgesPointRepository.GetAllBridgesPoints();
            }
            outputPort.Handle(new GetBridgesPointListUseCaseResponse(bridgespoints));
            return true;
        }
    }
}
