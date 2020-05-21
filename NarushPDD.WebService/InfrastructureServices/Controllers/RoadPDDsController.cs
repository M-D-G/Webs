using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NarushPDD.DomainObjects;
using NarushPDD.ApplicationServices.GetRoadPDDListUseCase;
using NarushPDD.InfrastructureServices.Presenters;

namespace NarushPDD.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoadPDDsController : ControllerBase
    {
        private readonly ILogger<RoadPDDsController> _logger;
        private readonly IGetRoadPDDListUseCase _getRoadPDDListUseCase;

        public RoadPDDsController(ILogger<RoadPDDsController> logger,
                                IGetRoadPDDListUseCase getRoadPDDListUseCase)
        {
            _logger = logger;
            _getRoadPDDListUseCase = getRoadPDDListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoadPDDs()
        {
            var presenter = new RoadPDDListPresenter();
            await _getRoadPDDListUseCase.Handle(GetRoadPDDListUseCaseRequest.CreateAllRoadPDDsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{roadpddId}")]
        public async Task<ActionResult> GetRoadPDD(long roadpddId)
        {
            var presenter = new RoadPDDListPresenter();
            await _getRoadPDDListUseCase.Handle(GetRoadPDDListUseCaseRequest.CreateRoadPDDRequest(roadpddId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("roadpdd/{recordedv}")]
        public async Task<ActionResult> GetRecordedVRoadPDDs(string recordedv)
        {
            var presenter = new RoadPDDListPresenter();
            await _getRoadPDDListUseCase.Handle(GetRoadPDDListUseCaseRequest.CreateRecordedVCriteriaRequest(recordedv), presenter);
            return presenter.ContentResult;
        }
    }
}
