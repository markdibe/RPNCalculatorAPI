namespace RPNCalculatorAPI.IServices
{
    public interface IOperation
    {
        int Add(int x, int y);
        int Substract(int x, int y);
        int Multiply(int x, int y);
        int Divide(int x, int y);
    }
}
