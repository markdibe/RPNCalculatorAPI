using Moq;
using RPNCalculatorAPI.IServices;
using RPNCalculatorAPI.Services;
using System;
using Xunit;

namespace RPNCalulatorTest
{
    public class OperationsTest
    {
        private static int x = 9;
        private static int y = 3;
        private readonly Mock<IOperation> _operation;

        public OperationsTest()
        {
            _operation = new Mock<IOperation>();
        }

        [Fact]
        public void ShouldAdd()
        {
            _operation.Setup(o => o.Add(x, y)).Returns(12);
        }

        [Fact]
        public void ShouldSubstract()
        {
            _operation.Setup(o => o.Substract(x, y)).Returns(6);
        }

        [Fact]
        public void ShouldMultiply()
        {
            _operation.Setup(o => o.Multiply(x, y)).Returns(27);
        }

        [Fact]
        public void ShouldDivide()
        {
            _operation.Setup(o => o.Divide(x, y)).Returns(3);
        }
    }
}
