using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using AcadOracle.Common;
using AcadOracle.Core;
using AcadOracle.Core.Models;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AcadOracle.UnitTests
{
    [TestClass]
    public class OracleServiceTest
    {
        private Turma CriarTurma(Disciplina disc, HoraAula[] horas, DayOfWeek[] dias )
        {
            HashSet<Horario> horarios = new HashSet<Horario>();
            foreach (var dia in dias)
            {
                horarios.Add(new Horario()
                    {
                        DiaSemana = dia,
                        HorasAula = horas
                    });
            }
            
            Turma turma = new Turma()
            {
                Disciplina = disc,
                Id = 1,
                Horarios = horarios
            };

            return turma;
        }

        [TestMethod]
        public void TesteSugerirDisciplinasSemRestricoes()
        {
            #region DataSetup
            
            Disciplina d1 = new Disciplina()
                {
                    Nome = "Alpro I",
                    Creditos = 6,
                    Id = 1,
                    Eletiva = false,
                    Semestre = 1
                };
            
            Disciplina d2 = new Disciplina()
            {
                Nome = "Calculo A",
                Creditos = 4,
                Id = 2,
                Eletiva = false,
                Semestre = 1
            };

            Disciplina d3 = new Disciplina()
            {
                Nome = "Alpro II",
                Creditos = 4,
                Id = 3,
                Eletiva = false,
                Semestre = 2
            };

            d1.RequisitoPara = new Disciplina[] {d3};

            Disciplina d4 = new Disciplina()
            {
                Nome = "Introdução a CC",
                Creditos = 4,
                Id = 2,
                Eletiva = false,
                Semestre = 1
            };
            
            
            List<Disciplina> pendentes = new List<Disciplina>(new Disciplina[] {d1, d2});
            List<Disciplina> cursadas = new List<Disciplina>(new Disciplina[] { });
            int semestreAtual = 1;

            Turma turmaD1 = CriarTurma(d1, new HoraAula[] {HoraAula.J, HoraAula.K},
                                       new DayOfWeek[] {DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday});
            Turma turmaD2 = CriarTurma(d2, new HoraAula[] { HoraAula.J, HoraAula.K },
                                       new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Thursday });
            Turma turmaD3 = CriarTurma(d3, new HoraAula[] { HoraAula.L, HoraAula.M },
                                       new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Thursday });             
            Turma turmaD4 = CriarTurma(d4, new HoraAula[] { HoraAula.J, HoraAula.K },
                                       new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday });
            #endregion

            #region Mock

            MockRepository repository = new MockRepository(MockBehavior.Strict);
            Mock<ITurmaRepository> turmaRepoMock = repository.Create<ITurmaRepository>();
            turmaRepoMock.Setup(x => x.GetByDisciplina(It.IsAny<IEnumerable<Disciplina>>()))
                         .Returns(new Turma[] {turmaD1, turmaD2, turmaD3, turmaD4});
            AcadInjector.AcadContainer.RegisterSingle<ITurmaRepository>(turmaRepoMock.Object);

            #endregion

            OracleService target = new OracleService();
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(semestreAtual, pendentes, cursadas);

            repository.VerifyAll();

            //Tem as 3 disciplinas do primeiro semestre, já que não há restrições.
            Assert.IsTrue(turmas.Count() == 2);
            Assert.IsTrue(turmas.Contains(turmaD1));
            Assert.IsTrue(turmas.Contains(turmaD2));
        }
    }
}
