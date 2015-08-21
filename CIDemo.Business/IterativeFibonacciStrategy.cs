using System;
using System.Globalization;
using System.Numerics;

namespace CIDemo.Business
{
    public class IterativeFibonacciStrategy : IFibonacciStrategy
    {
        public string GetNthValue(int n)
        {
            BigInteger a = 0;
            BigInteger b = 1;
            for (int i = 0; i < n; i++)
            {
                BigInteger temp = a;
                a = b;
                b = temp + b;
            }
            return a.ToString(CultureInfo.InvariantCulture);
        }
    }
}