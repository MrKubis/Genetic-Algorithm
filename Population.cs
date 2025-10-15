using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class Population
    {
        private List<Chromosome> _chromosomes;
        private int _currentIteration;

        public List<Chromosome> Chromosomes
        {
            get { return _chromosomes; }
            set { _chromosomes = value; }
        }
        public int CurrentIteration
        {
            get { return _currentIteration; }
            set { _currentIteration = value; }
        }
        public Population(List<Chromosome> chromosomes, int currentIteration)
        {
            _chromosomes = chromosomes;
            _currentIteration = currentIteration;
        }

        public List<Chromosome> SeparateElite(List<Chromosome> chromosomes)
        {
            chromosomes = chromosomes.OrderByDescending(c => c.FitnessValue).ToList();
            List<Chromosome> elite = new List<Chromosome>() { chromosomes.ElementAt(0), chromosomes.ElementAt(1) };
            return elite;
        }

        public List<Chromosome> DropElite(List<Chromosome> chromosomes)
        {
            chromosomes = chromosomes.OrderByDescending(c => c.FitnessValue).ToList();
            chromosomes.RemoveAt(0);
            chromosomes.RemoveAt(0);
            return chromosomes;
        }
    }
}
