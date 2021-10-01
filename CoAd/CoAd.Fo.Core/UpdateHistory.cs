using System;

namespace CoAd.Fo.Core
{
    public class UpdateHistory
    {
        public DateTime? ParametersLoadTime { get; set; }

        public static UpdateHistory Default
        {
            get
            {
                return new UpdateHistory
                {
                    ParametersLoadTime = null
                };
            }
        }
    }
}