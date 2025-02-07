namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados para retornar uma consulta de produtos da API
    /// </summary>
    public class ProductResponseDTO
    {
        public Guid? Id{ get; set; }

        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get { return Price * Quantidade; } }

        public Guid? CategoryId { get; set; }
    }
}
