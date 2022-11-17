using Moq;
using RPNCalculatorAPI.CustomExceptions;
using RPNCalculatorAPI.IServices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPNCalulatorTest
{
    public class OperationHandlerTest
    {
        private readonly Mock<IOperationHandler> _operationHandler;
        private readonly ConcurrentStack<int> stack;
        public OperationHandlerTest()
        {
            _operationHandler = new Mock<IOperationHandler>();
            stack = new ConcurrentStack<int>();
        }

        [Fact]
        public void ShouldInsertANumberInStack()
        {
            string input = "2";
            stack.Push(2);
            _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        }

        [Fact]
        public void ShouldInsertAnotherNumberInStack()
        {
            string input = "5";
            stack.Push(5);
            _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        }

        [Fact]

        public void ShouldAddTheTwoNumbers()
        {
            //the result should be 7
            string input = "+";
            stack.TryPop(out int firstNumber);
            stack.TryPop(out int secondNumber);
            int result = firstNumber + secondNumber;
            stack.Push(result);
            _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        }

        [Fact]
        public void ShouldSubstractTheTwoNumbers()
        {
            //the result should be 4
            string input = "3";
            _operationHandler.Setup(x => x.Compute(input));
            input = "-";
            stack.TryPop(out int aNumber);
            int result = aNumber + 3;
            stack.Push(result);
            _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        }

        [Fact]
        public void ShouldMultiplyTwoNumbers()
        {
            //result should be 16
            string input = "4";
            stack.Push(4);
            _operationHandler.Setup(x => x.Compute(input));
            input = "*";
            stack.TryPop(out int aNumber);
            int result = aNumber * 4;
            stack.Push(result);
            _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        }

        [Fact]
        public void ShouldDivideTwoNumbers()
        {
            // result should be 8
            string input = "2";
            stack.Push(2);
            _operationHandler.Setup(x => x.Compute(input));
            input = "/";
            stack.TryPop(out int aNumber);
            int result = aNumber / 2;
            stack.Push(result);
            _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        }

        [Fact]
        public void ShouldThrowException()
        {
            string input = "/";
            _operationHandler.Setup(x => x.Compute(input))
                .Throws(new NotEnoughNumbersException(string.Empty));
        }

    }
}
