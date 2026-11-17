using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.CapaDatos
{
    public class cls_usuario_equipo
    { }

        namespace Banco.CapaDatos
    {
        public class cls_usuario
        {
            public int UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string CorreoElectronico { get; set; }
            public string Telefono { get; set; }
        }

        public class cls_equipo
        {
            public int EquipoID { get; set; }
            public string TipoEquipo { get; set; }
            public string Modelo { get; set; }
            public int UsuarioID { get; set; }
        }
    }

}
}