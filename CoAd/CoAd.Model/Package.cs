using CoAd.Model.Enums;
using CoAd.Model.Interfaces;

namespace CoAd.Model
{
    public class Package<T> : IPackage<T> where T : class
    {
        public T Object { get; set; }

        public ErrorEnum ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public int ProcessingTime { get; set; }
    }
}