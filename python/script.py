import csv
import subprocess
import os


functions = [
    'Rastrigin',
    'Rosenbrock',
    'Sphere',
    'Beale',
    'Bukin'
]

dimensions = [
    3, 5, 10
]

population_sizes = [
    10, 20, 40, 80
]
iteration_numbers = [
    5, 10, 20, 40, 60, 80, 100, 1000
]

file_name = "result.csv"
dir_name = os.getcwd()
parent_dir = os.path.join(dir_name, os.pardir)
final_directory = os.path.join(os.path.abspath(parent_dir), 'bin\\Debug\\net8.0\\Genetic-Algorithm.exe')

with open(file_name, 'w') as f:
    writer = csv.writer(f, delimiter=';')
    writer.writerow(["Algorytm","Funkcja testowa","Liczba szukanych parametrów", "Prawdopobieństwo mutacji", "Prawdopobieństwo crossover",	"Liczba iteracji",	"Rozmiar populacji",	"Znalezione minimum",	"Średnia wartość znalezionych parametrów",	"Odchylenie standardowe znalezionych parametrów", "Wartość funkcji celu"	,"Odchylenie standardowe funkcji celu"])
    for function in functions:
        for population_size in population_sizes:
            for iteration_number in iteration_numbers:
                result = subprocess.run([
                    final_directory,
                    str(function),
                    str('2'),
                    str(population_size),
                    str(iteration_number)
                ],
                capture_output=True,
                text=True)
                f.write(str(result.stdout))

    functions.remove('Beale')
    functions.remove('Bukin')
    for function in functions:
        for dimension in dimensions:
            for population_size in population_sizes:
                for iteration_number in iteration_numbers:
                    result = subprocess.run([
                        final_directory,
                        str(function),
                        str(dimension),
                        str(population_size),
                        str(iteration_number)
                    ],
                    capture_output=True,
                    text=True)
                    f.write(str(result.stdout))

print("Done")