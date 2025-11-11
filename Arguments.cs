using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public class Arguments
    {
        private List<double> _args = new List<double>();
        public List<double> Args { set { _args = value; } get{ return _args; } }
        public Arguments(int length) {
        Args = new List<double>(length);
        }
    }
}
