using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcadOracle.UnitTests.TestHelpers
{
    internal static class TestExtensions
    {
        internal static void AssertTurmaEsperada(this IEnumerable<Turma> turmas, Turma esperada)
        {
            Assert.IsTrue(turmas.Contains(esperada), string.Format("Turma da disciplina de {0} era esperada.", esperada.Disciplina.Nome));
        }

        internal static void AssertNaoRepeteDisciplinas(this IEnumerable<Turma> turmas)
        {
            if (turmas != null && turmas.Count() > 0)
            {
                var groups = turmas.GroupBy(t => t.Disciplina).ToArray();
                bool repeteDisciplinas = groups.Count() < turmas.Count();
                var orderedGroup = groups.OrderByDescending(g => g.Count());
                var turma = orderedGroup.First().First();
                Assert.IsFalse(repeteDisciplinas,
                               string.Format("Existem {0} turmas da disciplina de {1}", orderedGroup.Count(),
                                             turma.Disciplina.Nome));
            }
        }
    }
}
