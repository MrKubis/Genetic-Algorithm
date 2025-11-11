using Genetic_Algorithm;
using System;
using System.Xml.Linq;

const int POPULATION_SIZE = 30;
const int MAXIMUM_NUMBER_OF_ITERATIONS = 15;
const int GENE_COUNT = 2;
const double MIN_X = -4.5;
const double MAX_X = 4.5;

double calculateMean(List<double> x)
{
    double mean = 0;
    for (int i = 0; i < x.Count; i++)
    {
        mean += x[i];
    }
    mean /= x.Count;
    return mean;
}
double calculateDeviation(List<double>x)
{
    double mean = calculateMean(x);
    double sum = 0;
    for (int i = 0; i < x.Count; i++) {
        sum += Math.Pow(x[i] - mean, 2);
    }
    return sum/ (x.Count - 1);


List<Chromosome> GAChromosomes = new List<Chromosome>();
for (int j = 0; j < 10; j++)
{
    PopulationProvider populationProvider = new PopulationProvider(POPULATION_SIZE, GENE_COUNT, MIN_X, MAX_X, FunctionsProvider.RastraginFunction, 0.15);
    for (int i = 0; i < MAXIMUM_NUMBER_OF_ITERATIONS; i++)
    {
        populationProvider.NewPopulation = populationProvider.createNewPopulation();
        populationProvider.replacePopulation();
    }
    List<Chromosome> elites = populationProvider.CurrentPopulation.SeparateElite();
    GAChromosomes.Add(elites[0]);
}



double max = 0;
Chromosome bestChromosome = null;
foreach (Chromosome chromosome in GAChromosomes)
{
    if(chromosome.FitnessValue > max)
    {
        bestChromosome = chromosome;
    }
}
Console.Write(MAXIMUM_NUMBER_OF_ITERATIONS + " ");
Console.Write(POPULATION_SIZE + " ");
Console.Write(bestChromosome);



