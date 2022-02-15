using Microsoft.AspNetCore.Mvc;
using MrTomato.Data;
using MrTomato.DTOs;
using MrTomato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MrTomato.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository; 
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        //add login logout 

        // GET: api/<UserController>
       [HttpGet]
       public List<UserDto> GetUsers()
        {
            List<UserDto> response = _usersRepository.GetUsers();
            return response;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDto GetUserById(int id)
        {
            UserDto response = _usersRepository.GetUserById(id);
            return response;
        }

        // POST api/<UserController>
        [HttpPost]
        public UserDto CreateUser([FromBody] UserDto user)
        {
            UserDto response = _usersRepository.CreateUser(user);
            return response;
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public UserDto UpdateUser([FromBody] UserDto user)
        {
            UserDto response = _usersRepository.UpdateUser(user);
            return response;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public UserDto DeleteUser(int id)
        {
            UserDto response = _usersRepository.DeleteUser(id);
            return response;
        }
    }
}
