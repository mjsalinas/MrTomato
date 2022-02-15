using MrTomato.DTOs;
using MrTomato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext dbContext;
        public UsersRepository(DataContext db)
        {
            dbContext = db;
        }

        
        public UserDto GetUserById(int id) {
            UserDto response = new UserDto();
            try
            {
                var user = dbContext.Users.FirstOrDefault(user => user.Id == id);
                response.Id = user.Id;
                response.Name = user.Name;
                response.LastName = user.LastName;
                response.Role = user.Role;
                response.Username = user.Username;
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                return response;
            }
        }
        public UserDto GetUserByUsername(string username)
        {
            UserDto response = new UserDto();
            var user = dbContext.Users.FirstOrDefault(user => user.Username == username);

            if(user == null)
            {
                response.ErrorMessage ="User Not Found";
            }
            else
            {
                response.Id = user.Id;
                response.Name = user.Name;
                response.LastName = user.LastName;
                response.Role = user.Role;
                response.Username = user.Username;
                response.Password = user.Password;
            }
          
                return response;
            
        }
        public List<UserDto> GetUsers()
        {
            List<UserDto> usersDto = new List<UserDto>();
            List<User> users = dbContext.Users.ToList();
            foreach (var user in users)
            {
                usersDto.Add(new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Role = user.Role,
                    Username = user.Username
                });
            }
            return usersDto;
        }

        public UserDto CreateUser(UserDto newUser)
        {
            User users = new User
            {
                Name = newUser.Name,
                LastName = newUser.LastName,
                Role = newUser.Role,
                Username = newUser.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password)
            };
            dbContext.Users.Add(users);
            dbContext.SaveChanges();
            return newUser;
        }

        public UserDto UpdateUser(UserDto newUser)
        {
            User existingUser = dbContext.Users.FirstOrDefault(user => user.Id == newUser.Id);
            if (existingUser == null)
            {
                return new UserDto
                {
                    ErrorMessage = "User does not exist, creating a new one."
                };
            }
            existingUser.Name = newUser.Name;
            existingUser.LastName = newUser.LastName;
            existingUser.Role = newUser.Role;
            existingUser.Username = newUser.Username;
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            dbContext.SaveChanges();
            return newUser;
        }

        public UserDto DeleteUser (int userId)
        {
            User existingUser = dbContext.Users.FirstOrDefault(user => user.Id == userId);
            dbContext.Remove(existingUser);
            dbContext.SaveChanges();
            return new UserDto();
        }
    }
}
