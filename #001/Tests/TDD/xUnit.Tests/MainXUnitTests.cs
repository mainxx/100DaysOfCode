using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnit.Tests
{
    public class MainXUnitTests
    {
        private Demo.API.Main main;
        public MainXUnitTests()
        {
            main = new Demo.API.Main();
        }

        #region Add Tests
        [Fact]
        public void Add_Test()
        {
            var addResult = main.Add(100, 150);
            Assert.Equal(250, addResult);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(100, 100, 200)]
        [InlineData(8000, 800, 8800)]
        public void Add_Theory(int one, int two, int addResult)
        {
            Assert.Equal(addResult, main.Add(one, two));
        }
        #endregion

        #region AddV2 Tests
        [Fact]
        public void AddV2_Test()
        {
            var addV2Result = main.AddV2(30, 20);
            Assert.Equal(50, addV2Result);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(10, 10, 20)]
        [InlineData(5, 50, 55)]
        public void AddV2_Theory(int one, int two, int addV2Result)
        {
            Assert.Equal(addV2Result, main.AddV2(one, two));
        }

        [Fact(DisplayName = "Throw Demo.API.AddException")]
        public void AddV2_AddExceptionTest()
        {
            Assert.Throws<Demo.API.AddException>(() =>
            {
                main.AddV2(51, 20);
            });

        }
        [Fact(DisplayName = "Throw Demo.API.SumException")]
        public void AddV2_SumExceptionTest()
        {
            Assert.Throws<Demo.API.SumException>(() =>
            {
                main.AddV2(45, 45);
            });

        }

        [Theory()]
        [InlineData(50, 51, typeof(Demo.API.AddException))]
        [InlineData(100, 20, typeof(Demo.API.AddException))]
        [InlineData(1000, 1, typeof(Demo.API.AddException))]
        [InlineData(50, 45, typeof(Demo.API.SumException))]
        [InlineData(40, 42, typeof(Demo.API.SumException))]
        [InlineData(41, 41, typeof(Demo.API.SumException))]
        public void AddV2_ExceptionTheory(int one, int two, Type exceptionType)
        {
            Assert.Throws(exceptionType, () =>
            {
                main.AddV2(one, two);
            });
        }

        #endregion
    }
}
