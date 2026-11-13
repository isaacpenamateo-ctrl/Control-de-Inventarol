
using System.Linq.Expressions;

Dictionary<string, int> inventario = new Dictionary<string, int>();

Dictionary<string, string> nombres = new Dictionary<string, string>();

Dictionary<string, string> marcas = new Dictionary<string, string>();

Dictionary<string, string> categorias = new Dictionary<string, string>();

Dictionary<string, decimal> precios = new Dictionary<string, decimal>();
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

                    nombres.Add(codigo, nombre);

                    Console.WriteLine("Ingrese su marca");
                    string marca = Console.ReadLine();

                    marcas.Add(codigo, marca);

                    Console.WriteLine("Ingrese su categoria");
                    string categoria = Console.ReadLine();

                    categorias.Add(codigo, categoria);

                    Console.WriteLine("Ingrese el precio");
                    var precio = Convert.ToDecimal(Console.ReadLine());

                    precios.Add(codigo, precio);

                    Console.WriteLine("Ingrese la cantidad del repuesto");
                    var cantidad = Convert.ToInt32(Console.ReadLine());

                    inventario.Add(codigo, cantidad);

                    Console.WriteLine("Se guardo jevi en vd");

                    break;
                }

            case 2:
                {
                    foreach (var repuesto in nombres)
                    {

                        Console.WriteLine("Codigo: " + repuesto.Key);
                        Console.WriteLine("Nombre: " + repuesto.Value);
                        Console.WriteLine("Marca: " + marcas[repuesto.Key]);
                        Console.WriteLine("Categoria: " + categorias[repuesto.Key]);
                        Console.WriteLine("Precio: RD$" + precios[repuesto.Key]);
                        Console.WriteLine("Cantidad en inventario: " + inventario[repuesto.Key]);
                    }


                    break;
                }
            case 3:
                {

                    Console.WriteLine("Ingrese el codigo de lo que busca");
                    string buscarcodigo = Console.ReadLine();


                    if (nombres.ContainsKey(buscarcodigo))
                    {
                        Console.WriteLine("Codigo: " + buscarcodigo);
                        Console.WriteLine("Nombre: " + nombres[buscarcodigo]);
                        Console.WriteLine("Marca: " + marcas[buscarcodigo]);
                        Console.WriteLine("Categoria: " + categorias[buscarcodigo]);
                        Console.WriteLine("Precio: RD$" + precios[buscarcodigo]);
                        Console.WriteLine("Cantidad en inventario: " + inventario[buscarcodigo]);


                    }
                    else
                        Console.WriteLine("No tenemos ese codigo por favor ingrese una opcion valida");





                    break;
                }
            case 4:
                {
                    Console.WriteLine("Ingrese el codigo de lo que desea actualizar");
                    string actdecantidad = Console.ReadLine();

                    if (nombres.ContainsKey(actdecantidad))
                    {
                        Console.WriteLine("Ahora mismo tienes: " + inventario[actdecantidad]);
                        Console.WriteLine("Que cantidad desea registrar?");
                        int nuevacantidad = Convert.ToInt32(Console.ReadLine());
                        inventario[actdecantidad] = nuevacantidad;
                        Console.WriteLine("El valor a sido actualizado con exito ");
                    }


                    else
                        Console.WriteLine("No tienes respuesto con ese codigo");


                    break;
                }

            case 5:
                {
                    Console.WriteLine("Ingrese el codigo del repuesto que desea elinminar");
                    string Decocotarepuesto = Console.ReadLine();
                    if (nombres.ContainsKey(Decocotarepuesto))
                    {
                        inventario.Remove(Decocotarepuesto);
                        marcas.Remove(Decocotarepuesto);
                        precios.Remove(Decocotarepuesto);
                        categorias.Remove(Decocotarepuesto);
                        nombres.Remove(Decocotarepuesto);
                        Console.WriteLine("Repuesto eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No tenemos ningun repuesto con ese codigo");
                    }

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
catch(Exception ex)
{
    Console.WriteLine("Ha ocurrido un error: " + ex.Message);
}