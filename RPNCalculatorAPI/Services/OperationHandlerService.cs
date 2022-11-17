using RPNCalculatorAPI.CustomExceptions;
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
            InProcessOperation p = CheckInput(input);

            switch (p.OperationType)
            {
                case OperationType.Add:
                    p.OperationResult = _operation.Add(p.SecondNumber, p.FirstNumber);
                    break;
                case OperationType.Substract:
                    p.OperationResult = _operation.Substract(p.SecondNumber, p.FirstNumber);
                    break;
                case OperationType.Divide:
                    p.OperationResult = _operation.Divide(p.SecondNumber, p.FirstNumber);
                    break;
                case OperationType.Multiply:
                    p.OperationResult = _operation.Multiply(p.SecondNumber, p.FirstNumber);
                    break;
            }
            _stack.Push(p.OperationResult);
            return _stack;
        }

        private InProcessOperation CheckInput(string input)
        {
            OperationType type = _identifier.IdentiftOperationType(input);
            int operationResult = default(int);
            int firstNumber = default(int);
            int secondNumber = default(int);
            bool isFirst = false;
            bool isSecond = false;
            if (type == OperationType.NOT_OPERATOR)
            {
                int.TryParse(input, out operationResult);
            }
            else
            {
                isFirst = _stack.TryPop(out firstNumber);
                isSecond = _stack.TryPop(out secondNumber);
                if (!(isFirst && isSecond))
                {
                    throw new NotEnoughNumbersException("You can not use an operator before entering at least two consecutive numbers!");
                }
            }
            InProcessOperation inProcessOperation = new InProcessOperation(firstNumber, secondNumber, operationResult, type);
            return inProcessOperation;
        }

    }
}
