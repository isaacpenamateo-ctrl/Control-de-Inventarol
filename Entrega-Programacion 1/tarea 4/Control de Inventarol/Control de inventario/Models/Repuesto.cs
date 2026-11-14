using System;
using System.Collections.Generic;
using System.Text;

namespace Control_de_Inventarol.Control_de_inventario.Models
{
    public class Repuesto
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public Repuesto(string codigo, string nombre, string marca,
    string categoria, decimal precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Marca = marca;
            Categoria = categoria;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
