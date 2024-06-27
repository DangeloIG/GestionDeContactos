using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeContactos
{
    [Serializable]
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Teléfono: {Telefono}, Email: {Email} ";
        }
    }

}
