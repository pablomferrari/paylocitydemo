using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityDemo.Business.Dependents
{
    public class DependentComponent : IDependentComponent
    {
        private readonly IMapper _mapper;
        private readonly IDependentRepository _dependentRepository;

        public DependentComponent(IDependentRepository dependentRepository, IMapper mapper)
        {
            _dependentRepository = dependentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Dependent>> UpsertAsync(ICollection<Dependent> dependents)
        {
            var domain = dependents.Select(x => _mapper.Map<Domain.Models.Dependent>(x));
            var result =  await _dependentRepository.UpsertAsync(domain.ToList());
            return result.Select(x => _mapper.Map<Dependent>(x));
        }
    }
}
