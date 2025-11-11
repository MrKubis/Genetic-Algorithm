import csv
import subprocess



functions = [
    'Rastragin',
    'Rosenbrock',
    'Sphere',
    'Beale',
    'Bukin'
]
population_sizes = [
    5,10,20,40,80
]
iteration_numbers = [
    5,10,20,40,60,80
]
filename = "result.csv"
with open(filename, 'w') as f:
    writer = csv.writer(f, delimiter=';')
    writer.writerow(["Alogrytm","Funkcja testowa","Liczba szukanych parametrów","p1 - prawdopodobienstwo mutacji",	"Liczba iteracji",	"Rozmiar populacji",	"Znalezione minimum",	"Średnia wartość znalezionych parametrów",	"Odchylenie standardowe znalezionych parametrów", "Wartość funkcji celu"	,"Odchylenie standardowe funkcji celu"])
    for function in functions:
        for population_size in population_sizes:
            for iteration_number in iteration_numbers:
                result = subprocess.run([
                    r"C:\Users\jakub\Documents\GitHub\GeneticAlgorithm\bin\Debug\net8.0\Genetic-Algorithm.exe",
                    str(function),
                    str(population_size),
                    str(iteration_number)
                ],
                capture_output=True,
                text=True)
                f.write(str(result.stdout))
                f.write("\n")

print("Done")