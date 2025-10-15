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
        public Population createNewPopulation()
        {
            //CREATES NEW POPULATION
            
        }
    }
}
