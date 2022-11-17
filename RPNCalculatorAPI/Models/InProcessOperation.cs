
namespace RPNCalculatorAPI.Models
{
    public class InProcessOperation
    {
        public InProcessOperation(int firstNumber, int secondNumber, int operationResult, OperationType operationType)
        {
            this.FirstNumber = firstNumber;
            this.SecondNumber = secondNumber;
            this.OperationType = operationType;
            this.OperationResult = operationResult;
        }
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public int OperationResult { get; set; }

        public OperationType OperationType { get; set; }


    }
}
