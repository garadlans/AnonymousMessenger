namespace MessengerCoreLib.WorkWithBase
{
    public interface IRequester
    {
        DataBaseGetter Execute(string request);
    }
}
