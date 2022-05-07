using Microsoft.Extensions.Configuration;

using Generations.Data.Contracts;
using Generations.ObjectModel;
using Generations.ObjectModel.Search;

namespace Generations.Data.Services
{
    public class PersonService : BaseService, IPersonService
    {
        public PersonService(IConfiguration configuration)
            : base(configuration)
        { }

        public override string TableName => "People";

        public Task<IEnumerable<Person>> AllAsync(string sort = "id", bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> AllAsync(string sort = "id", bool ascending = true, int page = 1, int pageSize = 100)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Person search)
        {
            throw new NotImplementedException();
        }

        public Task<Person> CreateAsync(Person model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> SearchAsync(PersonSearch search, string sort = "id", bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> SearchAsync(PersonSearch search, string sort = "id", bool ascending = true, int page = 1, int pageSize = 100)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Person model)
        {
            throw new NotImplementedException();
        }
    }
}