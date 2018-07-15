namespace SharpKeys.API
{
    public interface IUserAction
    {
        void Execute();

        bool Succees { get; }
    }
}