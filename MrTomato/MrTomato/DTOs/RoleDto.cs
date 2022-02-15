using MrTomato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string ErrorMessage { get; set; }

    }
}
