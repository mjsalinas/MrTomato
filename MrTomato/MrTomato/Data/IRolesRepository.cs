using MrTomato.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Data
{
    public interface IRolesRepository
    {
        public RoleDto GetRoleById(int id);
        public List<RoleDto> GetRoles();
        public RoleDto CreateRole(RoleDto newRole);
        public RoleDto UpdateRole(RoleDto newRole);
        public RoleDto DeleteRole(int roleId);
    }
}
