using ApiStudy.Model;
using ApiStudy.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("[action]/{firstNum}/{secondNum}")]
        public Calculator Sum(decimal firstNum, decimal secondNum)
        {
            return _calculatorService.Sum(firstNum, secondNum);
        }

        [HttpGet("[action]/{firstNum}/{secondNum}")]
        public Calculator Subtract(decimal firstNum, decimal secondNum)
        {
            return _calculatorService.Subtract(firstNum, secondNum);
        }

        [HttpGet("[action]/{firstNum}/{secondNum}")]
        public Calculator Multiply(decimal firstNum, decimal secondNum)
        {
            return _calculatorService.Multiply(firstNum, secondNum);
        }

        [HttpGet("[action]/{firstNum}/{secondNum}")]
        public Calculator Division(decimal firstNum, decimal secondNum)
        {
            return _calculatorService.Division(firstNum, secondNum);
        }

        [HttpGet("[action]/{firstNum}/{secondNum}")]
        public Calculator Mean(decimal firstNum, decimal secondNum)
        {
            return _calculatorService.Mean(firstNum, secondNum); ;
        }

        [HttpGet("[action]/{value}")]
        public Calculator SquareRoot(double value)
        {
            return _calculatorService.SquareRoot(value); ;
        }
    }
}
