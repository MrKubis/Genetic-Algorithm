using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Genetic_Algorithm
{
    public class FunctionsProvider
    {


        public static double RastraginFunction(List<double> X)
        {
            double A = 10.0;
            double sum = 0;
            for (int i = 0; i < X.Count; i++)
            {
                sum += X[i] * X[i] - (A * Math.Cos(2 * Math.PI * X[i]));
            }
            sum += A * X.Count;
            return sum;
        }
        public static double RosenbrockFunction(List<double> X)
        {
            double sum = 0;
            for (int i = 0; i < X.Count - 1; i++)
            {
                sum += 100 * Math.Pow(X[i + 1] - Math.Pow(X[i], 2), 2) + Math.Pow(1 - X[i], 2);
            }
            return sum;
        }
        public static double SphereFunction(List<double> X)
        {
            double sum = 0.0;
            for(int i = 0;i < X.Count; i++)
            {
                sum += X[i] * X[i];
            }
            return sum;
        }
        public static double BealeFunction(List<double> X)
        {
            // X.length == 2!!!!
            return  (  Math.Pow(1.5 - X[0] + X[0] * X[1], 2)
                    + Math.Pow(2.25 - X[0] + X[0] * X[1] * X[1], 2)
                    + Math.Pow(2.625 - X[0] + X[0] * X[1] * X[1] * X[1],2)); 
        }

        public static double BukinFunction(List<double> X)
        {
            // X.length == 2!!!!
            return ( 100 * Math.Sqrt(Math.Abs(X[1] - 0.01 * Math.Pow(X[0],2) )) + 0.01 * Math.Abs(X[0]+10));
        }
    }
}
