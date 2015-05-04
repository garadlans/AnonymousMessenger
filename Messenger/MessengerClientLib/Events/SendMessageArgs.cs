namespace MessengerClientLib.Events
{
    public class SendMessageArgs
    {
        public string Message { get; set; }

        public SendMessageArgs(string message)
        {
            Message = message;
        }
    }
}
