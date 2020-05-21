using System.Threading.Tasks;
using System.Collections.Generic;
using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using NarushPDD.ApplicationServices.Ports;

namespace NarushPDD.ApplicationServices.GetRoadPDDListUseCase
{
    public class GetRoadPDDListUseCase : IGetRoadPDDListUseCase
    {
        private readonly IReadOnlyRoadPDDRepository _readOnlyRoadPDDRepository;

        public GetRoadPDDListUseCase(IReadOnlyRoadPDDRepository readOnlyRoadPDDRepository) 
            => _readOnlyRoadPDDRepository = readOnlyRoadPDDRepository;

        public async Task<bool> Handle(GetRoadPDDListUseCaseRequest request, IOutputPort<GetRoadPDDListUseCaseResponse> outputPort)
        {
            IEnumerable<RoadPDD> roadpdds = null;
            if (request.RoadPDDId != null)
            {
                var roadpdd = await _readOnlyRoadPDDRepository.GetRoadPDD(request.RoadPDDId.Value);
                roadpdds = (roadpdd != null) ? new List<RoadPDD>() { roadpdd } : new List<RoadPDD>();
                
            }
            else if (request.RecordedV != null)
            {
                roadpdds = await _readOnlyRoadPDDRepository.QueryRoadPDDs(new RecordedVCriteria(request.RecordedV));
            }
            else
            {
                roadpdds = await _readOnlyRoadPDDRepository.GetAllRoadPDDs();
            }
            outputPort.Handle(new GetRoadPDDListUseCaseResponse(roadpdds));
            return true;
        }
    }
}
