namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados para retornar uma consulta de categorias da API
    /// </summary>
    public class CategoryResponseDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
