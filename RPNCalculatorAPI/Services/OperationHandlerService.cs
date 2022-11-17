using RPNCalculatorAPI.CustomExceptions;
using RPNCalculatorAPI.IServices;
using RPNCalculatorAPI.Models;
using System.Collections.Concurrent;
using System.Linq;

namespace RPNCalculatorAPI.Services
{
    public class OperationHandlerService : IOperationHandler
    {
        private readonly IOperationIdentifier _identifier;
        private readonly IOperation _operation;
        private readonly ConcurrentDictionary<int, ConcurrentStack<int>> _stackDictionary;
        public OperationHandlerService(IOperationIdentifier identifier, IOperation operation)
        {
            _identifier = identifier;
            _operation = operation;
            _stackDictionary = new ConcurrentDictionary<int, ConcurrentStack<int>>();
        }
        public void CreateNew()
        {
            var keys = _stackDictionary.Keys;
            int newId = 1;
            if (keys.Count > 0)
            {
                newId = keys.Max() + 1;
            }
            _stackDictionary[newId] = new ConcurrentStack<int>();
        }
        public ConcurrentStack<int> GetStack(int id)
        {
            bool existed = _stackDictionary.TryGetValue(id, out var operands);
            if (!existed)
            {
                throw new NotExistedStack("This stack number does not exists!");
            }
            return operands;
        }

        public void DeleteStack(int id)
        {
            bool canDelete = _stackDictionary.TryRemove(id, out var removedStack);
            if (!canDelete)
            {
                throw (new NotExistedStack("This Stack Can not be deleted!"));
            }
        }

        public ConcurrentStack<int> Compute(string input, int id)
        {
            InProcessOperation p = CheckInput(input, id);
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
            var _stack = GetStack(id);
            _stack.Push(p.OperationResult);
            return _stack;
        }


        private InProcessOperation CheckInput(string input, int id)
        {
            var _stack = GetStack(id);
            OperationType type = _identifier.IdentiftOperationType(input);
            int operationResult = default(int);
            int firstNumber = default(int);
            int secondNumber = default(int);

            if (type == OperationType.NOT_OPERATOR)
            {
                int.TryParse(input, out operationResult);
            }
            else
            {
                bool isFirst = _stack.TryPop(out firstNumber);
                bool isSecond = _stack.TryPop(out secondNumber);
                if (!(isFirst && isSecond))
                {
                    throw new NotEnoughNumbersException("You can not use an operator before entering at least two consecutive numbers!");
                }
            }
            InProcessOperation inProcessOperation = new InProcessOperation(firstNumber, secondNumber, operationResult, type);
            return inProcessOperation;
        }

        public ConcurrentDictionary<int, ConcurrentStack<int>> GetDictionary()
        {
            return _stackDictionary;
        }
    }
}
