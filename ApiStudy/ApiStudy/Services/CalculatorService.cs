using ApiStudy.Model;

namespace ApiStudy.Services
{
    public class CalculatorService
    {
        public Calculator Sum(decimal firstNum, decimal secondNum) => new Calculator(firstNum + secondNum);
        public Calculator Subtract(decimal firstNum, decimal secondNum) => new Calculator(firstNum - secondNum);
        public Calculator Multiply(decimal firstNum, decimal secondNum) => new Calculator(firstNum * secondNum);
        public Calculator Division(decimal firstNum, decimal secondNum)
        {
            if (secondNum == 0) throw new DivideByZeroException("Denominator cannot be zero.");
            return new Calculator(firstNum / secondNum);
        }
        public Calculator Mean(decimal firstNum, decimal secondNum) => new Calculator((firstNum + secondNum) / 2);
        public Calculator SquareRoot(double value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value cannot be negative.");
            return new Calculator((decimal) Math.Sqrt(value));
        }
    }
}
