using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.Common;
using AcadOracle.Core.Interfaces;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;

namespace AcadOracle.Core
{
    public class OracleService : IOracleService
    {
        public static List<List<Turma>> AllCombinationsOf(params List<Turma>[] sets)
        {
            // need array bounds checking etc for production
            var combinations = new List<List<Turma>>();

            // prime the data
            foreach (var value in sets[0])
                combinations.Add(new List<Turma> { value });

            foreach (var set in sets.Skip(1))
                combinations = AddExtraSet(combinations, set);

            return combinations;
        }

        private static List<List<Turma>> AddExtraSet
             (List<List<Turma>> combinations, List<Turma> set) 
        {
            var newCombinations = from value in set
                                  from combination in combinations
                                  where combination.All(c => c.Disciplina != value.Disciplina)
                                  select new List<Turma>(combination) { value };

            return (newCombinations.Count() > 0) ? newCombinations.ToList() : combinations;
        }

        private static IEnumerable<Turma> FiltrarTurmas(IEnumerable<Turma> turmas)
        {
            turmas = turmas.OrderBy(t => t.Disciplina.Peso).ToList();

            var listaDeCombinacoesConflitantes = GerarListaDeCombinacoesConflitantes(turmas);
            var allCombinations = AllCombinationsOf(listaDeCombinacoesConflitantes.ToArray());
            var orderedCombinations = allCombinations.OrderByDescending(x => x.Sum(t => t.Disciplina.Peso)).First();

            return orderedCombinations;
        }

        private static List<List<Turma>> GerarListaDeCombinacoesConflitantes(IEnumerable<Turma> turmas)
        {
            List<List<Turma>> listaDeCombinacoesConflitantes = new List<List<Turma>>();

            var horarios = turmas.SelectMany(t => t.TurmaHorarios).ToList();

            foreach (var horario in horarios)
            {
                var conflitantes = turmas.Where(
                    t =>
                    t.TurmaHorarios.Any(
                        h => h.DiaSemana == horario.DiaSemana && h.Horarios.Any(ha => horario.Horarios.Contains(ha))))
                                         .ToList();

                /*if (conflitantes.Count > 1 && !listaDeCombinacoesConflitantes.Any(
                    l => l.All(t => conflitantes.Any(c => c.Disciplina == t.Disciplina))))*/
                
                if(conflitantes.Count > 1 && !conflitantes.All(c => listaDeCombinacoesConflitantes.Any(l => l.Contains(c))))
                    listaDeCombinacoesConflitantes.Add(conflitantes);
            }

            turmas.ToList().ForEach(t =>
                {
                    if (!listaDeCombinacoesConflitantes.Any(l => l.Contains(t)))
                        listaDeCombinacoesConflitantes.Add(new List<Turma> {t});
                });
            return listaDeCombinacoesConflitantes;
        }

        /// <summary>
        /// Sugere disciplinas baseado nas disciplinas cursadas, pendentes e semestre atual.
        /// </summary>
        /// <param name="semestreAtual"></param>
        /// <param name="candidatas"></param>
        /// <param name="cursadas"></param>
        /// <returns></returns>
        public IEnumerable<Turma> SugerirDisciplinas(IEnumerable<Disciplina> candidatas, IEnumerable<Disciplina> cursadas)
        {
            return SugerirDisciplinas(candidatas, cursadas, null);
        }

        public IEnumerable<Turma> SugerirDisciplinas(IEnumerable<Disciplina> candidatas, IEnumerable<Disciplina> cursadas, IEnumerable<Restricao> restricoes )
        {
            //Somente disciplinas do semestre atual ou anterior
            var candidatasCursaveis = candidatas.Where(c => !c.PreRequisitos.Any() || c.PreRequisitos.All(cursadas.Contains));
            var repository = AcadInjector.AcadContainer.GetInstance<ITurmaRepository>();
            var turmas = repository.GetByDisciplina(candidatasCursaveis.AsEnumerable());        
            
            foreach (var restricao in restricoes)
            {
                if (!(restricao is RestricaoCreditos))
                {
                    turmas = restricao.AplicarRestricao(turmas);
                }
            }

            if (turmas.Any())
            {
                var result = FiltrarTurmas(turmas);
                result = result.AplicarRestricoes(restricoes);
                return result;
            }
            return turmas;
        }
    }
}
