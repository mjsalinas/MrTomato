using MrTomato.DTOs;
using MrTomato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext dbContext;
        public CategoriesRepository(DataContext db)
        {
            dbContext = db;
        }
        public CategoryDto GetCategoryById(int id)
        {
            CategoryDto response = new CategoryDto();
            try
            {
                var category = dbContext.Categories.FirstOrDefault(category => category.Id == id);
                response.Id = category.Id;
                response.CategoryName = category.CategoryName;
                response.Level = category.Level;
                response.RoleId = category.RoleId;
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public List<CategoryDto> GetCategories()
        {
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            List<Category> categories = dbContext.Categories.ToList();
            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Level = category.Level,
                    RoleId = category.RoleId
                });
            }
            return categoriesDto;
        }
        public CategoryDto CreateCategory(CategoryDto newCategory)
        {
            Category category = new Category
            {
                CategoryName = newCategory.CategoryName,
                Level = newCategory.Level,
                RoleId = newCategory.RoleId
            };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return newCategory;
        }

        public CategoryDto UpdateCategory(CategoryDto newCategory)
        {
            Category existingCategory = dbContext.Categories.FirstOrDefault(category => category.Id == newCategory.Id);
            if (existingCategory == null)
            {
                return new CategoryDto
                {
                    ErrorMessage = "Category does not exist, creating a new one."
                };
            }
            existingCategory.CategoryName = newCategory.CategoryName;
            existingCategory.Level = newCategory.Level;
            existingCategory.RoleId = newCategory.RoleId;
            dbContext.SaveChanges();
            return newCategory;
        }

        public CategoryDto DeleteCategory(int categoryId)
        {
            Category existingCategory = dbContext.Categories.FirstOrDefault(category => category.Id == categoryId);
            dbContext.Remove(existingCategory);
            dbContext.SaveChanges();
            return new CategoryDto();
        }

    }
}
