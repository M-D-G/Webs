using NarushPDD.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NarushPDD.ApplicationServices.Ports.Gateways.Database
{
    public interface IPDDDatabaseGateway
    {
        Task AddRoadPDD(RoadPDD roadpdd);

        Task RemoveRoadPDD(RoadPDD roadpdd);

        Task UpdateRoadPDD(RoadPDD roadpdd);

        Task<RoadPDD> GetRoadPDD(long id);

        Task<IEnumerable<RoadPDD>> GetAllRoadPDDs();

        Task<IEnumerable<RoadPDD>> QueryRoadPDDs(Expression<Func<RoadPDD, bool>> filter);

    }
}
