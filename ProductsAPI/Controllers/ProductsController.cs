using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Entities;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        /// <summary>
        /// Serviço para consulta de produtos na API.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var repository = new ProductRepository();
            var produtos = repository.GetAll();

            var response = new List<ProductResponseDTO>();

            foreach (var product in produtos) {
                response.Add(new ProductResponseDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantidade = product.Quantity,
                    CategoryId = product.CategoryId,

                });
            }

            return Ok(response);
        }

        /// <summary>
        /// Serviço para consulta de produtos na API, informando o Id.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var repository = new ProductRepository();
            var produto = repository.GetById(id);

            var response = new ProductResponseDTO
            {
                Id = produto.Id,
                Name = produto.Name,
                Price = produto.Price,
                Quantidade = produto.Quantity,

                CategoryId = produto.CategoryId,
            };

            return Ok(response);
        }

            /// <summary>
            /// Serviço para cadastro de produto da API.
            /// </summary>
            [HttpPost]
        public IActionResult Post([FromBody] ProductRequestDTO request)
        {
            var produto = new Product{ 
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,

                CategoryId = request.CategoryId,
            };

            var repository = new ProductRepository();
            repository.Add(produto);

            //Retornar um case de sucesso (200)
            return Ok(new { 
                Message = "Cadstrado com sucesso!",
                CreatedAt = DateTime.Now,
                ProductId = produto.Id,
            });
        }

        /// <summary>
        /// Serviço para atualização de produto na API.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductRequestDTO request)
        {
            var repository = new ProductRepository();
            var produto = repository.GetById(id);

            produto.Name = request.Name;
            produto.Price = request.Price;
            produto.Quantity = request.Quantity;
            produto.CategoryId = request.CategoryId;

            repository.Update(produto);

            //Retornar um case de sucesso (200)
            return Ok(new
            {
                Message = "Atualizado com sucesso!",
                CreatedAt = DateTime.Now,
                ProductId = produto.Id,
            });
        }

        /// <summary>
        /// Serviço para exclusão de produto na API
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var repository = new ProductRepository();
            var produto = repository.GetById(id);

            repository.Delete(produto);

            //Retornar um case de sucesso (200)
            return Ok(new
            {
                Message = "Excluído com sucesso!",
                CreatedAt = DateTime.Now,
                ProductId = produto.Id,
            });

        }
    }
}
