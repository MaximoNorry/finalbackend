namespace AlmacenMvc.Models
{
    public class Articulo
    {
        public int Id { get; set; }             
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
