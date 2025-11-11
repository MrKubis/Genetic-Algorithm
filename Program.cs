using Genetic_Algorithm;
using System;
using System.Xml.Linq;

Func<List<double>, double> fitnessfunction;

switch (args[0])
{
    case "Rastragin":
        { 
            fitnessfunction = FunctionsProvider.RastraginFunction; break;
        }
    case "Rosenbrock":
        {
            fitnessfunction =FunctionsProvider.RosenbrockFunction; break;
        }
    case "Sphere":
        {
            fitnessfunction=FunctionsProvider.SphereFunction; break;
        }
    case "Beale":
        {
            fitnessfunction=FunctionsProvider.BealeFunction; break;
        }
    case "Bukin":
        {
            fitnessfunction=FunctionsProvider.BukinFunction; break;
        }
    default:
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            System.Environment.Exit(1);
            break;
        }

}



int POPULATION_SIZE = int.Parse(args[1]);
int MAXIMUM_NUMBER_OF_ITERATIONS = int.Parse(args[2]);
double mutationProbbability = 0.15;
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
    for (int i = 0; i < x.Count; i++)
    {
        sum += Math.Pow(x[i] - mean, 2);
    }
    return sum / (x.Count - 1);

}

List<Chromosome> GAChromosomes = new List<Chromosome>();
for (int j = 0; j < 10; j++)
{
    PopulationProvider populationProvider = new PopulationProvider(POPULATION_SIZE, GENE_COUNT, MIN_X, MAX_X, FunctionsProvider.RastraginFunction,mutationProbbability);
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
//Choosing the best chromosome
foreach (Chromosome chromosome in GAChromosomes)
{
    if(chromosome.FitnessValue > max)
    {
        bestChromosome = chromosome;
    }
}

List<double> means = new List<double>();
List<double> deviations = new List<double>();
for(int i = 0; i < GENE_COUNT; i++)
{
    List<double> X = new List<double>();
    foreach(Chromosome chromosome in GAChromosomes)
    {
        X.Add(chromosome.Genes[i].Value);
    }
    means.Add(calculateMean(X));
    deviations.Add(calculateDeviation(X));
}

List<double> fitness_values = new List<double>();
foreach (Chromosome chromosome in GAChromosomes)
{
    fitness_values.Add(chromosome.FitnessValue);
}
double mean_fitness = calculateMean(fitness_values);
double deviation_fitness = calculateDeviation(fitness_values);

Console.Write("GA");
Console.Write(";");

Console.Write(args[0]);
Console.Write(";");

Console.Write(GENE_COUNT);
Console.Write(";");

Console.Write(mutationProbbability);
Console.Write(";");

Console.Write(MAXIMUM_NUMBER_OF_ITERATIONS);
Console.Write(";");

Console.Write(POPULATION_SIZE);
Console.Write(";");

Console.Write(bestChromosome);
Console.Write(";");

Console.Write("(");
for(int i =0;  i<means.Count;i++)
{
    Console.Write(means[i]);
    if(i< means.Count-1)
    Console.Write(", ");
}
Console.Write(")");
Console.Write(";");

Console.Write("(");
for (int i = 0; i < deviations.Count; i++)
{
    Console.Write(deviations[i]);
    if (i < deviations.Count - 1)
        Console.Write(", ");
}
Console.Write(")");
Console.Write(";");
Console.Write(bestChromosome.FitnessValue);
Console.Write(";");
Console.Write(mean_fitness);
Console.WriteLine();


