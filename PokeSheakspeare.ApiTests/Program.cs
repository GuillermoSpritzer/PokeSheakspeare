using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace PokeSheakspeare.ApiTests
{
    class Program
    {
        static readonly string testUri = "https://localhost:5001/pokemon/ditto";
        static readonly string expectedOutcome = "While 't can transform into aught,  each ditto apparently hath its own strengths and weaknesses at which hour 't cometh to transformations.";

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            Console.WriteLine("------------------ Starting Tests ------------------");

            Console.WriteLine("Test 1:");
            try
            {
                var response = await client.GetAsync(testUri);
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());                
                Assert.AreEqual(values["description"], expectedOutcome, "result is different as the expected outcome");
                Console.WriteLine("------------------ Test 1 - passed ------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(" ------------------ Test 1 - Failed with exeption:  " + e.Message + " ------------------");
            }


            Console.WriteLine("Test 2:");
            try
            {
                //
            }
            catch (Exception e)
            {
                Console.WriteLine(" ------------------ Test 2 - Failed with exeption:  " + e.Message + " ------------------");
            }

            Console.ReadLine();
        }
    }
}
