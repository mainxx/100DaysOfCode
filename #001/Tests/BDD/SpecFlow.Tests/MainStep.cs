using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Shouldly;
namespace SpecFlow.Tests
{
    [Binding]
    public sealed class MainStep
    {
        private Demo.API.Main _main;
        private int one;
        private int two;
        private int result;

        public MainStep(Demo.API.Main main)
        {
            _main = main;
        }
        [Given(@"我已经输入了第一个数(.*)到计算器")]
        public void 假如我已经输入了第一个数到计算器(int p0)
        {
            one = p0;
        }

        [Given(@"我已经输入了第二个数(.*)到计算器")]
        public void 假如我已经输入了第二个数到计算器(int two)
        {
            this.two = two;
        }

        [When(@"我点击求和")]
        public void 当我点击求和()
        {
            result = _main.Add(one, two);
        }

        [Then(@"结果应该显示(.*)")]
        public void 那么结果应该显示(int p0)
        {
            result.ShouldBe(p0);
        }


        [When(@"点击新的求和")]
        public void 当点击新的求和()
        {
            result = _main.AddV2(one, two);
        }

        [Then(@"我输入了大于(.*)的数到计算器")]
        public void 那么我输入了大于的数到计算器(int p0)
        {
            one = p0 + 1;
        }

        [When(@"点击新的求和则抛出AddException异常")]
        public void 当点击新的求和则抛出AddException异常()
        {
            Should.Throw<Demo.API.AddException>(() =>
            {
                _main.AddV2(one, two);
            });
        }

        [Given(@"我输入两个数的和大于(.*)")]
        public void 假如我输入两个数的和大于(int p0)
        {

            one = p0 / 2;
            two = p0 / 2 + 1;
        }

        [When(@"点击新的求和则抛出SumException异常")]
        public void 当点击新的求和则抛出SumException异常()
        {
            Should.Throw<Demo.API.SumException>(() =>
            {
                _main.AddV2(one, two);
            });
        }



    }

}
