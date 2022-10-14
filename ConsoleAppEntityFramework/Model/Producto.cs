namespace ConsoleAppEntityFramework.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public string UrlImagen { get; set; }

        //Fk
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }





        public List<DetalleVenta> DetalleVenta { get; set; }
    }
}
