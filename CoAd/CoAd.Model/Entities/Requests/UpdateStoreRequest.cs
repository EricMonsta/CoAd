namespace CoAd.Model.Entities.Requests
{
    public class UpdateStoreRequest
    {
        public string ClientId { get; set; }

        public Store Store { get; set; }
    }
}