using Control_de_Inventarol.Control_de_inventario.Models;
using Control_de_Inventarol.Control_de_inventario.services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
namespace Control_de_Inventarol.metodos_de_gestion
{
    public class Gestion
    {
        private readonly ConexionDB conexionDB = new ConexionDB();
        private List<Repuesto> listaRepuestos = new List<Repuesto>();


        public void RegistrarRepuesto(Repuesto nuevoRepuesto)
        {
            using (SqlConnection conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"INSERT INTO Repuestos
        (Codigo, Nombre, Marca, Categoria, Precio, Cantidad)
        VALUES
        (@Codigo, @Nombre, @Marca, @Categoria, @Precio, @Cantidad)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", nuevoRepuesto.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", nuevoRepuesto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", nuevoRepuesto.Marca);
                    comando.Parameters.AddWithValue("@Categoria", nuevoRepuesto.Categoria);
                    comando.Parameters.AddWithValue("@Precio", nuevoRepuesto.Precio);
                    comando.Parameters.AddWithValue("@Cantidad", nuevoRepuesto.Cantidad);

                    comando.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Repuesto guardado correctamente ");
        }
        public void MostrarRepuesto()
        {
            using (SqlConnection conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT * FROM Repuestos";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (!lector.HasRows)
                        {
                            Console.WriteLine("No hay repuestos registrados.");
                        }
                        else
                        {
                            while (lector.Read())
                            {
                                Console.WriteLine("----------------------------");
                                Console.WriteLine("Código: " + lector["Codigo"]);
                                Console.WriteLine("Nombre: " + lector["Nombre"]);
                                Console.WriteLine("Marca: " + lector["Marca"]);
                                Console.WriteLine("Categoría: " + lector["Categoria"]);
                                Console.WriteLine("Precio: " + lector["Precio"]);
                                Console.WriteLine("Cantidad: " + lector["Cantidad"]);
                                Console.WriteLine("----------------------------");
                            }
                        }
                    }
                }
            }
        }

        public void BuscarRepuesto(string codigoBuscado)
        {
            using (SqlConnection conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT * FROM Repuestos WHERE Codigo = @Codigo";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", codigoBuscado);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Código: " + lector["Codigo"]);
                            Console.WriteLine("Nombre: " + lector["Nombre"]);
                            Console.WriteLine("Marca: " + lector["Marca"]);
                            Console.WriteLine("Categoría: " + lector["Categoria"]);
                            Console.WriteLine("Precio: " + lector["Precio"]);
                            Console.WriteLine("Cantidad: " + lector["Cantidad"]);
                            Console.WriteLine("----------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Repuesto no encontrado.");
                        }
                    }
                }
            }
        }
        public void ActualizarRepuesto(string codigoRepuesto, int NuevaCantidad)
        {
            using (SqlConnection conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"UPDATE Repuestos
                            SET Cantidad = @Cantidad
                            WHERE Codigo = @Codigo";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Cantidad", NuevaCantidad);
                    comando.Parameters.AddWithValue("@Codigo", codigoRepuesto);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("Cantidad actualizada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Repuesto no encontrado.");
                    }
                }
            }
        }
        public void EliminarRepuesto(string codigoBuscado)
        {
            using (SqlConnection conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "DELETE FROM Repuestos WHERE Codigo = @Codigo";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", codigoBuscado);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("Repuesto eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Repuesto no encontrado.");
                    }
                }
            }
        }

    }




}


