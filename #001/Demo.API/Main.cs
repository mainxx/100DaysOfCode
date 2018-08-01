using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.API
{
    public class Main
    {
        public double AddDouble(double one, double two)
        {
            if (one + two == 66)
            {
                return -1;
            }
            return one + two;
        }

        /// <summary>
        /// 普通的加法计算器
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public int Add(int one, int two)
        {
            return one + two;
            //return one + two + 1;
        }

        /// <summary>
        /// 有限制的加法计算器（数字不能大于50，和不能大于80）
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public int AddV2(int one, int two)
        {
            if (one > 50 || two > 50)
            {
                throw new AddException("数字不能大于50");
            }
            if (one + two > 80)
            {
                throw new SumException("和不能大于80");
            }
            return one + two;
            //return one + two + 1;
        }
    }
}
