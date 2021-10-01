namespace CoAd.Model.Entities
{
    /// <summary>
    /// клиентский магазин
    /// </summary>
    public class Store
    {
        /// <summary>
        /// идентификатор из ФО
        /// </summary>
        public int FoIdStore { get; set; }

        public string Name { get; set; }

        public string EgaisProps { get; set; }

        public string OfdProps { get; set; }

        public string BpaProps { get; set; }
    }
}