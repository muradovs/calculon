namespace Calculon.Math.Murad.Operations
{
  public interface IOperationDefinition
    {
        int ParameterCount { get; }
        Associativity Associativity { get; }
        OperationType Type { get; }
        ParameterOrder ParameterOrder { get; }
        string Token { get; }
    }
}