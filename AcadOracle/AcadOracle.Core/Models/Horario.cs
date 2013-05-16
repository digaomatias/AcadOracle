using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOracle.Core.Models
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
