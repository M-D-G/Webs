using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NarushPDD.DomainObjects.Ports
{
    public interface IReadOnlyRoadPDDRepository
    {
        Task<RoadPDD> GetRoadPDD(long id);

        Task<IEnumerable<RoadPDD>> GetAllRoadPDDs();

        Task<IEnumerable<RoadPDD>> QueryRoadPDDs(ICriteria<RoadPDD> criteria);

    }

    public interface IRoadPDDRepository
    {
        Task AddRoadPDD(RoadPDD roadpdd);

        Task RemoveRoadPDD(RoadPDD roadpdd);

        Task UpdateRoadPDD(RoadPDD roadpdd);
    }
}
