using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bridges.DomainObjects;
using Bridges.ApplicationServices.GetBridgesPointListUseCase;
using Bridges.InfrastructureServices.Presenters;

namespace Bridges.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BridgesPointsController : ControllerBase
    {
        private readonly ILogger<BridgesPointsController> _logger;
        private readonly IGetBridgesPointListUseCase _getBridgesPointListUseCase;

        public BridgesPointsController(ILogger<BridgesPointsController> logger,
                                IGetBridgesPointListUseCase getBridgesPointListUseCase)
        {
            _logger = logger;
            _getBridgesPointListUseCase = getBridgesPointListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBridgesPoints()
        {
            var presenter = new BridgesPointListPresenter();
            await _getBridgesPointListUseCase.Handle(GetBridgesPointListUseCaseRequest.CreateAllBridgesPointsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{bridgespointId}")]
        public async Task<ActionResult> GetBridgesPoint(long bridgespointId)
        {
            var presenter = new BridgesPointListPresenter();
            await _getBridgesPointListUseCase.Handle(GetBridgesPointListUseCaseRequest.CreateBridgesPointRequest(bridgespointId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("crossriver/{crossriver}")]
        public async Task<ActionResult> GetCrossRiverBridgesPoints(string crossriver)
        {
            var presenter = new BridgesPointListPresenter();
            await _getBridgesPointListUseCase.Handle(GetBridgesPointListUseCaseRequest.CreateBridgesPointsRequest(crossriver), presenter);
            return presenter.ContentResult;
        }
    }
}
