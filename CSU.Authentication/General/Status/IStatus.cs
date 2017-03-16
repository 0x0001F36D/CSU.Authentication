namespace CSU.Authentication.General.Status
{
    public interface IStatus
    {
        bool Status { get; }
        object Data { get; }
    }

    public interface IStatus<R> : IStatus
    {
        new R Data { get; }
    }
}
