using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Domain.Dependents
{
    public interface IDependentRepository
    {
        Task<IEnumerable<Dependent>> UpsertAsync(ICollection<Domain.Models.Dependent> dependents);
    }
}
