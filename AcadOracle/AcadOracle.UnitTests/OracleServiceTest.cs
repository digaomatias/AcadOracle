using System;
using AcadOracle.Core.Models;
using AcadOracle.Dal.EntityModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcadOracle.UnitTests
{
    [TestClass]
    public class OracleServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            #region DataSetup

            Discipline d1 = new Discipline()
                {
                    Name = "Alpro I",
                    Credits = 6,
                    Id = 1,
                    IsElective = false,
                    Semester = 1
                };


            #endregion
        }
    }
}
