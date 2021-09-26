using System;

namespace ClassLibraryRepuestos
{
    public class Repuesto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; }
        public string ToString(Repuesto repuesto)
        {
            return "string de prueba";
        }
    }
}
