﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;

namespace AcadOracle.Core.Interfaces
{
    public interface IOracleService
    {
        IEnumerable<Turma> SugerirDisciplinas(IEnumerable<Disciplina> pendentes,
                                              IEnumerable<Disciplina> cursadas);

        IEnumerable<Turma> SugerirDisciplinas(IEnumerable<Disciplina> candidatas,
                                              IEnumerable<Disciplina> cursadas,
                                              IEnumerable<Restricao> restricoes);
    }
}
