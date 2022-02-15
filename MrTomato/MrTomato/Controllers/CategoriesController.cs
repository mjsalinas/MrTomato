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
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public List<CategoryDto> GetCategories()
        {
            List<CategoryDto> response = _categoriesRepository.GetCategories();
            return response;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDto GetCategoryById(int id)
        {
            CategoryDto response = _categoriesRepository.GetCategoryById(id);
            return response;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public CategoryDto CreateCategory([FromBody] CategoryDto category)
        {
            CategoryDto response = _categoriesRepository.CreateCategory(category);
            return response;
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public CategoryDto UpdateCategory([FromBody] CategoryDto category)
        {
            CategoryDto response = _categoriesRepository.UpdateCategory(category);
            return response;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public CategoryDto DeleteCategory(int id)
        {
            CategoryDto response = _categoriesRepository.DeleteCategory(id);
            return response;
        }
    }
}
