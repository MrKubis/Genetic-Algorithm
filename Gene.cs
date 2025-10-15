using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Gene
    {
        private int _weight;
        private int _value;

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Gene(int weight, int value)
        {
            _weight = weight;
            _value = value;
        }
    }
}
