using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.API.Tests
{
    [TestClass()]
    public class MainTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Demo.API.Main main = new Main();
            var result = main.Add(50, 50);
            Assert.AreEqual(100, result);
        }
    }
}