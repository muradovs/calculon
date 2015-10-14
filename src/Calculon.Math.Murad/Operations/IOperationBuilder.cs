namespace Calculon.Math.Murad.Operations
{
  public interface IOperationBuilder
    {
        void PushParameter(IExpression param);

        bool IsEnoughParameters { get; }

        IOperation Build();

        IOperationDefinition Definition { get; }
    }
}
