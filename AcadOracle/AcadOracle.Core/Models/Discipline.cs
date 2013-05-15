using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOracle.Core.Models
{
    public class Discipline
    {
        //ToDo: Move this to a settings file or the database.
        private const int MaxSemesters = 11;
        //ToDo: Move this to a settings file or the database.
        private const int SemesterWeight = 15;
        //ToDo: Move this to a settings file or the database.
        private const int DependencyWeight = 10;

        public Discipline()
        {
            RequisiteTo = new Discipline[0];
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int PreCredits { get; set; }
        public short Semester { get; set; }
        public bool IsElective { get; set; }

        public IEnumerable<Discipline> RequisiteTo { get; set; }

        public int Points
        {
            get
            {
                int points = (MaxSemesters - Semester) * SemesterWeight;
                points += RequisiteTo.Count() * DependencyWeight;

                return points;
            }
        }


    }
}
