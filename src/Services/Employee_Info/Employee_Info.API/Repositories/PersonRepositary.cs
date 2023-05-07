using Employee_Info.API.Data;
using Employee_Info.API.Entities;
using Couchbase;
using Couchbase.KeyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Search;
using Couchbase.Search.Queries.Simple;
using Couchbase.Search.Queries.Compound;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using static Couchbase.Core.Diagnostics.Tracing.OuterRequestSpans.ManagerSpan;


namespace Employee_Info.API.Repositories
{
    public class PersonRepositary : IPersonRepositary, IDisposable
    {
        private readonly IEmployeeContext _EmployeeContext;

        public PersonRepositary(IEmployeeContext EmployeeContext)
        {
            _EmployeeContext = EmployeeContext ?? throw new ArgumentNullException(nameof(EmployeeContext));
        }



        public async Task<IEnumerable<Person>> GetPersons()
        {
            var query = "SELECT * FROM `master-data`.`inventory`.`persons` WHERE type = 'BSH.OPS.Tools.MasterData.Person'";
            var queryresult = await _EmployeeContext.Cluster.QueryAsync<Person>(query);
            return (IEnumerable<Person>)queryresult.Rows;
        }

        Task<Person> IPersonRepositary.GetPerson(string email_id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Person>> IPersonRepositary.GetPersonByLast_Name(string last_name)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Person>> IPersonRepositary.GetPersonByFirst_Name(string first_name)
        {
            throw new NotImplementedException();
        }

        Task IPersonRepositary.CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPersonRepositary.DeletePerson(string email_id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPersonRepositary.UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
    

