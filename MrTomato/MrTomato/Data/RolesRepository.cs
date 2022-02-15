using MrTomato.DTOs;
using MrTomato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Data
{
    public class RolesRepository : IRolesRepository
    {
        private readonly DataContext dbContext;
        public RolesRepository(DataContext db)
        {
            dbContext = db;
        }

        public RoleDto GetRoleById(int id)
        {
            RoleDto response = new RoleDto();
            try
            {
                var role = dbContext.UserRoles.FirstOrDefault(role => role.Id == id);
                response.Id = role.Id;
                response.RoleName = role.RoleName;
                response.UserId = role.UserId;
                response.User = role.User;
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public List<RoleDto> GetRoles()
        {
            List<RoleDto> rolesDto = new List<RoleDto>();
            List<Role> roles = dbContext.UserRoles.ToList();
            foreach (var role in roles)
            {
                rolesDto.Add(new RoleDto
                {
                    Id = role.Id,
                    RoleName = role.RoleName,
                    UserId = role.UserId,
                    User = role.User
                });
            }
            return rolesDto;
        }

        public RoleDto CreateRole(RoleDto newRole)
        {
            Role roles = new Role
            {
                RoleName = newRole.RoleName,
                UserId = newRole.UserId,
                User = newRole.User
            };
            dbContext.UserRoles.Add(roles);
            dbContext.SaveChanges();
            return newRole;
        }

        public RoleDto UpdateRole(RoleDto newRole)
        {
            Role existingRole = dbContext.UserRoles.FirstOrDefault(role => role.Id == newRole.Id);
            if (existingRole == null)
            {
                return new RoleDto
                {
                    ErrorMessage = "Role does not exist, creating a new one."
                };
            }
            existingRole.RoleName = newRole.RoleName;
            existingRole.UserId = newRole.UserId;
            existingRole.User = newRole.User;
            dbContext.SaveChanges();
            return newRole;
        }

        public RoleDto DeleteRole(int roleId)
        {
            Role existingRole = dbContext.UserRoles.FirstOrDefault(role => role.Id == roleId);
            dbContext.Remove(existingRole);
            dbContext.SaveChanges();
            return new RoleDto();
        }
    }
}
