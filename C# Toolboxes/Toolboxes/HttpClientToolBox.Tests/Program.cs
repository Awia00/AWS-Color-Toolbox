using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientToolBox.Tests
{
    class Program
    {
        private static AwiaHttpClientToolbox _testToolbox;
        static void Main(string[] args)
        {
            _testToolbox = new AwiaHttpClientToolbox("http://driveit.azurewebsites.net/api/");
            AwiaHttpClientStaticToolBox.Setup("http://driveit.azurewebsites.net/api/");
            GetObjects().Wait();
        }

        static private async Task GetObjects()
        {
            var temp = await _testToolbox.Read<object>("cars");
            Console.WriteLine(temp);
            var temp2 = await AwiaHttpClientStaticToolBox.Read<object>("cars");
            Console.WriteLine(temp2);
        }
    }
}
