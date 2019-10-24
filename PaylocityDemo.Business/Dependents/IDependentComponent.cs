using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaylocityDemo.Business.Dependents
{
    public interface IDependentComponent
    {
        Task<IEnumerable<Dependent>> UpsertAsync(ICollection<Dependent> dependents);
    }
}
