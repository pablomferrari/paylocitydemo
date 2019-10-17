using AutoMapper;

namespace PaylocityDemo.Business.Bootstrap
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
                cfg.AddProfile<DependentProfile>();
            });
            var mapper = config.CreateMapper();
        }
    }
}
