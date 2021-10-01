using System;

namespace CoAd.Core
{
    public class LoadHistory
    {
        public DateTime? ParametersLoadTime { get; set; }

        public static LoadHistory Default
        {
            get
            {
                return new LoadHistory
                {
                    ParametersLoadTime = null
                };
            }
        }
    }
}