using System;
using System.Collections.Generic;

#nullable disable

namespace UserTree.webAPI.Domains
{
    public partial class Usuario
    {
        public byte IdUsuario { get; set; }
        public byte? IdTipoU { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool StatusU { get; set; }

        public virtual TipoUsuario IdTipoUNavigation { get; set; }
    }
}
