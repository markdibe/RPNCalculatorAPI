using RPNCalculatorAPI.Models;

namespace RPNCalculatorAPI.IServices
{
    public interface IOperationIdentifier
    {
        public OperationType IdentiftOperationType(string signature);
    }
}
