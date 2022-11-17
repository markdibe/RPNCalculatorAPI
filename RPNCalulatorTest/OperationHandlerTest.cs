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
using Xunit.Priority;

namespace RPNCalulatorTest
{
    public class OperationHandlerTest
    {
        private readonly Mock<IOperationHandler> _operationHandler;
        private static readonly ConcurrentDictionary<int, ConcurrentStack<int>> stack = new ConcurrentDictionary<int, ConcurrentStack<int>>();
        public OperationHandlerTest()
        {
            _operationHandler = new Mock<IOperationHandler>();
           
        }

        [Fact,Priority(1)]
        public void ShouldAddANewStack()
        {
            _operationHandler.Setup(x => x.CreateNew());
            stack[1] = new ConcurrentStack<int>();
            _operationHandler.Setup(x => x.GetDictionary()).Returns(stack);
        }

        //[Fact, Priority(2)]
        //public void ShouldInsertANumberInStack()
        //{
        //     _operationHandler.Setup(x => x.CreateNew());
        //    stack[1] = new ConcurrentStack<int>();
        //    string input = "2";
        //    stack[1].Push(2);
        //    _operationHandler.Setup(x => x.Compute(input, 1));
        //    _operationHandler.Setup(x => x.GetStack(1)).Returns(stack[1]);
        //}

        //[Fact, Priority(3)]
        //public void ShouldInsertAnotherNumberInStack()
        //{
        //    string input = "5";
        //    stack[1].Push(5);
        //    _operationHandler.Setup(x => x.Compute(input,1));
        //    _operationHandler.Setup(x => x.GetStack(1)).Returns(stack[1]);
        //}

        //[Fact]

        //public void ShouldAddTheTwoNumbers()
        //{
        //    //the result should be 7
        //    string input = "+";
        //    stack.TryPop(out int firstNumber);
        //    stack.TryPop(out int secondNumber);
        //    int result = firstNumber + secondNumber;
        //    stack.Push(result);
        //    _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        //}

        //[Fact]
        //public void ShouldSubstractTheTwoNumbers()
        //{
        //    //the result should be 4
        //    string input = "3";
        //    _operationHandler.Setup(x => x.Compute(input));
        //    input = "-";
        //    stack.TryPop(out int aNumber);
        //    int result = aNumber + 3;
        //    stack.Push(result);
        //    _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        //}

        //[Fact]
        //public void ShouldMultiplyTwoNumbers()
        //{
        //    //result should be 16
        //    string input = "4";
        //    stack.Push(4);
        //    _operationHandler.Setup(x => x.Compute(input));
        //    input = "*";
        //    stack.TryPop(out int aNumber);
        //    int result = aNumber * 4;
        //    stack.Push(result);
        //    _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        //}

        //[Fact]
        //public void ShouldDivideTwoNumbers()
        //{
        //    // result should be 8
        //    string input = "2";
        //    stack.Push(2);
        //    _operationHandler.Setup(x => x.Compute(input));
        //    input = "/";
        //    stack.TryPop(out int aNumber);
        //    int result = aNumber / 2;
        //    stack.Push(result);
        //    _operationHandler.Setup(x => x.Compute(input)).Returns(stack);
        //}

        //[Fact]
        //public void ShouldThrowException()
        //{
        //    string input = "/";
        //    _operationHandler.Setup(x => x.Compute(input))
        //        .Throws(new NotEnoughNumbersException(string.Empty));
        //}

    }
}
