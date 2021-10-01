using CoAd.Model.Enums;

namespace CoAd.Model.Interfaces
{
    public interface IStartable
    {
        void Start();

        void Stop();

        void Restart();

        StatusEnum Status { get; }
    }
}