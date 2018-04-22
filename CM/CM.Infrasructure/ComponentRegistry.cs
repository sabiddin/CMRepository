using CM.Application.Interfaces;
using CM.Services;
using StructureMap;

namespace CM.Infrasructure
{
    public class ComponentRegistry : Registry
    {
        public ComponentRegistry()
        {
            Scan(s => {
                s.Assembly("CM.Data");
                s.Assembly("CM.Services");
                s.IncludeNamespace("CM.Application.Interfaces");
                s.IncludeNamespace("CM.Services");
                s.WithDefaultConventions();
            });
            Policies.SetAllProperties(p => 
            {
                p.WithAnyTypeFromNamespace("CM.Application.Interfaces");
                p.WithAnyTypeFromNamespace("CM.Services");
            });
            For<IUserService>().Use<UserService>();
        }
    }
}
