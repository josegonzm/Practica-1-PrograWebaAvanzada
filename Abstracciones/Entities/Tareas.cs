using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Entities
{
    public class Tareas

    {
        public Guid Id  { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public DateTime Fecha_Inicio { get; set; }

        public DateTime Fecha_Fin { get; set; }

        public Usuarios Asignado { get; set; } 

        public string Estado { get; set; } 





    

       
        







    }
}
