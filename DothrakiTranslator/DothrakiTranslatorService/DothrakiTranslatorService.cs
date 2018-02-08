using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DothrakiTranslatorService
{
    public static class DothrakiTranslatorService
    {
        [FunctionName("DothrakiTranslatorService")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "HttpTriggerCSharp/name/{phrase}")]HttpRequestMessage req, string phrase, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            string dothrakiDictionaryJson = get_web_content("https://dothrakitranslaa589.blob.core.windows.net/azure-webjobs-hosts/EnglishDothraki.json");
            return req.CreateResponse(HttpStatusCode.OK, dothrakiDictionaryJson);
        }

        public static string get_web_content(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string output = reader.ReadToEnd();
            response.Close();
            return output;
        }

    }
}
                                       