using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOracle.Core.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int PreCredits { get; set; }
        public short Semester { get; set; }
        public bool IsElective { get; set; }
    }
}
