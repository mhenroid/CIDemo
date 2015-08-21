using System.Numerics;

namespace CIDemo.Business
{
    public interface IFibonacciStrategy
    {
        string GetNthValue(int n);
    }
}