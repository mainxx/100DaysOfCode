using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    [TestFixture]
    public class MainNUnitTests
    {
        private Demo.API.Main main;
        public MainNUnitTests()
        {
            main = new Demo.API.Main();
        }

        #region Add Tests
        [Test]
        public void Add_Test()
        {
            var addResult = main.Add(100, 150);
            Assert.AreEqual(250, addResult);
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(100, 100, 200)]
        [DataRow(8000, 800, 8800)]
        public void Add_DatasTest(int one, int two, int addResult)
        {
            Assert.AreEqual(addResult, main.Add(one, two));
        }
        #endregion

        #region AddV2 Tests
        [TestMethod]
        public void AddV2_Test()
        {
            var addV2Result = main.AddV2(30, 20);
            Assert.AreEqual(50, addV2Result);
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(10, 10, 20)]
        [DataRow(5, 50, 55)]
        public void AddV2_DatasTest(int one, int two, int addV2Result)
        {
            Assert.AreEqual(addV2Result, main.AddV2(one, two));
        }

        [TestMethod]
        public void AddV2_AddExceptionTest()
        {
            Assert.ThrowsException<Demo.API.AddException>(() =>
            {
                main.AddV2(51, 20);
            });

        }
        [TestMethod]
        public void AddV2_SumExceptionTest()
        {
            Assert.ThrowsException<Demo.API.SumException>(() =>
            {
                main.AddV2(45, 45);
            });

        }
        [DataTestMethod()]
        [DataRow(50, 51)]
        [DataRow(100, 20)]
        [DataRow(1000, 1)]
        public void AddV2_AddExceptionDatasTest(int one, int two)
        {
            Assert.ThrowsException<Demo.API.AddException>(() =>
            {
                main.AddV2(one, two);
            });
        }

        [DataTestMethod()]
        [DataRow(50, 45)]
        [DataRow(40, 42)]
        [DataRow(41, 41)]
        public void AddV2_SumExceptionDatasTest(int one, int two)
        {
            Assert.ThrowsException<Demo.API.SumException>(() =>
            {
                main.AddV2(one, two);
            });
        }



        #endregion
    }
}
