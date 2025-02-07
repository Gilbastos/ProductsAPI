using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados para cadastrar ou atualizar um produto da API
    /// </summary>
    public class ProductRequestDTO
    {
        [MinLength(8, ErrorMessage = "Deve ter, no mínimo, {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Deve ter, no máximo, {1} caracteres")]
        [Required(ErrorMessage = "Favor informar o nome do produto.")]
        public string? Name { get; set; }


        [Range(0.01, 999999, ErrorMessage = "Favor informar preços entre {1} e {2}")]
        [Required(ErrorMessage = "Favor informar o preço do produto.")]
        public decimal? Price { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Favor informar preços entre {1} e {2}")]
        [Required(ErrorMessage = "Favor informar a quantidade do produto.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Favor informar a categoria do produto.")]
        public Guid? CategoryId { get; set; }
    }
}