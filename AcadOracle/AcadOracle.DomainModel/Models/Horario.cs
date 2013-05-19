using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class Horario
    {
        public Horario()
        {
            this.TurmaHorarios = new List<TurmaHorario>();
        }

        private string descricao; 

        public HoraAula Id { get; set; }
        public string Descricao 
        { 
            get { return Id.ToString(); } 
            set { descricao = value; } 
        }

        public virtual ICollection<TurmaHorario> TurmaHorarios { get; set; }

        public override bool Equals(object obj)
        {
            Horario horario = obj as Horario;

            if (horario != null)
                return horario.Id == Id;

            return base.Equals(obj);
        }
    }
}
