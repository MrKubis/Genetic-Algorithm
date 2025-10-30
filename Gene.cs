using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Gene
    {
        private double _value;
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Gene(double value)
        {
            _value = value;
        }
    }
}
