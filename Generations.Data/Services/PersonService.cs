using Generations.Data.Contracts;
using Generations.ObjectModel;

namespace Generations.Data.Services
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(ApplicationDbContext context)
            : base(context)
        { }
    }
}