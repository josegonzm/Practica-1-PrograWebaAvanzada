using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Usuarios
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string Primer_Apellido { get; set; } = string.Empty;
        public string? Segundo_Apellido { get; set; } = string.Empty;
        public string Correo {  get; set; } = string.Empty;
        public string Contraseña {  get; set; } = string.Empty;
        public bool Administrador { get; set; }
    }
}
