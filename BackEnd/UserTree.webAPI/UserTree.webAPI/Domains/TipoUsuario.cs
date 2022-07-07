using System;
using System.Collections.Generic;

#nullable disable

namespace UserTree.webAPI.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoU { get; set; }
        public string TipoU { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
