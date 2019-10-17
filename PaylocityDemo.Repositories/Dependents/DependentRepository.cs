using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Repositories.Dependents
{
    public class DependentRepository : IDependentRepository
    {
        private readonly PaylocityContext _context;
        public DependentRepository(PaylocityContext context)
        {
            _context = context;
        }
        public async Task<int> AddDependentAsync(Dependent dependent)
        {
            var result = await _context.AddAsync<Dependent>(dependent);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
