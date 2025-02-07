using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// Serviço para consulta de categorias da API. BBB
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var categoryRepository = new CategoryRepository();

            var categories = categoryRepository.GetAll();

            var response = new List<CategoryResponseDTO>();

            foreach (var category in categories)
            {
                response.Add(new CategoryResponseDTO
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return Ok(response);
        }
    }
}
