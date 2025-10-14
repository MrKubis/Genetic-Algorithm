# Genetic Algorithm

A clear, multi-class, object-oriented framework for understanding and implementing a simple Genetic Algorithm (GA) in C#. This project is designed to find a binary string (a sequence of 0s and 1s) containing the maximum possible number of 1s.

## Project Goal

The primary goal is to provide an easy-to-understand and extensible structure for a genetic algorithm. By separating concerns into distinct classes (`Individual`, `Population`, `GeneticAlgorithm`), the code is clean, reusable, and simple to modify for other optimization problems.

---

## Project Structure

The framework is built around four main classes, each with a specific responsibility.

### `Individual.cs`
Represents a single candidate solution in the population.

* **Responsibilities:**
    * `byte[] Genes`: An array holding the chromosome (e.g., `[0, 1, 1, 0, 1]`).
    * `int Fitness`: A property representing the quality of the solution.
* **Key Methods & Properties:**
    * `public Individual(int geneLength)`: Creates an individual with a random chromosome.
    * `public void CalculateFitness()`: Calculates the fitness score. For this project, it simply counts the number of `1`s in the `Genes` array.
    * `public int Fitness { get; private set; }`: A property to get the fitness score.

### `Population.cs`
Manages a collection of `Individual` objects.

* **Responsibilities:**
    * `Individual[] Individuals`: An array or `List<Individual>` to store all individuals of the current generation.
* **Key Methods:**
    * `public Population(int populationSize, int geneLength, bool initialize)`: Creates a population. If `initialize` is true, it populates itself with new random individuals.
    * `public Individual GetFittest()`: Finds and returns the individual with the highest fitness score in the population.
    * `public int Size()`: Returns the number of individuals in the population.

### `GeneticAlgorithm.cs`
The core engine that drives the evolutionary process. It contains all the genetic operators.

* **Responsibilities:**
    * Manages algorithm parameters like `MutationRate`, `CrossoverRate`, and `TournamentSize`.
    * Implements the logic for evolving one population into the next.
* **Key Methods:**
    * `public Population EvolvePopulation(Population currentPop)`: The main method that takes a population and returns a new, evolved generation.
    * `private Individual Crossover(Individual parent1, Individual parent2)`: Combines the genes from two parents to create a new offspring.
    * `private void Mutate(Individual individual)`: Randomly flips bits in an individual's chromosome based on the `MutationRate`.
    * `private Individual TournamentSelection(Population pop)`: Selects the fittest individuals to be parents for the next generation.

### `Program.cs`
The entry point of the application. It initializes the algorithm and manages the overall generation loop.

* **Responsibilities:**
    * Contains the `Main` method.
    * Initializes the `GeneticAlgorithm` and the initial `Population`.
    * Runs the evolution loop for a fixed number of generations.
    * Prints the progress and the final result to the console.

---

## How It Works

1. Start: Initial Population
The algorithm begins by creating a set of completely random solutions to the problem. This initial set is called the first generation or initial population.

2. Fitness Evaluation
Each individual solution in the population is evaluated to see how well it solves the problem. This is done using a fitness function, which assigns a score to each solution. A higher score means a better solution.

3. Selection
The "fittest" individuals are selected to become parents for the next generation. Solutions with higher fitness scores have a greater chance of being chosen. This step mimics the principle of "survival of the fittest."

4. Crossover (Reproduction)
Pairs of selected "parents" exchange parts of their information to create new solutions, called "offspring." The idea is that combining two good solutions might create an even better one.

5. Mutation
To introduce new possibilities and prevent the algorithm from getting stuck, small, random changes are made to some of the new offspring. This is the mutation step.

6. Create New Population & Repeat
The newly created offspring form the next generation. This new population replaces the old one, and the entire cycle—evaluation, selection, crossover, and mutation—repeats. The loop continues until a satisfactory solution is found or a set number of generations has passed.
---

## Customization

This framework can be easily adapted to solve other problems:

* **Change the Fitness Function**: Modify the `CalculateFitness()` method in the `Individual.cs` class to evaluate a different problem.
* **Adjust Parameters**: Tweak the `MutationRate`, `CrossoverRate`, `TournamentSize`, and population size in the `Program.cs` and `GeneticAlgorithm.cs` classes to fine-tune performance.
* **Modify Representation**: Change the `byte[] Genes` to another data structure if your problem requires it (e.g., an array of integers or custom objects).
