using NarushPDD.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using NarushPDD.ApplicationServices.GetRoadPDDListUseCase;
using System.Linq.Expressions;
using NarushPDD.ApplicationServices.Ports;
using NarushPDD.DomainObjects.Ports;
using NarushPDD.ApplicationServices.Repositories;

namespace NarushPDD.WebService.Core.Tests
{
    public class GetRoadPDDListUseCaseTest
    {
        private InMemoryRoadPDDRepository CreateRoadPDDtRepository()
        {
            var repo = new InMemoryRoadPDDRepository(new List<RoadPDD> {
                new RoadPDD { Id = 1, Data ="20.01.2013",  RecordedV="Общее количество зафиксированных нарушений - 5374",RegisteredV="Общее количество оформленных - 2440"},
                new RoadPDD { Id = 2, Data ="21.01.2013",RecordedV="Общее количество зафиксированных нарушений - 25312",RegisteredV="Общее количество оформленных - 1551"},
                new RoadPDD { Id = 3, Data ="22.01.2013", RecordedV="Общее количество зафиксированных нарушений - 29132", RegisteredV="Общее количество оформленных - 2672"}
            });
            return repo;
        }
        [Fact]
        public void TestGetAllRoadPDDs()
        {
            var useCase = new GetRoadPDDListUseCase(CreateRoadPDDtRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetRoadPDDListUseCaseRequest.CreateAllRoadPDDsRequest(), outputPort).Result);
            Assert.Equal<int>(3, outputPort.RoadPDDs.Count());
            Assert.Equal(new long[] { 1, 2, 3 }, outputPort.RoadPDDs.Select(rp => rp.Id));
        }

        [Fact]
        public void TestGetAllRoadPDDsFromEmptyRepository()
        {
            var useCase = new GetRoadPDDListUseCase(new InMemoryRoadPDDRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRoadPDDListUseCaseRequest.CreateAllRoadPDDsRequest(), outputPort).Result);
            Assert.Empty(outputPort.RoadPDDs);
        }

        [Fact]
        public void TestGetRoadPDD()
        {
            var useCase = new GetRoadPDDListUseCase(CreateRoadPDDtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRoadPDDListUseCaseRequest.CreateRoadPDDRequest(2), outputPort).Result);
            Assert.Single(outputPort.RoadPDDs, rp => 2 == rp.Id);
        }

        [Fact]
        public void TestTryGetNotExistingRoadPDD()
        {
            var useCase = new GetRoadPDDListUseCase(CreateRoadPDDtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRoadPDDListUseCaseRequest.CreateRoadPDDRequest(999), outputPort).Result);
            Assert.Empty(outputPort.RoadPDDs);
        }
      
    }

    class OutputPort : IOutputPort<GetRoadPDDListUseCaseResponse>
    {
        public IEnumerable<RoadPDD> RoadPDDs { get; private set; }

        public void Handle(GetRoadPDDListUseCaseResponse response)
        {
            RoadPDDs = response.RoadPDDs;
        }
    }
}
