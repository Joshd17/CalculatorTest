using Calculation.Lib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        if (operationType == "add")//This could be refactored into a service and httpstatuscode handling added
        {
            result = _calculator.Add(start, amount);
        }
        else if(operationType == "subtract")
        {
            result = _calculator.Subtract(start, amount);
        }
        else
        {
            throw new NotSupportedException($"Invalid operation type {operationType}");
        }
        _logger.LogInformation($"called with start {start}, amount {amount} returning {result}");
        return result;
    }
}
