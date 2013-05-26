using System;
using System.Collections;
using System.Linq;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AcadOracle.UnitTests
{
    [TestClass]
    public class ModelExtensionsTest
    {
        [TestMethod]
        public void ToTurmaHorariosInvalidFormatTest()
        {
            string a = "2jk4jk";
            string b = "4lm";
            string c = "2jk4jk6jk";

            string h = "";
            string j = "jf983";

            IEnumerable<TurmaHorario> result = a.ToTurmaHorarios();
            Assert.IsTrue(result.Count() == 2);
            Assert.IsTrue(result.First().DiaSemana == DayOfWeek.Monday);
            Assert.IsTrue(result.ElementAt(1).DiaSemana == DayOfWeek.Wednesday);
        }

        [TestMethod]
        public void IsValidTurmaHorarioTest()
        {
            string[] invalids = new string[]
                {
                    "",
                    "     ",
                    "   ",
                    "2q",
                    "1j",
                    "33",
                    "2jk4nn"
                };

            foreach (var invalid in invalids)
            {
                var result = invalid.IsValidTurmaHorario();
                Assert.IsFalse(result, string.Format("{0} deveria falhar", invalid));
            }

            string[] valids =
                {
                    "2jk4jk",
                    "3np5np",
                    "2jk",
                    "4lm",
                    "3jk",
                    "2lm",
                    "2jk4jk6jk",
                    "3np5np"
                };
            foreach (string valid in valids)
            {
                var result = valid.IsValidTurmaHorario();
                Assert.IsTrue(result, string.Format("{0} deveria passar", valid)); 
            }
        }
    }
}
