namespace AlmacenMvc.Dtos
{
    public class ArticuloDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
