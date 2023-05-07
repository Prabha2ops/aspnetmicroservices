using Employee_Info.API.Entities;
using Couchbase;
using Couchbase.KeyValue;
using Swashbuckle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Info.API.Data
{
    public interface IEmployeeContext
    {
        ICluster Cluster { get; }
        IBucket MasterDataBucket { get; }
        ICouchbaseCollection PersonsCollection { get; }

     
    }
}
