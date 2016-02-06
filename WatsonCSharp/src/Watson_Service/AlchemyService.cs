using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleH.WatsonCSharp.Watson_Service
{
    class AlchemyService:WatsonService
    {
        protected const string ENDPOINT = "https://gateway-a.watsonplatform.net/calls";
        protected const string JSONP = "jsonp";

        private const string DAILY_TRANSACTION_LIMIT_EXCEEDED = "daily-transaction-limit-exceeded";
        private const string INVALID_API_KEY = "invalid-api-key";
        //skipping log
        private const string MESSAGE_CODE = "code";
        private const string MESSAGE_ERROR = "error";

        protected const string OUTPUT_MODE = "outputMode";

        private const string PARAM_APIKEY = "apikey";
        private const string STATUS_ERROR = "ERROR";
        private const string X_ALCHEMY_API_ERROR_MSG = "X-AlchemyAPI-Error-Msg";
        private const string X_ALCHEMY_API_STATUS = "X-AlchemyAPI-Status";


        public AlchemyService():base("alchemy_api")
        {
           
        }






    }
}
