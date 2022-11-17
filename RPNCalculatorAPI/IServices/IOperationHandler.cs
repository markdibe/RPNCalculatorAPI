using System.Collections.Concurrent;

namespace RPNCalculatorAPI.IServices
{
    public interface IOperationHandler
    {
        public ConcurrentStack<int> Compute(string input, int id);
        public ConcurrentStack<int> GetStack(int id);
        public void CreateNew();
        public void DeleteStack(int id);
        public ConcurrentDictionary<int, ConcurrentStack<int>> GetDictionary();
    }
}
