using Genetic_Algorithm;
using System;

const int POPULATION_SIZE = 20;
const int MAXIMUM_NUMBER_OF_ITERATIONS = 20;

//Z ŁAPY
List<Gene> genes = new List<Gene>() 
{ new Gene(200, 20), new Gene(400, 30), new Gene(500, 10), new Gene(200, 60), new Gene(1000, 70), new Gene(660, 70), new Gene(300, 40), new Gene(100, 150) };
//

PopulationProvider populationProvider = new PopulationProvider(POPULATION_SIZE, genes);

//GENERATIONS
for (int i = 0; i < MAXIMUM_NUMBER_OF_ITERATIONS; i++)
{
    Console.WriteLine("NEW POPULATION!!!");
    foreach(Chromosome chromosome in populationProvider.CurrentPopulation.Chromosomes)
    {
        foreach(bool ispresent in chromosome.IsGenePresent)
        {
            Console.Write(ispresent ? "1" : "0");
        }
        Console.WriteLine();
        Console.WriteLine("Fitness score: " + chromosome.FitnessValue.ToString());
    }
    populationProvider.NewPopulation = populationProvider.createNewPopulation();
    populationProvider.replacePopulation();
    // TO JEST ZLE ALE CHODZI MI TU O TO ZEBY NADPISAC OBECNA POPULACJE TĄ NOWĄ
    
}