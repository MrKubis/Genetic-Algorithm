namespace Genetic_Algorithm
{
    class Chromosome
    {

        private Func<List<double>, double> _fitnessfunction;

        public Func<List<double>, double> Fitnessfunction { get { return _fitnessfunction; } }
        private List<Gene> _genes;
        private double _fitnessValue;

        public List<Gene> Genes
        {
            get { return _genes; }
            set { _genes = value; }
        }

        public double FitnessValue
        {
            get { return _fitnessValue; }
            set { _fitnessValue = value; }
        }
        public Chromosome(List<Gene> genes, Func<List<double>, double> func)
        {
            _genes = genes;
            _fitnessfunction = func;
            _fitnessValue = CalculateFitness();
        }

        public double CalculateFitness()
        {
            List<double> X = new List<double>();
            foreach (Gene gene in _genes)
            {
                X.Add(gene.Value);
            }
            return _fitnessfunction(X);
        }

        public override string ToString()
        {
            string result = "(";
            for (int i = 0; i < _genes.Count; i++)
            {
                if(i == _genes.Count -1)
                    result += _genes[i].Value.ToString();

                else
                   result += _genes[i].Value.ToString() + ", ";
            }
            result += ")";
            return result;
        }
    }
}
