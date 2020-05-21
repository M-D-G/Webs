using NarushPDD.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using NarushPDD.ApplicationServices.Ports.Gateways.Database;

namespace NarushPDD.InfrastructureServices.Gateways.Database
{
    public class PDDEFSqliteGateway : IPDDDatabaseGateway
    {
        private readonly PDDContext _pddContext;

        public PDDEFSqliteGateway(PDDContext PDDContext)
            => _pddContext = PDDContext;

        public async Task<RoadPDD> GetRoadPDD(long id)
           => await _pddContext.RoadPDDs.Where(rp => rp.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<RoadPDD>> GetAllRoadPDDs()
            => await _pddContext.RoadPDDs.ToListAsync();
          
        public async Task<IEnumerable<RoadPDD>> QueryRoadPDDs(Expression<Func<RoadPDD, bool>> filter)
            => await _pddContext.RoadPDDs.Where(filter).ToListAsync();

        public async Task AddRoadPDD(RoadPDD roadpdd)
        {
            _pddContext.RoadPDDs.Add(roadpdd);
            await _pddContext.SaveChangesAsync();
        }

        public async Task UpdateRoadPDD(RoadPDD roadpdd)
        {
            _pddContext.Entry(roadpdd).State = EntityState.Modified;
            await _pddContext.SaveChangesAsync();
        }

        public async Task RemoveRoadPDD(RoadPDD roadpdd)
        {
            _pddContext.RoadPDDs.Remove(roadpdd);
            await _pddContext.SaveChangesAsync();
        }

    }
}
