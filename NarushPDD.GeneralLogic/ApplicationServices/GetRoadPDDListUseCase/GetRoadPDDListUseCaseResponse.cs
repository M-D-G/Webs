using NarushPDD.DomainObjects;
using NarushPDD.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NarushPDD.ApplicationServices.GetRoadPDDListUseCase
{
    public class GetRoadPDDListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<RoadPDD> RoadPDDs { get; }

        public GetRoadPDDListUseCaseResponse(IEnumerable<RoadPDD> roadpdds) => RoadPDDs = roadpdds;
    }
}
