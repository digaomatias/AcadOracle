using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AcadOracle.Core.Models;
using AcadOracle.Dal.Interfaces;
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
        public void TestMethod1()
        {
            #region DataSetup
            Disciplina d3 = new Disciplina()
            {
                Nome = "Alpro II",
                Creditos = 4,
                Id = 3,
                Eletiva = false,
                Semestre = 2
            };
            
            Disciplina d1 = new Disciplina()
                {
                    Nome = "Alpro I",
                    Creditos = 6,
                    Id = 1,
                    Eletiva = false,
                    Semestre = 1,
                    RequisitoPara = new Disciplina[] { d3 }
                };

            HashSet<Horario> horariosD1 = new HashSet<Horario>();
            horariosD1.Add(new Horario()
            {
                DiaSemana = DayOfWeek.Monday,
                HorasAula = new HoraAula[] { HoraAula.J, HoraAula.K, }
            });
            horariosD1.Add(new Horario()
            {
                DiaSemana = DayOfWeek.Wednesday,
                HorasAula = new HoraAula[] { HoraAula.J, HoraAula.K, }
            });
            horariosD1.Add(new Horario()
            {
                DiaSemana = DayOfWeek.Friday,
                HorasAula = new HoraAula[] { HoraAula.J, HoraAula.K, }
            });
            Turma turmad1 = new Turma()
            {
                Disciplina = d1,
                Id = 1,
                Horarios = horariosD1
            };

            Disciplina d2 = new Disciplina()
            {
                Nome = "Introdução a CC",
                Creditos = 4,
                Id = 2,
                Eletiva = false,
                Semestre = 1
            };

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
            
            //Expression<Func<Turma, bool>> expression = turma => { turma.Disciplina }

            //turmaRepoMock.Setup(x => x.GetAll())

            #endregion

            //OracleService target = new OracleService();
            //IEnumerable<Turma> turmas = target.SugerirDisciplinas(semestreAtual, pendentes, cursadas);
        
            //Tem as 3 disciplinas do primeiro semestre, já que não há restrições.
            //Assert.IsTrue(turmas.Count() == 2);
        }
    }
}
