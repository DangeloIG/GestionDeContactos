using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeContactos
{
    public class GestorDeContactos
    {
        private List<Contacto> contactos;
        private const string archivo = "contactos.dat";

        public GestorDeContactos()
        {
            contactos = new List<Contacto>();
            CargarContactos();
        }

        public void AgregarContacto(Contacto contacto)
        {
            contactos.Add(contacto);
        }

        public Contacto BuscarContacto(string criterio)
        {
            return contactos.Find(c =>
                c.Nombre.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Telefono.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public List<Contacto> ListarContactos()
        {
            return new List<Contacto>(contactos);
        }

        public void EliminarContacto(int id)
        {
            contactos.RemoveAll(c => c.Id == id);
        }

        public void GuardarContactos()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(archivo, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, contactos);
            }            
        }

        public void CargarContactos()
        {
            if (File.Exists(archivo))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    using (Stream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                    {
                        contactos = (List<Contacto>)formatter.Deserialize(stream);
                    }    
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Error de serialización: " + e.Message);
                    contactos = new List<Contacto>();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error de E/S: " + e.Message);
                    contactos = new List<Contacto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error desconocido: " + e.Message);
                    contactos = new List<Contacto>();
                }
            }
        }

    }
}
