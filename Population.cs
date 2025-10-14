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
        private int _populationSize;
        private int _maxNumberOfIterations;
        private int _currentIteration;

        public List<Chromosome> Chromosomes
        {
            get { return _chromosomes; }
            set { _chromosomes = value; }
        }
        public int PopulationSize
        {
            get { return _populationSize; }
            set { _populationSize = value; }
        }
        public int MaxNumberOfIterations
        {
            get { return _maxNumberOfIterations; }
            set { _maxNumberOfIterations = value; }
        }
        public int CurrentIteration
        {
            get { return _currentIteration; }
            set { _currentIteration = value; }
        }
        public Population(List<Chromosome> chromosomes, int populationSize, int maxNumberOfIterations, int currentIteration)
        {
            _chromosomes = chromosomes;
            _populationSize = populationSize;
            _maxNumberOfIterations = maxNumberOfIterations;
            _currentIteration = currentIteration;
        }
    }
}
