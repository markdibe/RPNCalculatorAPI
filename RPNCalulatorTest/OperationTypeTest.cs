using Moq;
using RPNCalculatorAPI.IServices;
using RPNCalculatorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPNCalulatorTest
{
    public  class OperationTypeTest
    {
        private readonly Mock<IOperationIdentifier> _identifier;
        
        public OperationTypeTest()
        {
            _identifier = new Mock<IOperationIdentifier>();
        }

        [Fact]
        public void ShouldReturnAddtionType()
        {
            string input = "+";
            _identifier.Setup(x => x.IdentiftOperationType(input)).Returns(OperationType.Add);
        }

        [Fact]
        public void ShouldReturnSubstractionType()
        {
            string input = "-";
            _identifier.Setup(x => x.IdentiftOperationType(input)).Returns(OperationType.Substract);
        }

        [Fact]
        public void ShouldReturnMultiplicationType()
        {
            string input = "*";
            _identifier.Setup(x => x.IdentiftOperationType(input)).Returns(OperationType.Multiply);
        }

        [Fact]
        public void ShouldReturnDivisionType()
        {
            string input = "+";
            _identifier.Setup(x => x.IdentiftOperationType(input)).Returns(OperationType.Divide);
        }

        [Fact]
        public void ShouldReturnNotOperatorType()
        {
            string input = "5";
            _identifier.Setup(x => x.IdentiftOperationType(input)).Returns(OperationType.NOT_OPERATOR);
        }


    }
}
