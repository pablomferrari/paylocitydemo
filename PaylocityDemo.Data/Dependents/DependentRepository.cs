using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Domain.Dependents
{
    public class DependentRepository : IDependentRepository
    {
        private readonly PaylocityContext _context;
        public DependentRepository(PaylocityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dependent>> UpsertAsync(ICollection<Dependent> dependents)
        {      
            await _context.AddRangeAsync(dependents.Where(x => x.Id == 0));
            _context.UpdateRange(dependents.Where(x => x.Id > 0));
            await _context.SaveChangesAsync();
            return dependents;
        }
    }
}
