using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    internal class PopulationProvider
    {
        private readonly Func<List<double>, double> _fitnessfunction;
        private double _mutationProbability = 0.02;
        private double _max_x;
        private double _min_x;
        private int _geneCount;
        private int _size;
        private Population _currentPopulation;
        private Population _newPopulation;
        public Population CurrentPopulation { get { return _currentPopulation; } set { _currentPopulation = value; } }
        public Population NewPopulation { get { return _newPopulation; } set { _newPopulation = value; } }
        public int Size { get { return _size; } set { _size = value; } }
        public int GeneCount { get { return _geneCount; } set { _geneCount = value; } }
        public PopulationProvider(int populationSize, int geneCount, double min_x, double max_x, Func<List<double>, double> function, double mutationProbability)
        {
            Random random = new Random();
            //USTAWIA WIELKOSC POPULACJI, LISTĘ GENÓW, OBECNĄ POPULACJĘ 
            _geneCount = geneCount;
            _size = populationSize;
            _fitnessfunction = function;
            _max_x = max_x;
            _min_x = min_x;
            _mutationProbability = mutationProbability;
            List<Chromosome> chromosomes = new List<Chromosome>();
            for (int i = 0; i < populationSize; i++)
            {
                List<Gene> genes = new List<Gene>();
                for (int j = 0; j < geneCount; j++)
                {
                    double r = Math.Abs(max_x - min_x);
                    double value = r * random.NextDouble() + min_x;
                    genes.Add(new Gene(value));
                }
                Chromosome chromosome = new Chromosome(genes, _fitnessfunction);
                chromosomes.Add(chromosome);
            }
            _currentPopulation = new Population(chromosomes, currentIteration: 0);
        }
        //RODZICE ZWRACAJA 1 DZIECKO
        public Chromosome CrossOver(List<Chromosome> pair)
        {
            List<Gene> geneList = new List<Gene>();
            Random random = new Random();
            double alpha = 0.5;
            int n = pair[0].Genes.Count;
            int a = random.Next(0, n + 1);
            int b = random.Next(0, n + 1);
            int min = 0;
            int max = 0;


            if (a == b)
            {
                return pair[random.Next(2)];
            }
            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            //CHOSING THE FRONT - FIRST OR SECOND PARENT
            int leftchoice = random.Next(2);
            for (int i = 0; i < a; i++)
            {
                if (random.NextDouble() <= _mutationProbability)
                {
                    geneList.Add(Mutate(new Gene(pair[leftchoice].Genes[i].Value)));
                }
                else
                {

                    geneList.Add(new Gene(pair[leftchoice].Genes[i].Value));
                }
            }
            for (int i = a; i < b; i++)
            {
                double x0 = pair[0].Genes[i].Value;
                double x1 = pair[1].Genes[i].Value;

                double d = Math.Abs(x1 - x0);
                min = (int)(Math.Min(x0, x1) - d * alpha);
                max = (int)(Math.Max(x0, x1) + d * alpha);

                min = Math.Max(min, (int)_min_x);
                max = Math.Min(max, (int)_max_x);

                double r = Math.Abs(max - min);
                double value = r * random.NextDouble() + x0;
                Gene gene = new Gene(value);
                if (random.NextDouble() <= _mutationProbability)
                {
                    geneList.Add(Mutate(gene));
                }
                else
                {
                    geneList.Add(gene);
                }
            }
            int rightchoice = random.Next(2);
            for (int i = b; i < n; i++)
            {
                if (random.NextDouble() <= _mutationProbability)
                {
                    geneList.Add(Mutate(new Gene(pair[rightchoice].Genes[i].Value)));
                }
                else
                {

                    geneList.Add(new Gene(pair[rightchoice].Genes[i].Value));
                }
            }
            return new Chromosome(geneList, pair[0].Fitnessfunction);
        }


        public Population createNewPopulation()
        {
            List<Chromosome> newChromosomeList = new List<Chromosome>();


            List<Chromosome> elites = CurrentPopulation.SeparateElite();
            foreach (Chromosome elite in elites)
            {
                newChromosomeList.Add(elite);
            }

            while (newChromosomeList.Count < Size)
            {
                Chromosome newChromosome = CrossOver(CurrentPopulation.ChooseRandomPair());

                newChromosomeList.Add(newChromosome);
            }
            return new Population(newChromosomeList, CurrentPopulation.CurrentIteration + 1);
        }
        public void replacePopulation()
        {
            CurrentPopulation = new Population(NewPopulation.Chromosomes, CurrentPopulation.CurrentIteration);
            NewPopulation = null;
        }
        private Gene Mutate(Gene gene)
        {
            Random random = new Random();
            bool plus = true;
            bool minus = true;
            double r = _mutationProbability * Math.Abs(_max_x - _min_x);
            if (gene.Value + r > _max_x)
                plus = false;
            if (gene.Value - r < _min_x)
                minus = false;
            if (plus && minus)
            {
                //PLUS
                if (random.Next(2) == 1)
                {
                    gene.Value += r;
                }
                //MINUS
                else
                {
                    gene.Value -= r;
                }
            }
            else if (minus)
            {
                gene.Value -= r;

            }
            else if (plus)
            {
                gene.Value += r;
            }
            return gene;
        }
    }
}
