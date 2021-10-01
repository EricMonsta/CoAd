namespace CoAd.Model.Entities
{
    /// <summary>
    /// группа устройств на клиенте
    /// </summary>
    public class DeviceGroup
    {
        /// <summary>
        /// идентификатор из ФО
        /// </summary>
        public int FoIdGroup { get; set; }

        public string Name { get; set; }
    }
}