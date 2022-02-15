using MrTomato.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Data
{
    public interface IUsersRepository
    {
        public UserDto GetUserById(int id);
        public UserDto GetUserByUsername(string username);
        public List<UserDto> GetUsers();
        public UserDto CreateUser(UserDto newUser);
        public UserDto UpdateUser(UserDto newUser);
        public UserDto DeleteUser(int userId);

    }
}
