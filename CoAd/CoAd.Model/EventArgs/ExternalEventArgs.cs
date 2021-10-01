namespace CoAd.Model.EventArgs
{
    public class ExternalEventArgs : System.EventArgs
    {
        public string Information { get; protected set; }

        public object[] Arguments { get; protected set; }

        public ExternalEventArgs(string information, params object[] args)
        {
            Information = information;
            Arguments = args;
        }
    }
}