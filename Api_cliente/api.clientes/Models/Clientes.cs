namespace api.clientes.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Idciudad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public int Email { get; set; }
        public int Fechanacimiento { get; set; }
        public int Nacionalidad { get; set; }

    }
    public class Ciudad
    {
        public int Id { get; set; }
        public string ciudad { get; set; }
        public string Estado { get; set; }

    }
}
