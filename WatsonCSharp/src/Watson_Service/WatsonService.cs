using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace LittleH.WatsonCSharp.Watson_Service
{
   abstract class WatsonService
    {


        
        private const string BASIC = "Basic";
        //Skipping log
        private string apiKey;
        private HttpClient client;
     
        private string endPoint;
        private readonly string name;
        //Headers
        protected const string XWatsonAuthorizationToken = "X-Watson-Authorization-Token";
        protected const string VERSION = "version";
        
        



        public WatsonService(string name)
        {
            this.name = name;
            this.apiKey = Util.CredentialUtils.getAPIKey(name);
            this.client = ConfigureHttpClient();
            
        }

        protected HttpClient ConfigureHttpClient()
        {
            HttpClient client = new HttpClient();
            //cookie handler

            client.Timeout = new TimeSpan(0, 0, 60);
            return client;
        }



    }
}
