using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPE.Util
{
    internal class HttpClientUtil
    {
        public static async Task<string> ConsHttpClientAsync(string url) 
        {
            var client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);   
                response .EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (Exception) 
            {
                return ""; 
            }
        }
    }
}
