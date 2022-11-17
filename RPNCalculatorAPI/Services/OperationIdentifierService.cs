using RPNCalculatorAPI.IServices;
using RPNCalculatorAPI.Models;

namespace RPNCalculatorAPI.Services
{
    public class OperationIdentifierService : IOperationIdentifier
    {
        public OperationType IdentiftOperationType(string signature)
        {
            OperationType operationType = OperationType.NOT_OPERATOR;
            switch (signature)
            {
                case "+":
                    operationType = OperationType.Add;
                    break;
                case "-":
                    operationType = OperationType.Substract;
                    break;
                case "/":
                    operationType = OperationType.Divide;
                    break;
                case "*":
                    operationType = OperationType.Multiply;
                    break;
                default:
                    operationType = OperationType.NOT_OPERATOR;
                    break;
            }
            return operationType;
                

        }
    }
}
