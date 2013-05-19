using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using AcadOracle.Common;
using AcadOracle.Core;
using AcadOracle.Core.Models;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;
using AcadOracle.UnitTests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AcadOracle.UnitTests
{
    [TestClass]
    public class OracleServiceTest
    {
        private Turma CriarTurma(Disciplina disc, Horario[] horas, DayOfWeek[] dias )
        {
            HashSet<TurmaHorario> horarios = new HashSet<TurmaHorario>();
            foreach (var dia in dias)
            {
                horarios.Add(new TurmaHorario()
                    {
                        DiaSemana = dia,
                        Horarios = horas
                    });
            }
            
            Turma turma = new Turma()
            {
                Disciplina = disc,
                Id = 1,
                TurmaHorarios = horarios
            };

            return turma;
        }

        [TestInitialize]
        public void CleanupTests()
        {
            AcadInjector.RenewContainer();
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
                Semestre = 2,
                PreRequisitos = new Disciplina[] { d1 }
            };

            d1.PreRequisitos = new Disciplina[] {d3};

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

            Horario horJ = new Horario() { Id = HoraAula.J };
            Horario horK = new Horario() { Id = HoraAula.K };

            Turma turmaD1 = CriarTurma(d1, new[] {horJ, horK},
                                       new[] {DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday});
            Turma turmaD2 = CriarTurma(d2, new [] { horJ, horK },
                                       new[] { DayOfWeek.Tuesday, DayOfWeek.Thursday });
          
            Turma turmaD4 = CriarTurma(d4, new [] { horJ, horK },
                                       new[] { DayOfWeek.Monday, DayOfWeek.Wednesday });
            #endregion

            #region Mock

            MockRepository repository = new MockRepository(MockBehavior.Strict);
            Mock<ITurmaRepository> turmaRepoMock = repository.Create<ITurmaRepository>();
            turmaRepoMock.Setup(x => x.GetByDisciplina(It.IsAny<IEnumerable<Disciplina>>()))
                         .Returns(new Turma[] {turmaD1, turmaD2, turmaD4});
            AcadInjector.AcadContainer.Register(() => turmaRepoMock.Object);

            #endregion

            OracleService target = new OracleService();
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(semestreAtual, pendentes, cursadas);

            repository.VerifyAll();

            //Tem as 3 disciplinas do primeiro semestre, já que não há restrições.
            Assert.IsTrue(turmas.Count() == 2);
            turmas.AssertTurmaEsperada(turmaD1);
            turmas.AssertTurmaEsperada(turmaD2);
        }

        [TestMethod]
        public void TesteSugerirDisciplinasRestricaoDeHorarios()
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
                Semestre = 2,
                PreRequisitos = new Disciplina[] { d1 }
            };

            d1.PreRequisitos = new Disciplina[] { d3 };

            Disciplina d4 = new Disciplina()
            {
                Nome = "Introdução a CC",
                Creditos = 4,
                Id = 2,
                Eletiva = false,
                Semestre = 1
            };


            List<Disciplina> pendentes = new List<Disciplina>(new Disciplina[] { d1, d2 });
            List<Disciplina> cursadas = new List<Disciplina>(new Disciplina[] { });
            int semestreAtual = 1;

            Horario horJ = new Horario() {Id = HoraAula.J};
            Horario horK = new Horario() { Id = HoraAula.K };
            Horario horL = new Horario() { Id = HoraAula.L };
            Horario horM = new Horario() { Id = HoraAula.M };
            Horario horN = new Horario() { Id = HoraAula.N };
            Horario horP = new Horario() { Id = HoraAula.P };

            Turma turmaD1 = CriarTurma(d1, new [] { horJ, horK },
                                       new [] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            Turma turmaD2 = CriarTurma(d2, new [] { horJ, horK },
                                       new [] { DayOfWeek.Tuesday, DayOfWeek.Thursday });

            Turma turmaD4 = CriarTurma(d4, new[] { horJ, horK },
                                       new [] { DayOfWeek.Monday, DayOfWeek.Wednesday });

            Turma turmaD5 = CriarTurma(d1, new[] { horN, horP },
                                       new[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });

            Turma turmaD6 = CriarTurma(d2, new[] { horL, horM },
                                       new[] { DayOfWeek.Tuesday, DayOfWeek.Thursday });

            TurmaHorario horario = new TurmaHorario()
                {
                    DiaSemana = DayOfWeek.Friday,
                    Horarios = new [] {new Horario(){Id = HoraAula.J}}
                };

            RestricaoHorarios restricao1 = new RestricaoHorarios(new[] { horario });

            #endregion

            #region Mock

            MockRepository repository = new MockRepository(MockBehavior.Strict);
            Mock<ITurmaRepository> turmaRepoMock = repository.Create<ITurmaRepository>();
            turmaRepoMock.Setup(x => x.GetByDisciplina(It.IsAny<IEnumerable<Disciplina>>()))
                         .Returns(new Turma[] { turmaD1, turmaD2, turmaD4, turmaD5, turmaD6 });
            
            AcadInjector.AcadContainer.Register(() => turmaRepoMock.Object);
            

            #endregion

            OracleService target = new OracleService();
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(semestreAtual, pendentes, cursadas, new Restricao[] {restricao1});

            repository.VerifyAll();

            Assert.IsTrue(turmas.Count() == 3, String.Format("Quantidade de turmas sugeridas inválido. Esperado: 3, Resultado: {0}", turmas.Count()));
            turmas.AssertNaoRepeteDisciplinas();
            turmas.AssertTurmaEsperada(turmaD4);
            turmas.AssertTurmaEsperada(turmaD5);
        }

        [TestMethod]
        public void TesteSugerirDisciplinasRestricaoDeCreditos()
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
                Semestre = 2,
                PreRequisitos = new Disciplina[] { d1 }
            };

            d1.PreRequisitos = new Disciplina[] { d3 };

            Disciplina d4 = new Disciplina()
            {
                Nome = "Introdução a CC",
                Creditos = 4,
                Id = 2,
                Eletiva = false,
                Semestre = 1
            };


            List<Disciplina> pendentes = new List<Disciplina>(new Disciplina[] { d1, d2 });
            List<Disciplina> cursadas = new List<Disciplina>(new Disciplina[] { });
            int semestreAtual = 1;

            Horario horJ = new Horario() { Id = HoraAula.J };
            Horario horK = new Horario() { Id = HoraAula.K };

            Turma turmaD1 = CriarTurma(d1, new [] { horJ, horK },
                                       new[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            Turma turmaD2 = CriarTurma(d2, new [] { horJ, horK },
                                       new[] { DayOfWeek.Tuesday, DayOfWeek.Thursday });

            Turma turmaD4 = CriarTurma(d4, new [] { horJ, horK },
                                       new[] { DayOfWeek.Monday, DayOfWeek.Wednesday });

            RestricaoCreditos restricao1 = new RestricaoCreditos(8);

            #endregion

            #region Mock

            MockRepository repository = new MockRepository(MockBehavior.Strict);
            Mock<ITurmaRepository> turmaRepoMock = repository.Create<ITurmaRepository>();
            turmaRepoMock.Setup(x => x.GetByDisciplina(It.IsAny<IEnumerable<Disciplina>>()))
                         .Returns(new Turma[] { turmaD1, turmaD2, turmaD4 });
            AcadInjector.AcadContainer.Register(() => turmaRepoMock.Object);

            #endregion

            OracleService target = new OracleService();
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(semestreAtual, pendentes, cursadas, new Restricao[]{restricao1});

            repository.VerifyAll();

            //Tem as 3 disciplinas do primeiro semestre, já que não há restrições.
            Assert.IsTrue(turmas.Count() == 1);
            turmas.AssertTurmaEsperada(turmaD1);
        }

        [TestMethod]
        public void TesteSugerirDisciplinasRestricaoDeDisciplinas()
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
                Semestre = 2,
                PreRequisitos = new Disciplina[] { d1 }
            };

            d1.PreRequisitos = new Disciplina[] { d3 };

            Disciplina d4 = new Disciplina()
            {
                Nome = "Introdução a CC",
                Creditos = 4,
                Id = 2,
                Eletiva = false,
                Semestre = 1
            };


            List<Disciplina> pendentes = new List<Disciplina>(new Disciplina[] { d1, d2 });
            List<Disciplina> cursadas = new List<Disciplina>(new Disciplina[] { });
            int semestreAtual = 1;

            Horario horJ = new Horario() { Id = HoraAula.J };
            Horario horK = new Horario() { Id = HoraAula.K };

            Turma turmaD1 = CriarTurma(d1, new [] { horJ, horK },
                                       new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            Turma turmaD2 = CriarTurma(d2, new [] { horJ, horK },
                                       new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Thursday });

            Turma turmaD4 = CriarTurma(d4, new [] { horJ, horK },
                                       new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday });

            RestricaoDisciplinas restricao1 = new RestricaoDisciplinas(new Disciplina[] {d1});


            #endregion

            #region Mock

            MockRepository repository = new MockRepository(MockBehavior.Strict);
            Mock<ITurmaRepository> turmaRepoMock = repository.Create<ITurmaRepository>();
            turmaRepoMock.Setup(x => x.GetByDisciplina(It.IsAny<IEnumerable<Disciplina>>()))
                         .Returns(new Turma[] { turmaD1, turmaD2, turmaD4 });
            AcadInjector.AcadContainer.Register(() => turmaRepoMock.Object);

            #endregion

            OracleService target = new OracleService();
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(semestreAtual, pendentes, cursadas, new Restricao[] { restricao1 });

            repository.VerifyAll();

            Assert.IsTrue(turmas.Count() == 2);
            turmas.AssertTurmaEsperada(turmaD2);
            turmas.AssertTurmaEsperada(turmaD4);
        }
    }
}
