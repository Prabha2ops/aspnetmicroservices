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
using Microsoft.Extensions.Logging;
using Couchbase.Query;
using System.Collections;

namespace Employee_Info.API.Repositories
{
    public class PersonRepositary : IPersonRepositary, IDisposable
    {
        private readonly IEmployeeContext _EmployeeContext;

        public PersonRepositary(IEmployeeContext EmployeeContext)
        {
            _EmployeeContext = EmployeeContext ?? throw new ArgumentNullException(nameof(EmployeeContext));
        }


        public async Task<(IEnumerable<Person>, string[])> GetPerson(string search_email_id)
        {
            var query = "SELECT id,employee_id,first_name,last_name,mobile_no,email_id,org_unit,org_team,org_role,location" +
                        " FROM `master-data`.`inventory`.`persons`" +
                        " WHERE email_id = $email_id";
                        
            //if (search_email_id != null)
            //{

              //  query += " WHERE email_id LIKE $1";
                
           // }


            var personResult = await _EmployeeContext.Cluster.QueryAsync<Person>(query, options => options.Parameter("email_id", search_email_id));

            var q = await personResult.Rows.ToListAsync();

            var context = new string[]
            {
                $"N1QL query - scoped to inventory: {query}; -- {search_email_id}"
            };

            return (q, context);
            
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
    

