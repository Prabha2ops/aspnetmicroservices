using Employee_Info.API.Data;
using Employee_Info.API.Entities;
using Couchbase;
using Couchbase.KeyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Couchbase.Search;
using Couchbase.Search.Queries.Simple;
using Couchbase.Search.Queries.Compound;

namespace Employee_Info.API.Repositories
{
    public interface IPersonRepositary
    {

        Task<IEnumerable<Person>> GetPersons();
        
        Task<Person> GetPerson(string email_id);
        
        Task<IEnumerable<Person>> GetPersonByLast_Name(string last_name);

        Task<IEnumerable<Person>> GetPersonByFirst_Name(string first_name);

        Task CreatePerson(Person person);

        Task<bool> UpdatePerson(Person person);
        
        Task<bool> DeletePerson(string email_id);
    }
}

