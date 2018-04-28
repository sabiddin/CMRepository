using CM.Application.DataAccess;
using CM.Application.Interfaces;
using CM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public RoleService(IRoleRepository roleRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _roleRepository = roleRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public List<Role> GetRoles()
        {
            return _roleRepository.FindAll();
        }
    }
}
