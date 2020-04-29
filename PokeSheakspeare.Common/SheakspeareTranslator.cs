using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeSheakspeare.Common
{
    public class SheakspeareTranslator : ISheakspeareTranslator
    {
        private readonly string uri = "http://api.funtranslations.com/translate/shakespeare.json?text=";

        public async Task<string> GetTranslationAsync(string phrase)
        {
            var client = new HttpClient();
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("text", phrase) });
            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                dynamic obj = JValue.Parse(await response.Content.ReadAsStringAsync());
                if (obj.success.total != 0)
                {
                    return obj.contents.translated;
                }
                else
                {
                    return obj.contents.message;
                }
            }
            else
            {
                throw new RequestException(await response.Content.ReadAsStringAsync(), response.StatusCode);
            }
        }
    }
}
