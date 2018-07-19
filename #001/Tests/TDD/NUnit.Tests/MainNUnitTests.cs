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

        [TestCase(1, 1, 2)]
        [TestCase(100, 100, 200)]
        [TestCase(8000, 800, 8800)]
        public void Add_DatasTest(int one, int two, int addResult)
        {
            Assert.AreEqual(addResult, main.Add(one, two));
        }
        #endregion

        #region AddV2 Tests
        [Test]
        public void AddV2_Test()
        {
            var addV2Result = main.AddV2(30, 20);
            Assert.AreEqual(50, addV2Result);
        }

        [TestCase(1, 1, 2)]
        [TestCase(10, 10, 20)]
        [TestCase(5, 50, 55)]
        public void AddV2_DatasTest(int one, int two, int addV2Result)
        {
            Assert.AreEqual(addV2Result, main.AddV2(one, two));
        }

        [Test]
        public void AddV2_AddExceptionTest()
        {
            Assert.Throws<Demo.API.AddException>(() =>
            {
                main.AddV2(51, 20);
            });

        }
        [Test]
        public void AddV2_SumExceptionTest()
        {
            Assert.Throws<Demo.API.SumException>(() =>
            {
                main.AddV2(45, 45);
            });

        }
        [TestCase(50, 51)]
        [TestCase(100, 20)]
        [TestCase(1000, 1)]
        public void AddV2_AddExceptionDatasTest(int one, int two)
        {
            Assert.Throws<Demo.API.AddException>(() =>
            {
                main.AddV2(one, two);
            });
        }


        [TestCase(50, 45)]
        [TestCase(40, 42)]
        [TestCase(41, 41)]
        public void AddV2_SumExceptionDatasTest(int one, int two)
        {
            Assert.Throws<Demo.API.SumException>(() =>
            {
                main.AddV2(one, two);
            });
        }



        #endregion
    }
}
