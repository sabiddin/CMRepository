using CM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetRoles();
    }
}
