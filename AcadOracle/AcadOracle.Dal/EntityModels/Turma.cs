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
    
    public partial class Turma
    {
        public int Id { get; set; }
        public int DisciplinaId { get; set; }
        public int Numero { get; set; }
        public string TurmaHorario { get; set; }
    
        public virtual Disciplina Disciplina { get; set; }
    }
}
