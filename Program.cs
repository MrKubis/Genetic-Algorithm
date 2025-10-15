using Genetic_Algorithm;
using System;

const int POPULATION_SIZE = 10;
const int MAXIMUM_NUMBER_OF_ITERATIONS = 20;

//Z ŁAPY
List<Gene> genes = new List<Gene>() 
{ new Gene(200, 20), new Gene(400, 30), new Gene(500, 10), new Gene(200, 60), new Gene(1000, 70) };
//

PopulationProvider populationProvider = new PopulationProvider(POPULATION_SIZE, genes);

//GENERATIONS
for (int i = 0; i < MAXIMUM_NUMBER_OF_ITERATIONS; i++)
{
    // TO JEST ZLE ALE CHODZI MI TU O TO ZEBY NADPISAC OBECNA POPULACJE TĄ NOWĄ
    populationProvider.CurrentPopulation = populationProvider.NewPopulation;
    populationProvider.NewPopulation = new Population(populationProvider.CurrentPopulation.SeparateElite(),populationProvider.CurrentPopulation.CurrentIteration + 1);
    populationProvider.CurrentPopulation = new Population(populationProvider.CurrentPopulation.DropElite(), populationProvider.CurrentPopulation.CurrentIteration);

    populationProvider.createNewPopulation();
}