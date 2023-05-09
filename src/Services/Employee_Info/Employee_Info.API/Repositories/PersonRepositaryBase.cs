using Couchbase;
using Couchbase.Query;
using Employee_Info.API.Data;
using Employee_Info.API.Entities;

namespace Employee_Info.API.Repositories
{
    public class PersonRepositaryBase
    {
        private readonly IEmployeeContext _EmployeeContext;

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public async Task<(IEnumerable<Person>, string[])> GetPerson(string search_email_id)
        {
            var query = "SELECT first_name, last_name FROM `master-data`.`inventory`.`persons`";

            if (search_email_id != null)
            {

                query += " WHERE email_id LIKE $1";

            }


            var personResult = await _EmployeeContext.Cluster.QueryAsync<Person>(query, options => options.Parameter(search_email_id));

            var q = await personResult.Rows.ToListAsync();

            var context = new string[] {
                $"N1QL query - scoped to inventory: {query}; -- {search_email_id}" };

            return (q, context);

        }
        public async Task<(IEnumerable<Person>, string[])> GetPersonByFirst_Name(string first_name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetPersonByLast_Name(string last_name)
        {
            throw new NotImplementedException();
        }
    }
}