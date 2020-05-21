using NarushPDD.ApplicationServices.GetRoadPDDListUseCase;
using System.Net;
using Newtonsoft.Json;
using NarushPDD.ApplicationServices.Ports;

namespace NarushPDD.InfrastructureServices.Presenters
{
    public class RoadPDDListPresenter : IOutputPort<GetRoadPDDListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RoadPDDListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetRoadPDDListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.RoadPDDs) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
