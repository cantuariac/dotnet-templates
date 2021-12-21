namespace Core.Api.Services
{
    public class Notification
    {
        public Notification(string message, string label = "error")
        {
            Message = message;
            Label = label;
        }

        public string Message { get; }
        public string Label { get; }
    }
}