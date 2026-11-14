using Control_de_Inventarol.Control_de_inventario.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_de_Inventarol.metodos_de_gestion
{
    public class Gestion
    {
        private List<Repuesto> listaRepuestos = new List<Repuesto>();


        public void RegistrarRepuesto(Repuesto nuevoRepuesto)
        {
            listaRepuestos.Add(nuevoRepuesto);
            Console.WriteLine("Total de repuestos: " + listaRepuestos.Count);
        }
        public void MostrarRepuesto()
        {
            if (listaRepuestos.Count == 0)
            {
                Console.WriteLine("No hay repuestos registrado");

            }
            else
                foreach (Repuesto repuesto in listaRepuestos)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Código: " + repuesto.Codigo);
                    Console.WriteLine("Nombre: " + repuesto.Nombre);
                    Console.WriteLine("Marca: " + repuesto.Marca);
                    Console.WriteLine("Categoría: " + repuesto.Categoria);
                    Console.WriteLine("Precio: " + repuesto.Precio);
                    Console.WriteLine("Cantidad: " + repuesto.Cantidad);
                    Console.WriteLine("--------------------------");
                }


        }

        public void BuscarRepuesto(string codigoBuscado)
        {
            bool encontrado = false;

            foreach (Repuesto repuesto in listaRepuestos)
            {
                if (repuesto.Codigo == codigoBuscado)
                {
                    Console.WriteLine("Código: " + repuesto.Codigo);
                    Console.WriteLine("Nombre: " + repuesto.Nombre);
                    Console.WriteLine("Marca: " + repuesto.Marca);
                    Console.WriteLine("Categoría: " + repuesto.Categoria);
                    Console.WriteLine("Precio: " + repuesto.Precio);
                    Console.WriteLine("Cantidad: " + repuesto.Cantidad);

                    encontrado = true;
                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("Repuesto no encontrado.");
            }
        }
        public void ActualizarRepuesto(string codigoRepuesto, int NuevaCantidad)
        {
            bool encontrado = false;

            foreach (Repuesto repuesto in listaRepuestos)
            {
                if (repuesto.Codigo == codigoRepuesto)
                {
                    repuesto.Cantidad = NuevaCantidad;
                    encontrado = true;

                    Console.WriteLine("Cantidad actualizada: " + repuesto.Cantidad);
                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("Repuesto no encontrado.");
            }
        }
        public void EliminarRepuesto(string codigoBuscado)
        {
            Repuesto repuestoEliminar = null;

            foreach (Repuesto repuesto in listaRepuestos)
            {
                if (repuesto.Codigo == codigoBuscado)
                {
                    repuestoEliminar = repuesto;
                    break;
                }
            }
            if (repuestoEliminar != null)
            {
                listaRepuestos.Remove(repuestoEliminar);
                Console.WriteLine("Repuesto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Repuesto no encontrado.");
            }
        }

    }




}


