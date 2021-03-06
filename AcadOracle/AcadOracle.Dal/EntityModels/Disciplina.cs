//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcadOracle.Dal.EntityModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disciplina
    {
        public Disciplina()
        {
            this.Turma = new HashSet<Turma>();
            this.Curso = new HashSet<Curso>();
            this.Disciplina1 = new HashSet<Disciplina>();
            this.Disciplina2 = new HashSet<Disciplina>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Creditos { get; set; }
        public int PreCreditos { get; set; }
        public short Semestre { get; set; }
        public bool Eletiva { get; set; }
    
        public virtual ICollection<Turma> Turma { get; set; }
        public virtual ICollection<Curso> Curso { get; set; }
        public virtual ICollection<Disciplina> Disciplina1 { get; set; }
        public virtual ICollection<Disciplina> Disciplina2 { get; set; }
    }
}
