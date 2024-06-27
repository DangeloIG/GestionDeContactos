using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeContactos
{
    class Program
    {
        static void Main()
        {
            GestorDeContactos gestor = new GestorDeContactos();
            bool salir = false;

            while (!salir) {
                Console.WriteLine("\nMenú de Contactos:");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Buscar contacto");
                Console.WriteLine("3. Listar contactos");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5. Guardar contactos");
                Console.WriteLine("6. Cargar contactos");
                Console.WriteLine("7. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion) {
                    case "1":
                        AgregarContacto(gestor);
                        break;

                    case "2":
                        BuscarContacto(gestor);
                        break;

                    case "3":
                        ListarContactos(gestor);
                        break;

                    case "4":
                        EliminarContacto(gestor);
                        break;

                    case "5":
                        gestor.GuardarContactos();
                        Console.WriteLine("Contactos guardados exitosamente.");
                        break;

                    case "6":
                        gestor.CargarContactos();
                        Console.WriteLine("Contactos cargados exitosamente.");
                        break;

                    case "7":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida intente nuevamente: ");
                        break;

                }
            }
        }

        static void AgregarContacto(GestorDeContactos gestor)
        {
            Contacto nuevoContacto = new Contacto();

            Console.Write("Ingrese el Id: ");
            nuevoContacto.Id = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el Nombre: ");
            nuevoContacto.Nombre = Console.ReadLine();
            Console.Write("Ingrese el Teléfono: ");
            nuevoContacto.Telefono = Console.ReadLine();
            Console.Write("Ingrese el Email: ");
            nuevoContacto.Email = Console.ReadLine();

            gestor.AgregarContacto(nuevoContacto);
            Console.WriteLine("Contacto agregado exitosamente.");
        }

        static void BuscarContacto(GestorDeContactos gestor)
        {
            Console.WriteLine("Ingrese el nombre o teléfono a buscar");
            String criterio = Console.ReadLine();

            Contacto contacto = gestor.BuscarContacto(criterio);

            if (contacto != null)
            {
                Console.WriteLine("Contacto encontrado: " + contacto);
            }
            else
            {
                Console.WriteLine("Contacto no encontrado");
            }
        }

        static void ListarContactos(GestorDeContactos gestor)
        {
            List<Contacto> contactos = gestor.ListarContactos();

            if (contactos.Count > 0)
            {
                Console.WriteLine("Lista de Contactos: ");
                foreach (var contacto in contactos)
                {
                    Console.WriteLine(contacto);
                }
            }
            else
            {
                Console.WriteLine("No hay contactos en la lista");
            }
        }

        static void EliminarContacto(GestorDeContactos gestor)
        {
            Console.WriteLine("Ingrese el ID del contacto a eliminar");
            int id = int.Parse(Console.ReadLine());
            gestor.EliminarContacto(id);
            Console.WriteLine("El contacto ha sido eliminado correctamente");
        }
    }
}
