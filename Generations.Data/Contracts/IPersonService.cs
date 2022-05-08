using Generations.ObjectModel;
using Generations.ObjectModel.Search;

namespace Generations.Data.Contracts
{
    public interface IPersonService : IService<Person, PersonSearch>
    { }
}