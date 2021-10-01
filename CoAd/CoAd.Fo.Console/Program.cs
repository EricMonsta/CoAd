using System.Text;
using CoAd.Fo.Core;
using CoAd.Model;
using CoAd.Model.EventArgs;

namespace CoAd.Fo.Console
{
    class Program
    {
        static void Main()
        {
            System.Console.OutputEncoding = Encoding.UTF8;
            System.Console.InputEncoding = Encoding.UTF8;

            Log.Instance.ExternalEvent += ExternalEvent;

            FoEngineModel.Instance.Start();

            System.Console.ReadLine();

            FoEngineModel.Instance.Stop();
        }

        private static void ExternalEvent(object sender, ExternalEventArgs e)
        {
            System.Console.WriteLine(e.Information, e.Arguments);
        }
    }
}
