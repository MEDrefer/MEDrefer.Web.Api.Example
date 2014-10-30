using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MEDrefer.Web.Api.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = Settings.Default.MEDreferApiUrl;

            Console.WriteLine("Enter the Application Authentication Token:");
            var appAuthToken = new ApplicationAuthenticationToken(Console.ReadLine());

            Console.WriteLine("Enter U for Username/Password entry, or T for User Authentication Token entry.");
            var option = Console.ReadLine();

            ApiClient client = null;
            switch (option)
            {
                case "U":
                    Console.WriteLine("Enter your Username:");
                    var username = Console.ReadLine();

                    Console.WriteLine("Enter your Password:");
                    var password = Console.ReadLine();

                    client = new ApiClient(url, appAuthToken, new UsernamePasswordPair(username, password));
                    break;
                case "P":
                    Console.WriteLine("Enter your User Authentication Token:");

                    client = new ApiClient(url, appAuthToken, new UserAuthenticationToken(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Yeah, thats clearly not a U or a P.");
                    Environment.Exit(1);
                    break;
            }

            var practitioner = client.GetSelf();
            Console.WriteLine("You are currently authenticated as the Practitioner:");
            Console.Write(JsonConvert.SerializeObject(practitioner, Formatting.Indented));
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
