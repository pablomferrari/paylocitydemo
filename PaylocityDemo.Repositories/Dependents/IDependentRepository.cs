using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Repositories.Dependents
{
    public interface IDependentRepository
    {
        Task<int> AddDependentAsync(Dependent dependent);
    }
}
