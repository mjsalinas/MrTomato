using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Level { get; set; }
        public int RoleId { get; set; }
    }
}
