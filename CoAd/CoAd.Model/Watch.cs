using System;

namespace CoAd.Model
{
    public class Watch
    {
        private static readonly object Sync = new object();

        private static volatile Watch _instance;

        public static Watch Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new Watch();
                        }
                    }
                }

                return _instance;
            }
        }

        public int Time(Action action)
        {
            int time;
            var start = Environment.TickCount;

            try
            {
                if (action != null)
                {
                    action.Invoke();
                }
            }
            finally
            {
                time = Environment.TickCount - start;
            }

            return time;
        }
    }
}