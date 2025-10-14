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
        private int _fitnessValue;

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
        public Chromosome(List<Gene> genes, int fitnessValue)
        {
            _genes = genes;
            _isGenePresent = RandomizePresence(genes.Count);
            _fitnessValue = CalculateFitness(genes, _isGenePresent);
        }

        public int CalculateFitness(List<Gene> genes, List<bool> isGenePresent)
        {
            int fitnessValue = 0;
            int weightValue = 0;
            for (int i = 0; i < genes.Count; i++)
            {
                if (isGenePresent[i] == true)
                {
                    fitnessValue += genes[i].Value;
                    weightValue += genes[i].Weight;
                }
            }
            if (weightValue > 1500)
            {
                fitnessValue = 0;
            }
            return fitnessValue;
        }

        public List<bool> RandomizePresence(int quantityOfGenes)
        {
            List<bool> isGenePresent = new List<bool>();
            for (int i = 0; i < quantityOfGenes; i++)
            {
                Random random = new Random();
                if (random.Next(2) % 2 == 0)
                {
                    isGenePresent.Add(false);
                }
                else
                {
                    isGenePresent.Add(true);
                }
            }
            return isGenePresent;
        }
    }
}
