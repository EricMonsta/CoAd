using System;

namespace CoAd.Model.EventArgs
{
    public class ExceptionEventArgs : ExternalEventArgs
    {
        public ExceptionEventArgs(Exception ex, string information, params object[] args)
            : base(information, args)
        {
            Ex = ex;
        }

        public Exception Ex { get; protected set; }
    }
}