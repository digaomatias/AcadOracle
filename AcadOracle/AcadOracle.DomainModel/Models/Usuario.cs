using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
