using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NarushPDD.ApplicationServices.GetRoadPDDListUseCase
{
    public class RecordedVCriteria : ICriteria<RoadPDD>
    {
        public string RecordedV { get; }

        public RecordedVCriteria(string recordedv)
            => RecordedV = recordedv;

        public Expression<Func<RoadPDD, bool>> Filter
            => (rp => rp.RecordedV == RecordedV);
    }
}
