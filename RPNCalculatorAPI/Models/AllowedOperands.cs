namespace RPNCalculatorAPI.Models
{
    public class AllowedOperands
    {
        private string[] allowedOperands = { "/", "*", "-", "+" };
        public string[] Operands
        {
            get { return allowedOperands; }
        }

    }
}
