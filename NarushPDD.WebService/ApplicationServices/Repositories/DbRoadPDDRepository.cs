using NarushPDD.ApplicationServices.Ports.Gateways.Database;
using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NarushPDD.ApplicationServices.Repositories
{
    public class DbRoadPDDRepository : IReadOnlyRoadPDDRepository,
                                     IRoadPDDRepository
    {
        private readonly IPDDDatabaseGateway _databaseGateway;

        public DbRoadPDDRepository(IPDDDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<RoadPDD> GetRoadPDD(long id)
            => await _databaseGateway.GetRoadPDD(id);

        public async Task<IEnumerable<RoadPDD>> GetAllRoadPDDs()
            => await _databaseGateway.GetAllRoadPDDs();

        public async Task<IEnumerable<RoadPDD>> QueryRoadPDDs(ICriteria<RoadPDD> criteria)
            => await _databaseGateway.QueryRoadPDDs(criteria.Filter);

        public async Task AddRoadPDD(RoadPDD roadpdd)
            => await _databaseGateway.AddRoadPDD(roadpdd);

        public async Task RemoveRoadPDD(RoadPDD roadpdd)
            => await _databaseGateway.RemoveRoadPDD(roadpdd);

        public async Task UpdateRoadPDD(RoadPDD roadpdd)
            => await _databaseGateway.UpdateRoadPDD(roadpdd);
    }
}
