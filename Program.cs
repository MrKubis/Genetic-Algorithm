using Genetic_Algorithm;
using System;

const int POPULATION_SIZE = 10;
const int MAXIMUM_NUMBER_OF_ITERATIONS = 20;

List<Gene> genes = new List<Gene>() 
{ new Gene(200, 20), new Gene(400, 30), new Gene(500, 10), new Gene(200, 60), new Gene(1000, 70) };
List<Chromosome> chromosomes = new List<Chromosome>();
for (int i = 0; i < POPULATION_SIZE; i++)
{
    Chromosome chromosome = new Chromosome(genes, 0);
    chromosomes.Add(chromosome);
}
Population population = new Population(chromosomes, 0);