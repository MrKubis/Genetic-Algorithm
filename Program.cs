using Genetic_Algorithm;
using System;

const int POPULATION_SIZE = 40;
const int MAXIMUM_NUMBER_OF_ITERATIONS = 5000;
const int GENE_COUNT = 2;
const double MIN_X = -5.12;
const double MAX_X = 5.12;
double RastraginFunction(List<double> X)
{
    double A = 10.0;
    double sum = 0;
    for (int i = 0; i < X.Count; i++)
    {
        sum += X[i] * X[i] - (A * Math.Cos(2 * Math.PI * X[i]));
    }
    sum += A * X.Count;
    return 1 / sum;
}


List<Chromosome> GAChromosomes = new List<Chromosome>();
for (int j = 0; j < 40; j++)
{
    PopulationProvider populationProvider = new PopulationProvider(POPULATION_SIZE, GENE_COUNT, MIN_X, MAX_X, RastraginFunction);
    for (int i = 0; i < MAXIMUM_NUMBER_OF_ITERATIONS; i++)
    {
        populationProvider.NewPopulation = populationProvider.createNewPopulation();
        populationProvider.replacePopulation();
    }
    List<Chromosome> elites = populationProvider.CurrentPopulation.SeparateElite();
    GAChromosomes.Add(elites[0]);
}

foreach (Chromosome chromosome in GAChromosomes)
{
    Console.WriteLine(chromosome.ToString());
}

