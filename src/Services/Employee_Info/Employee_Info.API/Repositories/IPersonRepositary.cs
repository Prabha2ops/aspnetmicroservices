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
        Task<(IEnumerable<Person>, string[])> GetPerson(string search_email_id);

        Task<bool> CreatePerson(string create_id, string create_employee_id, 
            string create_first_name, string create_last_name, string create_mobile_no, string create_email_id, 
            string create_org_unit, string create_org_team, string create_org_role, string create_location);

        Task<bool> UpdatePerson(string update_id, string update_employee_id,
            string update_first_name, string update_last_name, string update_mobile_no, string update_email_id,
            string update_org_unit, string update_org_team, string update_org_role, string update_location);

        Task<bool> UpdatePersonName(string update_first_name, string update_last_name, string update_email_id);

        Task<bool> DeletePerson(string deleteby_email_id);
    }
}

