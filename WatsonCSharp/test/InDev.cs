using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using LittleH.WatsonCSharp.Util;

namespace LittleH.WatsonCSharp.test
{
    class InDev
    {

        public static void Main(string[] args)
        {
            const string service = @"
      {
                'credentials': {
                    'password': 'xxxxxxxxxxxx',
          'url': 'https://gateway.watsonplatform.net/tradeoff-analytics-beta/api',
         'username': 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
                },
        'label': 'tradeoff_analytics',
        'name': 'tradeoff-analytics-service',
        'plan': 'free',
        'tags': [
          'watson',
          'ibm_created',
          'ibm_beta'
        ]
    }";




            CredentialUtils.VCAPService v = new CredentialUtils.VCAPService(service);
            Console.WriteLine(v.Name);
            foreach(KeyValuePair<string,string> entry in v.Credentials)
            {
                Console.WriteLine(entry.Key + ":" + entry.Value);
            }
            Console.ReadLine();




        }





       




    }
}
