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

        public List<Chromosome> ChooseRandomPair()
        {
            List<Chromosome> pair = new List<Chromosome>();
            Chromosome chr1 = null;
            int sum = 0;
            Random random = new Random();
            double k = random.NextDouble();
            for (int i=0;i<Chromosomes.Count;i++)
            {
                if (Chromosomes[i].FitnessValue != null)
                {
                    sum += Chromosomes[i].FitnessValue;
                }
                //Jeżeli jakimś cudem nie ma fitness value
                else
                {
                    Console.WriteLine("NO FITNES VALUE!!!");
                    sum += Chromosomes[i].CalculateFitness(Chromosomes[i].Genes, Chromosomes[i].IsGenePresent);
                }
            }
            int cumulative = 0;
            foreach (Chromosome chromosome in Chromosomes)
            {
                cumulative += chromosome.FitnessValue;
                if(cumulative > Convert.ToInt32(sum * k))
                {
                    pair.Add(chromosome);
                    break;
                }
            }
            if (pair.Count < 1)
            {
                pair.Add(Chromosomes[random.Next(Chromosomes.Count)]);
            }
            foreach (Chromosome chromosome in Chromosomes)
            {
                cumulative += chromosome.FitnessValue;
                if (cumulative > Convert.ToInt32(sum * k))
                {
                    pair.Add(chromosome);
                    break;
                }
            }
            if (pair.Count < 2)
            {
                pair.Add(Chromosomes[random.Next(Chromosomes.Count)]);
            }
            return pair;
        }
    }
}
