using CoAd.Model.Enums;

namespace CoAd.Model.Interfaces
{
    public interface IPackage<T>
    {
        T Object { get; set; }

        ErrorEnum ErrorCode { get; set; }

        string ErrorDescription { get; set; }

        int ProcessingTime { get; set; }
    }
}