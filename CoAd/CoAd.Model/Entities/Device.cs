namespace CoAd.Model.Entities
{
    public class Device
    {
        /// <summary>
        /// идентификатор из ФО
        /// </summary>
        public int FoIdDevice { get; set; }

        public int Type { get; set; }

        /// <summary>
        /// фо-группа устройств
        /// </summary>
        public int? IdDeviceGroup { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public string Data { get; set; }

        public string Settings { get; set; }
    }
}