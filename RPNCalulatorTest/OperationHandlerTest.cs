using Moq;
using RPNCalculatorAPI.CustomExceptions;
using RPNCalculatorAPI.IServices;
using RPNCalculatorAPI.Services;
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
        private readonly IOperationHandler _operationHandler;
        private static readonly ConcurrentDictionary<int, ConcurrentStack<int>> expectedStacks = new ConcurrentDictionary<int, ConcurrentStack<int>>();


        public OperationHandlerTest()
        {
            _operationHandler = new OperationHandlerService(new OperationIdentifierService(), new OperationService());
            _operationHandler.CreateNew();
            expectedStacks[1] = new ConcurrentStack<int>();
        }

        [Fact]
        public void ShouldAddANewStack()
        {
            Assert.Single(_operationHandler.GetDictionary());
        }

        [Fact]
        public void ShouldInsertANumberInStack()
        {
            string input = "2";
            expectedStacks[1].Push(2);
            _operationHandler.Compute(input, 1);
            var result = _operationHandler.GetStack(1);
            Assert.Equal(expectedStacks[1], result);
        }

        [Fact]
        public void ShouldInsertAnotherNumberInStack()
        {
            _operationHandler.Compute("1", 1);
            _operationHandler.Compute("2",1);
            var result = _operationHandler.GetStack(1);
            Assert.Equal(2, result.Count);
        }

        [Fact]

        public void ShouldAddTheTwoNumbers()
        {
            //the result should be 7

            string input = "2";
            expectedStacks[1].Push(2);
            _operationHandler.Compute(input, 1);
            input = "5";
            expectedStacks[1].Push(5);
            _operationHandler.Compute(input, 1);
            input = "+";
            expectedStacks[1].TryPop(out int firstNumber);
            expectedStacks[1].TryPop(out int secondNumber);
            int expectedResult = firstNumber + secondNumber;
            expectedStacks[1].Push(expectedResult);
            _operationHandler.Compute(input, 1);
            var result = _operationHandler.GetStack(1);
            Assert.Equal(expectedStacks[1], result);
        }

        [Fact]
        public void ShouldSubstractTheTwoNumbers()
        {
            _operationHandler.Compute("7", 1);
            _operationHandler.Compute("2", 1);
            _operationHandler.Compute("-", 1);
            _operationHandler.GetStack(1).TryPeek(out int result);
            Assert.Equal(5, result);
        }

        [Fact]
        public void ShouldMultiplyTwoNumbers()
        {
            //result should be 16
            string input = "4";
            string input2 = "5";
            _operationHandler.Compute(input, 1);
            _operationHandler.Compute(input2, 1);
            _operationHandler.Compute("*", 1);
            _operationHandler.GetStack(1).TryPeek(out int result);
            Assert.Equal(20, result);

        }

        [Fact]
        public void ShouldDivideTwoNumbers()
        {
            // result should be 8
            string input = "16";
            string input2 = "2";
            _operationHandler.Compute(input, 1);
            _operationHandler.Compute(input2, 1);
            _operationHandler.Compute("/", 1);
            _operationHandler.GetStack(1).TryPeek(out int result);
            Assert.Equal(8, result);
        }


        [Fact]
        public void ShouldRemoveStack()
        {
            _operationHandler.CreateNew();
            _operationHandler.DeleteStack(2);
            Assert.Single(_operationHandler.GetDictionary());
        }

    }
}
