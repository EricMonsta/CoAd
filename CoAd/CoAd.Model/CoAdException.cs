using System;
using CoAd.Model.Enums;

namespace CoAd.Model
{
    public class CoAdException : Exception
    {
        public CoAdException(string message, ErrorEnum state)
            : base(message)
        {
            State = state;
        }

        public ErrorEnum State { get; set; }
    }
}