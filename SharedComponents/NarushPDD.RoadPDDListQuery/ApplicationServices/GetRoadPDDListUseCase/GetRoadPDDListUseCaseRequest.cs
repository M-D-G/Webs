using NarushPDD.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NarushPDD.ApplicationServices.GetRoadPDDListUseCase
{
    public class GetRoadPDDListUseCaseRequest : IUseCaseRequest<GetRoadPDDListUseCaseResponse>
    {
        public string RecordedV { get; private set; }
        public long? RoadPDDId { get; private set; }

        private GetRoadPDDListUseCaseRequest()
        { }

        public static GetRoadPDDListUseCaseRequest CreateAllRoadPDDsRequest()
        {
            return new GetRoadPDDListUseCaseRequest();
        }

        public static GetRoadPDDListUseCaseRequest CreateRoadPDDRequest(long roadpddId)
        {
            return new GetRoadPDDListUseCaseRequest() { RoadPDDId = roadpddId };
        }
        public static GetRoadPDDListUseCaseRequest CreateRecordedVCriteriaRequest(string recordedv)
        {
            return new GetRoadPDDListUseCaseRequest() { RecordedV = recordedv };
        }
    }
}
