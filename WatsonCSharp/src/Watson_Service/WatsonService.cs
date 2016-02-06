using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleH.WatsonCSharp.Watson_Service
{
   abstract class WatsonService
    {


        
        private const string BASIC = "Basic";
        //Skipping log
        private string apiKey;
        //OkHttpClient
        private string endPoint;
        private readonly string name;
        //Headers
        protected const string XWatsonAuthorizationToken = "X-Watson-Authorization-Token";
        protected const string VERSION = "version";





        public WatsonService(string name)
        {
            this.name = name;
            
        }

    }
}
