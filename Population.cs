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
        //RETURNS SEPERATED LIST OF 2 ELITE CHROMOSOMES
        public List<Chromosome> SeparateElite()
        {
            List<Chromosome> orderedChromosomes = new List<Chromosome>();
            orderedChromosomes = _chromosomes.OrderByDescending(c => c.FitnessValue).ToList();
            List<Chromosome> elite = new List<Chromosome>() { orderedChromosomes.ElementAt(0), orderedChromosomes.ElementAt(1) };
            return elite;
        }

        //RETURNS LIST WITHOUT 2 ELITE CHROMOSOMES
        public List<Chromosome> DropElite()
        {
            List<Chromosome> droppedChromosomes = _chromosomes.OrderByDescending(c => c.FitnessValue).ToList();
            droppedChromosomes.RemoveAt(0);
            droppedChromosomes.RemoveAt(0);
            return droppedChromosomes;
        }
    }
}
