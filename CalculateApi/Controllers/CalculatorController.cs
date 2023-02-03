using Calculation.Lib.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculateApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CalculatorController: ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;
    private readonly ICalculator _calculator;

    public CalculatorController(ILogger<CalculatorController> logger, ICalculator calculator)
    {
        _logger = logger;
        _calculator = calculator;
    }

    [HttpGet]
    public int Calculate(int start, int amount, string operationType)
    {
        int result;
        if (operationType == "add")
        {
            result = _calculator.Add(start, amount);
        }
        else
        {
            result = _calculator.Subtract(start, amount);
        }
        _logger.LogInformation($"Subtract called with start {start}, amount {amount} returning {result}");
        return result;
    }
}
