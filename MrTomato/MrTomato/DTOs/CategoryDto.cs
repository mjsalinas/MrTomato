using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Level { get; set; }
        public int RoleId { get; set; }
        public string ErrorMessage { get; set; }

    }
}
