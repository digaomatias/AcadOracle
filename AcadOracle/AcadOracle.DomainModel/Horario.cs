using System;
using System.Collections.Generic;
using System.Linq;

namespace AcadOracle.DomainModel
{
    public class Horario
    {
        public Horario()
        {
            this.HorasAula = new HashSet<HoraAula>();
        }

        public int Id { get; set; }
        //JK, LM, etc...
        public ICollection<HoraAula> HorasAula { get; set; }
        public DayOfWeek DiaSemana { get; set; }

        public bool SobrepoeHorario(Horario obj)
        {
            if (DiaSemana != obj.DiaSemana)
                return false;
            
            foreach (HoraAula hora in HorasAula)
            {
                if (obj.HorasAula.Contains(hora))
                    return true;
            }

            return false;
        }
    }

    public enum HoraAula
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        P
        
    }
}
