using Microsoft.AspNetCore.Mvc;

namespace ApiStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        [HttpGet("sum/{firstNum}/{secondNum}")]
        public IActionResult Get(string firstNum, string secondNum)
        {
            if (IsNumeric(firstNum) && IsNumeric(secondNum))
            {
                var sum = ConvertToDecimal(firstNum) + ConvertToDecimal(secondNum);
                return Ok(sum);
            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;
            if (decimal.TryParse(value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string value)
        {
            decimal decimalValue;
            bool isNumber = decimal.TryParse(value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue);
            return isNumber;
        }
    }
}
