using System.Collections.Concurrent;

namespace RPNCalculatorAPI.IServices
{
    public interface IOperationWriter
    {
        ConcurrentStack<int> Compute(string input);
    }
}
