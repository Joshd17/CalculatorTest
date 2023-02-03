using Xunit;
using Calculation.Lib.Implementation;
using FluentAssertions;

namespace UnitTests.CalculatorTests;

public class CalculatorTests
{
    private readonly Calculator _target;

    public CalculatorTests()
    {
        _target = new Calculator();
    }

    //Add tests
    [Theory]
    [InlineData(5, 5, 10)]
    [InlineData(5, 2, 7)]
    [InlineData(5, 0, 5)]
    [InlineData(0, 2, 2)]

    public void Add_WithTwoPositiveOrZeroNumbers_Calculates(int start, int amount, int expected)
    {
        var result = _target.Add(start, amount);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-5, -5, -10)]
    [InlineData(-5, -2, -7)]

    public void Add_WithTwoNegativeNumbers_Calculates(int start, int amount, int expected)
    {
        var result = _target.Add(start, amount);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-5, 5, 0)]
    [InlineData(5, -2, 3)]
    [InlineData(0, -2, -2)]

    public void Add_WithOneNegativeNumbers_Calculates(int start, int amount, int expected)
    {
        var result = _target.Add(start, amount);

        result.Should().Be(expected);
    }

    //Subtract tests
    [Theory]
    [InlineData(5, 5, 0)]
    [InlineData(5, 2, 3)]
    [InlineData(5, 0, 5)]
    [InlineData(0, 2, -2)]

    public void Subtract_WithTwoPositiveOrZeroNumbers_Calculates(int start, int amount, int expected)
    {
        var result = _target.Subtract(start, amount);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-5, -5, 0)]
    [InlineData(-5, -2, -3)]

    public void Subtract_WithTwoNegativeNumbers_Calculates(int start, int amount, int expected)
    {
        var result = _target.Subtract(start, amount);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-5, 5, -10)]
    [InlineData(5, -2, 7)]
    [InlineData(0, -2, 2)]

    public void Subtract_WithOneNegativeNumbers_Calculates(int start, int amount, int expected)
    {
        var result = _target.Subtract(start, amount);

        result.Should().Be(expected);
    }
}
