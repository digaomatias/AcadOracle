using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using AcadOracle.Common;
using AcadOracle.Core;
using AcadOracle.Dal.EntityModels;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;
using AcadOracle.UnitTests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Disciplina = AcadOracle.DomainModel.Models.Disciplina;
using Turma = AcadOracle.DomainModel.Models.Turma;
using TurmaHorario = AcadOracle.DomainModel.Models.TurmaHorario;

namespace AcadOracle.UnitTests
{
    [TestClass]
    public class OracleServiceTest
    {
        private Turma CriarTurma(Disciplina disc, HoraAula[] horas, DiaDaSemana[] dias )
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
            
            Turma turmaD1 = CriarTurma(d1, new[] {HoraAula.J, HoraAula.K, },
                                       new[] {DiaDaSemana.Monday, DiaDaSemana.Wednesday, DiaDaSemana.Friday});
            Turma turmaD2 = CriarTurma(d2, new [] { HoraAula.J, HoraAula.K },
                                       new[] { DiaDaSemana.Tuesday, DiaDaSemana.Thursday });
          
            Turma turmaD4 = CriarTurma(d4, new [] { HoraAula.J, HoraAula.K },
                                       new[] { DiaDaSemana.Monday, DiaDaSemana.Wednesday });
            #endregion

            #region Mock

            MockRepository repository = new MockRepository(MockBehavior.Strict);
            Mock<ITurmaRepository> turmaRepoMock = repository.Create<ITurmaRepository>();
            turmaRepoMock.Setup(x => x.GetByDisciplina(It.IsAny<IEnumerable<Disciplina>>()))
                         .Returns(new Turma[] {turmaD1, turmaD2, turmaD4});
            AcadInjector.AcadContainer.Register(() => turmaRepoMock.Object);

            #endregion

            OracleService target = new OracleService();
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(pendentes, cursadas);

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
            
            Turma turmaD1 = CriarTurma(d1, new [] { HoraAula.J, HoraAula.K },
                                       new [] { DiaDaSemana.Monday, DiaDaSemana.Wednesday, DiaDaSemana.Friday });
            Turma turmaD2 = CriarTurma(d2, new [] { HoraAula.J, HoraAula.K },
                                       new [] { DiaDaSemana.Tuesday, DiaDaSemana.Thursday });

            Turma turmaD4 = CriarTurma(d4, new[] { HoraAula.J, HoraAula.K },
                                       new [] { DiaDaSemana.Monday, DiaDaSemana.Wednesday });

            Turma turmaD5 = CriarTurma(d1, new[] { HoraAula.N, HoraAula.P },
                                       new[] { DiaDaSemana.Monday, DiaDaSemana.Wednesday, DiaDaSemana.Friday });

            Turma turmaD6 = CriarTurma(d2, new[] { HoraAula.L, HoraAula.M },
                                       new[] { DiaDaSemana.Tuesday, DiaDaSemana.Thursday });

            TurmaHorario horario = new TurmaHorario()
                {
                    DiaSemana = DiaDaSemana.Friday,
                    Horarios = new [] { HoraAula.J}
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
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(pendentes, cursadas, new Restricao[] {restricao1});

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
            
            Turma turmaD1 = CriarTurma(d1, new [] { HoraAula.J, HoraAula.K },
                                       new[] { DiaDaSemana.Monday, DiaDaSemana.Wednesday, DiaDaSemana.Friday });
            Turma turmaD2 = CriarTurma(d2, new [] { HoraAula.J, HoraAula.K },
                                       new[] { DiaDaSemana.Tuesday, DiaDaSemana.Thursday });

            Turma turmaD4 = CriarTurma(d4, new [] { HoraAula.J, HoraAula.K },
                                       new[] { DiaDaSemana.Monday, DiaDaSemana.Wednesday });

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
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(pendentes, cursadas, new Restricao[]{restricao1});

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
            
            Turma turmaD1 = CriarTurma(d1, new [] { HoraAula.J, HoraAula.K },
                                       new DiaDaSemana[] { DiaDaSemana.Monday, DiaDaSemana.Wednesday, DiaDaSemana.Friday });
            Turma turmaD2 = CriarTurma(d2, new [] { HoraAula.J, HoraAula.K },
                                       new DiaDaSemana[] { DiaDaSemana.Tuesday, DiaDaSemana.Thursday });

            Turma turmaD4 = CriarTurma(d4, new [] { HoraAula.J, HoraAula.K },
                                       new DiaDaSemana[] { DiaDaSemana.Monday, DiaDaSemana.Wednesday });

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
            IEnumerable<Turma> turmas = target.SugerirDisciplinas(pendentes, cursadas, new Restricao[] { restricao1 });

            repository.VerifyAll();

            Assert.IsTrue(turmas.Count() == 2);
            turmas.AssertTurmaEsperada(turmaD2);
            turmas.AssertTurmaEsperada(turmaD4);
        }
    }
}
