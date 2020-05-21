using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NarushPDD.ApplicationServices.Repositories
{
    public class InMemoryRoadPDDRepository : IReadOnlyRoadPDDRepository,
                                           IRoadPDDRepository 
    {
        private readonly List<RoadPDD> _roadpdds = new List<RoadPDD>();

        public InMemoryRoadPDDRepository(IEnumerable<RoadPDD> roadpdds = null)
        {
            if (roadpdds != null)
            {
                _roadpdds.AddRange(roadpdds);
            }
        }

        public Task AddRoadPDD(RoadPDD roadpdd)
        {
            _roadpdds.Add(roadpdd);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<RoadPDD>> GetAllRoadPDDs()
        {
            return Task.FromResult(_roadpdds.AsEnumerable());
        }

        public Task<RoadPDD> GetRoadPDD(long id)
        {
            return Task.FromResult(_roadpdds.Where(rp => rp.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<RoadPDD>> QueryRoadPDDs(ICriteria<RoadPDD> criteria)
        {
            return Task.FromResult(_roadpdds.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveRoadPDD(RoadPDD roadpdd)
        {
            _roadpdds.Remove(roadpdd);
            return Task.CompletedTask;
        }

        public Task UpdateRoadPDD(RoadPDD roadpdd)
        {
            var foundRoadPDD = GetRoadPDD(roadpdd.Id).Result;
            if (foundRoadPDD == null)
            {
                AddRoadPDD(roadpdd);
            }
            else
            {
                if (foundRoadPDD != roadpdd)
                {
                    _roadpdds.Remove(foundRoadPDD);
                    _roadpdds.Add(roadpdd);
                }
            }
            return Task.CompletedTask;
        }
    }
}
