namespace SharpKeys.RuntimeComponent.API
{
    public interface IUserAction
    {
        void Execute();

        bool Succees { get; }
    }
}