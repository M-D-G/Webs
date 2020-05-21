using NarushPDD.ApplicationServices.Ports.Cache;
using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using NarushPDD.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NarushPDD.ApplicationServices.Repositories
{
    public class CachedReadOnlyRoadPDDRepository : ReadOnlyRoadPDDRepositoryDecorator
    {
        private readonly IDomainObjectsCache<RoadPDD> _roadpddsCache;

        public CachedReadOnlyRoadPDDRepository(IReadOnlyRoadPDDRepository roadpddRepository, 
                                             IDomainObjectsCache<RoadPDD> roadpddsCache)
            : base(roadpddRepository)
            => _roadpddsCache = roadpddsCache;

        public async override Task<RoadPDD> GetRoadPDD(long id)
            => _roadpddsCache.GetObject(id) ?? await base.GetRoadPDD(id);

        public async override Task<IEnumerable<RoadPDD>> GetAllRoadPDDs()
            => _roadpddsCache.GetObjects() ?? await base.GetAllRoadPDDs();

        public async override Task<IEnumerable<RoadPDD>> QueryRoadPDDs(ICriteria<RoadPDD> criteria)
            => _roadpddsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryRoadPDDs(criteria);

    }
}
