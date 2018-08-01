using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;
namespace SpecFlow.Tests
{
    [Binding]
    public sealed class StepDefinition1
    {
        private double one;
        private double two;
        private double result;
        [Given(@"第二个测试我已经输入第一个数(.*)到计算器")]
        public void 假如第二个测试我已经输入第一个数到计算器(double one)
        {
            this.one = one;
        }

        [Given(@"第二个测试我已经输入第二个数(.*)到计算器")]
        public void 假如第二个测试我已经输入第二个数到计算器(double two)
        {
            this.two = two;
        }

        [When(@"第二个测试我点击求和")]
        public void 当第二个测试我点击求和()
        {
            result = new Demo.API.Main().AddDouble(this.one, this.two);
        }

        [Then(@"第二个测试结果应该显示(.*)")]
        public void 那么第二个测试结果应该显示(double p0)
        {
            Assert.Equal(result, p0);
        }

    }
}
