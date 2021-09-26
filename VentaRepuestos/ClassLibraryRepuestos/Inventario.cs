using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryRepuestos
{
    public class Inventario
    {
        List<Repuesto> repuestos = new List<Repuesto>();
        public void AgregarRepuesto(int codigoRepuesto, string nombreRepuesto, decimal precio, int stock, int codigoCategoria, string nombreCategoria) {

            Repuesto repuesto = new() 
            { 
                Codigo = codigoRepuesto,
                Nombre = nombreRepuesto,
                Precio = precio,
                Stock = stock,
                Categoria = new Categoria() {
                    Codigo = codigoCategoria,
                    Nombre = nombreCategoria
                },
            };

            repuestos.Add(repuesto);

        }

        public void MostrarRepuestos()
        {
            foreach (Repuesto repuesto in repuestos)
            {
                Console.WriteLine(repuesto.Nombre);
            }
        }
        public bool ExisteCodigoGuardado(int codigoRepuesto)
        {
            bool existeRepuesto = repuestos.Any(x => x.Codigo == codigoRepuesto);
            return existeRepuesto;
        }

        public Repuesto ObtenerRepuesto(int codigoRepuesto) 
        {
            var repuesto = repuestos.FirstOrDefault(x => x.Codigo == codigoRepuesto);
            return repuesto;
        }

        public bool ExisteStock(int codigoRepuesto)
        {
            bool existeStock = repuestos.Any(x => x.Codigo == codigoRepuesto && x.Stock != 0);
            return existeStock;
        }

        public void EliminarRepuesto(int codigoRepuesto)
        {
            var repuestoAEliminar = repuestos.Single(r => r.Codigo == codigoRepuesto);
            repuestos.Remove(repuestoAEliminar);
        }

        public void ModificarPrecio(int codigoRepuesto, decimal precioNuevo)
        {
            var repuestoAModificar = repuestos.Single(r => r.Codigo == codigoRepuesto);
            repuestoAModificar.Precio = precioNuevo;
            
        }
        public void AgregarStock(int codigoRepuesto, int stockAgregar)
        {
            var repuestoAModificar = repuestos.Single(r => r.Codigo == codigoRepuesto);
            repuestoAModificar.Stock += stockAgregar;
        }

        public void QuitarStock(int codigoRepuesto, int stockReducir)
        {
            var repuestoAModificar = repuestos.Single(r => r.Codigo == codigoRepuesto);
            repuestoAModificar.Stock -= stockReducir;
        }
        public void ListarRepuestosPorCategoria(int categoria)
        {
            List<Repuesto> repuestosPorCategoria = repuestos.FindAll(x => x.Categoria.Codigo == categoria);
            if (repuestosPorCategoria.Count() == 0)
            {
                Console.WriteLine($"No existen repuestos para la Categoría de código {categoria}.");
            } else {
                foreach (Repuesto repuesto in repuestosPorCategoria)
                {
                    Console.WriteLine($"Código Repuesto: {repuesto.Codigo}\n" +
                                      $"Nombre: {repuesto.Nombre}\n" +
                                      $"Precio: ${repuesto.Precio}\n" +
                                      $"Stock: {repuesto.Stock} unidades\n" +
                                      $"Código Categoría: {repuesto.Categoria.Codigo}\n" +
                                      $"Nombre Categoría: {repuesto.Categoria.Nombre}\n");
                }
            }
         
        }
    }
}
