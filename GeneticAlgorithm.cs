namespace Genetic_Algorithm
{
    public class GeneticAlgorithm : IOptimizationAlgorithm
    {
        private int _populationSize;
        private int _maxIterations;
        private int _geneCount;
        private double[] _range; // tablica - pierwsza wartość to min, druga to max
        private Func<List<double>, double> _fitnessFunction; // funkcja celu i funkcja dopasowania to u nas to samo
        private double _mutationProbability;
        private double _crossoverProbability;

        public string Name { get; set; } = "Genetic Algorithm";

        public List<double> XBest { get; set; } = new List<double>();
        public double FBest { get; set; }
        public int NumberOfEvaluationFitnessFunction { get; set; }
        public double Solve()
        {
            PopulationProvider populationProvider = new PopulationProvider
                (_populationSize, _geneCount, _range[0], _range[1], _fitnessFunction, _mutationProbability, _crossoverProbability);
            for (int i = 0; i < _maxIterations; i++)
            {
                populationProvider.NewPopulation = populationProvider.createNewPopulation();
                populationProvider.replacePopulation();
            }
            FBest = populationProvider.CurrentPopulation.SeparateElite()[0].FitnessValue;
            List<Gene> genesOfBest = populationProvider.CurrentPopulation.SeparateElite()[0].Genes;
            for (int i = 0; i < _geneCount; i++)
            {
                XBest.Add(genesOfBest[i].Value);
            }
            return FBest;
        }

        public GeneticAlgorithm(int populationSize, int maxIterations,
            int geneCount, double[] range, Func<List<double>, double> fitnessFunction,
            double mutationProbability, double crossoverProbability)
        {
            _populationSize = populationSize;
            _maxIterations = maxIterations;
            _geneCount = geneCount;
            _range = range;
            _fitnessFunction = fitnessFunction;
            _mutationProbability = mutationProbability;
            _crossoverProbability = crossoverProbability;
            Counter counter = new Counter();
        }
    }
}
