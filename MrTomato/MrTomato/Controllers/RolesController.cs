using Microsoft.AspNetCore.Mvc;
using MrTomato.Data;
using MrTomato.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MrTomato.Controllers
{
    [Route("roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public List<RoleDto> GetUsers()
        {
            List<RoleDto> response = _rolesRepository.GetRoles();
            return response;
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public RoleDto GetRoleById(int id)
        {
            RoleDto response = _rolesRepository.GetRoleById(id);
            return response;
        }

        // POST api/<RolesController>
        [HttpPost]
        public RoleDto CreateRole([FromBody] RoleDto role)
        {
            RoleDto response = _rolesRepository.CreateRole(role);
            return response;
        }

        // PUT api/<RolesController>/5
        [HttpPut]
        public RoleDto UpdateRole([FromBody] RoleDto role)
        {
            RoleDto response = _rolesRepository.UpdateRole(role);
            return response;
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public RoleDto DeleteRole(int id)
        {
            RoleDto response = _rolesRepository.DeleteRole(id);
            return response;
        }
    }
}
