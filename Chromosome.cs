using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Chromosome
    {
        private List<Gene> _genes;
        private List<bool> _isGenePresent;
        private int _fitnessValue = 0;

        public List<Gene> Genes
        {
            get { return _genes; }
            set { _genes = value; }
        }
        public List<bool> IsGenePresent
        {
            get { return _isGenePresent; }
            set { _isGenePresent = value; }
        }
        public int FitnessValue
        {
            get { return _fitnessValue; }
            set { _fitnessValue = value; }
        }
        public Chromosome(List<Gene> genes, List<bool> isGenePresent)
        {
            _genes = genes;
            _isGenePresent = isGenePresent;
        }
    }
}
