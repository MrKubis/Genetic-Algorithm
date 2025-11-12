using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{

    class Population
    {
        private static Random random = new Random();

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
            orderedChromosomes = _chromosomes.OrderBy(c => c.FitnessValue).ToList();
            List<Chromosome> elite = new List<Chromosome>() { orderedChromosomes.ElementAt(0), orderedChromosomes.ElementAt(1) };
            return elite;
        }

        //RETURNS LIST WITHOUT 2 ELITE CHROMOSOMES
        public List<Chromosome> DropElite()
        {
            List<Chromosome> droppedChromosomes = _chromosomes.OrderBy(c => c.FitnessValue).ToList();
            droppedChromosomes.RemoveAt(0);
            droppedChromosomes.RemoveAt(0);
            return droppedChromosomes;
        }

        public List<Chromosome> ChooseRandomPair()
        {
            double sum = 0;
            for (int i = 0; i < Chromosomes.Count; i++)
            {
                if (Chromosomes[i].FitnessValue == 0 && Chromosomes[i].Fitnessfunction != null)
                {
                    sum +=  1/ Chromosomes[i].CalculateFitness();
                }
                else
                {
                    sum +=  1/ Chromosomes[i].FitnessValue;
                }
            }
            List<Chromosome> randomizedChromosomes = Chromosomes;
            
            Chromosome parent1 = ChooseOneParent(sum);
            Chromosome parent2 = ChooseOneParent(sum);
            return new List<Chromosome>() { parent1, parent2 };
        }
        private Chromosome ChooseOneParent(double totalFitnessSum)
        {

            double r = totalFitnessSum * random.NextDouble();

            foreach (Chromosome chromosome in _chromosomes)
            {
                r -= 1 / chromosome.FitnessValue;
                if (r <= 0)
                {
                    return chromosome;
                }
            }
            return _chromosomes.Last();
        }

        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> templist = new List<T>();
            foreach (T item in list)
            {
                templist.Add(item);
            }
            List<T> randomizedList = new List<T>();
            while (templist.Count > 0)
            {
                int index = random.Next(0, templist.Count);
                randomizedList.Add(list[index]);
                templist.RemoveAt(index);

            }
            return randomizedList;
        }
    }
}
