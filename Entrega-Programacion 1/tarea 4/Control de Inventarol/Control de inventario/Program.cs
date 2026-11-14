using Control_de_Inventarol.Control_de_inventario.Models;
using Control_de_Inventarol.metodos_de_gestion;
using Control_de_Inventarol.Control_de_inventario.services;
using Microsoft.Data.SqlClient;

ConexionDB conexionDB = new ConexionDB();

using (SqlConnection conexion = conexionDB.ObtenerConexion())
{
    conexion.Open();

    Console.WriteLine("Conexion exitosa con AutoRepuestoDB");

    
}

Gestion gestion = new Gestion();

try
{

    bool LaParita = true;
    Console.WriteLine("Bienvenidos a AutoRepuesto me chocaste");
    while (LaParita)
    {


        Console.WriteLine("----------------------------");
        Console.WriteLine("  Inventario de Respuestos ");
        Console.WriteLine("----------------------------");

        Console.WriteLine("1.Registrar Repuesto");
        Console.WriteLine("2.Mostrar todos los Repuestos ");
        Console.WriteLine("3.Buscar Repuesto");
        Console.WriteLine("4.Actualizar Cantidad de Repuesto");
        Console.WriteLine("5.Eliminar Repuesto");
        Console.WriteLine("6.Salir");

        int Option = Convert.ToInt32(Console.ReadLine());

        switch (Option)
        {
            case 1:
                {

                    Console.WriteLine("Escriba el codigo del repuesto");
                    string codigo = Console.ReadLine();

                    Console.WriteLine("Escriba el nombre del repuesto");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese su marca");
                    string marca = Console.ReadLine();

                    Console.WriteLine("Ingrese su categoria");
                    string categoria = Console.ReadLine();

                    Console.WriteLine("Ingrese el precio");
                    var precio = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Ingrese la cantidad del repuesto");
                    var cantidad = Convert.ToInt32(Console.ReadLine());
                    
                    Repuesto nuevoRepuesto = new Repuesto(
                    codigo,
                    nombre,
                    marca,
                    categoria,
                    precio,
                    cantidad

                    );
                    gestion.RegistrarRepuesto(nuevoRepuesto);

                    Console.WriteLine("Se guardo jevi en vd");

                    break;
                }
            case 2:
                {
                    gestion.MostrarRepuesto();


                    break;
                }
            case 3:
                {
                    Console.WriteLine("Ingrese el código del repuesto:");
                    string codigoBuscado = Console.ReadLine();
                    gestion.BuscarRepuesto(codigoBuscado);

                    break;
                }
            case 4:
                {
                    Console.WriteLine("Ingrese el código del repuesto:");
                    string codigoRepuesto = Console.ReadLine();

                    Console.WriteLine("Ingrese la nueva cantidad:");
                    int nuevaCantidad = Convert.ToInt32(Console.ReadLine());
                    
                    gestion.ActualizarRepuesto(codigoRepuesto, nuevaCantidad);

                    break;
                }

            case 5:
                {
                    Console.WriteLine("Ingrese el codigo de lo que desea eliminar");
                    string codigoBuscado = Console.ReadLine();
                    gestion.EliminarRepuesto(codigoBuscado);

                    break;
                }


            case 6:
                {
                    LaParita = false;
                    break;
                }
            default:

                Console.WriteLine("Ingrese una opcion valida por favor");

                break;



        }
    }



}
catch (Exception ex)
{
    Console.WriteLine("Ha ocurrido un error: " + ex.Message);
}