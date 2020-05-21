using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NarushPDD.DomainObjects.Repositories
{
    public abstract class ReadOnlyRoadPDDRepositoryDecorator : IReadOnlyRoadPDDRepository
    {
        private readonly IReadOnlyRoadPDDRepository _roadpddRepository;

        public ReadOnlyRoadPDDRepositoryDecorator(IReadOnlyRoadPDDRepository roadpddRepository)
        {
            _roadpddRepository = roadpddRepository;
        }

        public virtual async Task<IEnumerable<RoadPDD>> GetAllRoadPDDs()
        {
            return await _roadpddRepository?.GetAllRoadPDDs();
        }

        public virtual async Task<RoadPDD> GetRoadPDD(long id)
        {
            return await _roadpddRepository?.GetRoadPDD(id);
        }

        public virtual async Task<IEnumerable<RoadPDD>> QueryRoadPDDs(ICriteria<RoadPDD> criteria)
        {
            return await _roadpddRepository?.QueryRoadPDDs(criteria);
        }
    }
}
