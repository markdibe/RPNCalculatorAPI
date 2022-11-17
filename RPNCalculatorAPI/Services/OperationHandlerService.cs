using RPNCalculatorAPI.IServices;
using RPNCalculatorAPI.Models;
using System.Collections.Concurrent;

namespace RPNCalculatorAPI.Services
{
    public class OperationHandlerService : IOperationHandler
    {
        private readonly IOperationIdentifier _identifier;
        private readonly IOperation _operation;
        private readonly ConcurrentStack<int> _stack;
        public OperationHandlerService(IOperationIdentifier identifier, IOperation operation)
        {
            _identifier = identifier;
            _operation = operation;
            _stack = new ConcurrentStack<int>();
        }


        public ConcurrentStack<int> Compute(string input)
        {
            OperationType type = _identifier.IdentiftOperationType(input);
            int operationResult = default(int);
            int firstNumber = default(int);
            int secondNumber = default(int);
            if (type == OperationType.NOT_OPERATOR)
            {
                var isNumber = int.TryParse(input, out operationResult);
            }
            else
            {
                _stack.TryPop(out firstNumber);
                _stack.TryPop(out secondNumber);
            }
            switch (type)
            {
                case OperationType.Add:
                    operationResult = _operation.Add(secondNumber, firstNumber);
                    break;
                case OperationType.Substract:
                    operationResult = _operation.Substract(secondNumber, firstNumber);
                    break;
                case OperationType.Divide:
                    operationResult = _operation.Divide(secondNumber, firstNumber);
                    break;
                case OperationType.Multiply:
                    operationResult = _operation.Multiply(secondNumber, firstNumber);
                    break;
            }
            _stack.Push(operationResult);
            return _stack;
        }
    }
}
