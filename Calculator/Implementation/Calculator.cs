using Calculation.Lib.Interfaces;

namespace Calculation.Lib.Implementation;
public class Calculator : ICalculator
{
    public int Add(int start, int amount) => start + amount;

    public int Subtract(int start, int amount) => start - amount;
}
