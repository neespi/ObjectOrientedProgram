using Bridges.ApplicationServices.GetBridgesPointListUseCase;
using System.Net;
using Newtonsoft.Json;
using Bridges.ApplicationServices.Ports;

namespace Bridges.InfrastructureServices.Presenters
{
    public class BridgesPointListPresenter : IOutputPort<GetBridgesPointListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public BridgesPointListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetBridgesPointListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.BridgesPoints) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
