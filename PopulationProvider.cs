using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    internal class PopulationProvider
    {
        private int _size;
        private List<Gene> _geneList;
        private Population _currentPopulation;
        private Population _newPopulation;
        public Population CurrentPopulation { get { return _currentPopulation; } set { _currentPopulation = value; } }
        public Population NewPopulation { get { return _newPopulation; } set { _newPopulation = value; } }
        public int Size { get { return _size; } set { _size = value; } }
        public List<Gene> GeneList { get { return _geneList; } set { _geneList = value; } }
        public PopulationProvider(int populationSize, List<Gene> geneList)
        {
            //USTAWIA WIELKOSC POPULACJI, LISTĘ GENÓW, OBECNĄ POPULACJĘ 

            _size = populationSize;
            _geneList = geneList;

            List<Chromosome> chromosomes = new List<Chromosome>();
            for (int i = 0; i < populationSize; i++)
            {
                Chromosome chromosome = new Chromosome(_geneList);
                chromosomes.Add(chromosome);
                _currentPopulation = new Population(chromosomes, 0);

            }
        }
        public List<Chromosome> CrossOver(List<Chromosome> pair)
        {
            List<Chromosome> newPair = new List<Chromosome>();
            if (pair[0].IsGenePresent.Count == pair[1].IsGenePresent.Count)
            {
                int len = pair[0].IsGenePresent.Count;
                Random random = new Random();
                int index = random.Next(len);            
                List<bool> gens1 = new List<bool>();
                List<bool> gens2 = new List<bool>();
                for(int i =0; i < index; i++)
                {
                    gens1.Add(pair[0].IsGenePresent[i]);
                    gens2.Add(pair[1].IsGenePresent[i]);
                }
                for(int i = 0;i<len-index; i++)
                {
                    gens1.Add(pair[1].IsGenePresent[index + i]);
                    gens2.Add(pair[0].IsGenePresent[index + i]);
                }
                newPair.Add(new Chromosome(pair[0].Genes,gens1));
                newPair.Add(new Chromosome(pair[0].Genes, gens2));
                return newPair;
            }
            else
            {
                Console.WriteLine("Wait... that's illegal");
                return null;
            }
        }
        public Population createNewPopulation()
        {
            List<Chromosome> newChromosomeList = new List<Chromosome>();
            List<Chromosome> elites = CurrentPopulation.SeparateElite();
            foreach(Chromosome elite in elites) {
                newChromosomeList.Add(elite);
            }
            while (newChromosomeList.Count < CurrentPopulation.Chromosomes.Count)
            {
                {
                    List<Chromosome> crossedPair = CrossOver(CurrentPopulation.ChooseRandomPair());
                    newChromosomeList.Add(crossedPair[0]);
                    newChromosomeList.Add(crossedPair[1]);
                }

            }
            return new Population(newChromosomeList, CurrentPopulation.CurrentIteration + 1);
        }
        public void replacePopulation()
        {
            CurrentPopulation = new Population(NewPopulation.Chromosomes, CurrentPopulation.CurrentIteration);
            NewPopulation = null;
        }
    }
}
