using MrTomato.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Data
{
    public interface ICategoriesRepository
    {
        public CategoryDto GetCategoryById(int id);
        public List<CategoryDto> GetCategories();
        public CategoryDto CreateCategory(CategoryDto newCategory);
        public CategoryDto UpdateCategory(CategoryDto newCategory);
        public CategoryDto DeleteCategory(int userId);
    }
}
