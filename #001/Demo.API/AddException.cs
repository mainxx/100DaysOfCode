using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.API
{
    public class AddException : Exception
    {
        public AddException(string massage) : base(massage)
        {

        }
    }
}
