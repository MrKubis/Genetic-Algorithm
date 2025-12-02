using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    public class GeneticAlgorithm : IOptimizationAlgorithm
    {

        private int _populationSize;
        private int _maxIterations;
        private double _mutationProbability;
        private double _crossoverProbability;


        public string Name = "Genetic Algorithm";
        public double[] XBest;
        public double FBest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NumberOfEvaluationFitnessFunction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IOptimizationAlgorithm.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double[] IOptimizationAlgorithm.XBest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        // Zwraca warto ś ć funkcji celu dla znalezionego rozwi ą zania
        // ( najlepszego osobnika )
        public double Solve()
        {
            throw new NotImplementedException();
        }

        public GeneticAlgorithm(int populationSize,int maxIterations, double mutationProbability, double crossoverProbability)
        {
            _populationSize = populationSize;
            _maxIterations = maxIterations;
            _mutationProbability = mutationProbability;
            _crossoverProbability = crossoverProbability;


        }

    }
}
