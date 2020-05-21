using NarushPDD.ApplicationServices.Ports.Cache;
using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NarushPDD.InfrastructureServices.Repositories
{
    public class NetworkRoadPDDRepository : NetworkRepositoryBase, IReadOnlyRoadPDDRepository
    {
        private readonly IDomainObjectsCache<RoadPDD> _roadpddCache;

        public NetworkRoadPDDRepository(string host, ushort port, bool useTls, IDomainObjectsCache<RoadPDD> roadpddCache)
            : base(host, port, useTls)
            => _roadpddCache = roadpddCache;

        public async Task<RoadPDD> GetRoadPDD(long id)
            => CacheAndReturn(await ExecuteHttpRequest<RoadPDD>($"roadpdds/{id}"));

        public async Task<IEnumerable<RoadPDD>> GetAllRoadPDDs()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<RoadPDD>>($"roadpdds"), allObjects: true);

        public async Task<IEnumerable<RoadPDD>> QueryRoadPDDs(ICriteria<RoadPDD> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<RoadPDD>>($"roadpdds"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<RoadPDD> CacheAndReturn(IEnumerable<RoadPDD> roadpdds, bool allObjects = false)
        {
            if (allObjects)
            {
                _roadpddCache.ClearCache();
            }
            _roadpddCache.UpdateObjects(roadpdds, DateTime.Now.AddDays(1), allObjects);
            return roadpdds;
        }

        private RoadPDD CacheAndReturn(RoadPDD roadpdd)
        {
            _roadpddCache.UpdateObject(roadpdd, DateTime.Now.AddDays(1));
            return roadpdd;
        }
    }
}
