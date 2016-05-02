using System.Numerics;

namespace CIDemo.Business
{
    public class IterativeFibonacciCalculator : IFibonacciCalculator
    {
        public string GetNthValue(int n)
        {
            BigInteger fib0 = 0;
            BigInteger fib1 = 1;
            for (int i = 2; i <= n; i++)
            {
                BigInteger tmp = fib0;
                fib0 = fib1;
                fib1 = tmp + fib1;
            }
            var value = (n > 0 ? fib1 : 0);
            return value.ToString();
        }
    }
}