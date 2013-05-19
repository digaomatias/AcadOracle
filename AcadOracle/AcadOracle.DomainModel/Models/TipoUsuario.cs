using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            this.Usuarios = new List<Usuario>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
