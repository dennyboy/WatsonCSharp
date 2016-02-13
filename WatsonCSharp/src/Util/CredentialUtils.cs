using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LittleH.WatsonCSharp.Util
{
    class CredentialUtils
    {
      
   /// <summary>
   /// The Constant ALCHEMY_API. </summary>
   private const string AlchemyApi = "alchemy_api";

   /// <summary>
   /// The Constant APIKEY. </summary>
   private const string ApiKey = "apikey";

   /// <summary>
   /// The Constant CREDENTIALS. </summary>
   private const string Credentials = "credentials";

   /// <summary>
   /// The Constant log. </summary>
   //JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
 //  private static readonly Logger log = Logger.getLogger(typeof(CredentialUtils).FullName);

   /// <summary>
   /// The Constant PASSWORD. </summary>
   private const string Password = "password";

   /// <summary>
   /// The Constant PLAN. </summary>
   private const string Plan = "plan";

   /// <summary>
   /// The Constant PLAN_EXPERIMENTAL. </summary>
   public const string PlanExperimental = "experimental";

   /// <summary>
   /// The Constant PLAN_FREE. </summary>
   public const string PlanFree = "free";

   /// <summary>
   /// The Constant PLAN_STANDARD. </summary>
   public const string PlanStandard = "standard";

   /// <summary>
   /// The services. </summary>
   private static string services;

   /// <summary>
   /// The Constant USERNAME. </summary>
   private const string Username = "username";

   /// <summary>
   /// Returns the apiKey from the VCAP_SERVICES or null if doesn't exists.
   /// </summary>
   /// <param name="serviceName"> the service name </param>
   /// <returns> the API key or null if the service cannot be found. </returns>
   public static string getAPIKey(string serviceName)
   {
       return getAPIKey(serviceName, null);
   }

   /// <summary>
   /// Returns the apiKey from the VCAP_SERVICES or null if doesn't exists. If plan is specified, then
   /// only credentials for the given plan will be returned.
   /// </summary>
   /// <param name="serviceName"> the service name </param>
   /// <param name="plan"> the service plan: standard, free or experimental </param>
   /// <returns> the API key </returns>
   public static string getAPIKey(string serviceName, string plan)
   {

       if (serviceName == null || serviceName.Length == 0)
       {
           return null;
       }



       List<VCAPService> services = VCAPServices;
       if (services == null)
       {
             
                throw new IOException("No VCAP Services Present");
       //    return getKeyUsingJNDI(serviceName);
       }

       foreach (VCAPService entry in services)
       {

           string key = entry.Name;
           if (key.Equals(serviceName,StringComparison.CurrentCultureIgnoreCase))
           {
                    /*
                    JsonArray servInstances = services.getAsJsonArray(key);
                    foreach (JsonElement instance in servInstances)
                    {

                        JsonObject service = instance.AsJsonObject;

                        string instancePlan = service.get(Plan).AsString;
                        if (plan == null || plan.Equals(instancePlan, StringComparison.CurrentCultureIgnoreCase))
                        {
                            JsonObject credentials = instance.AsJsonObject.getAsJsonObject(Credentials);
                            if (serviceName.Equals(AlchemyApi, StringComparison.CurrentCultureIgnoreCase))
                            {
                                return credentials.get(ApiKey).AsString;
                            }
                            else
                            {
                            */

                    string username;
                    string password;


                    entry.Credentials.TryGetValue(Username, out username);
                    entry.Credentials.TryGetValue(Password, out password);
                
                                //basic authentication
                                string inputText = username + ":" + password;
                                byte[] bytesToEncode = Encoding.UTF8.GetBytes(inputText);
                                string encodedText = Convert.ToBase64String(bytesToEncode);

                                return encodedText;
                       }
                   }
            return null;
        }
           
       
       
       
      
   


   /// <summary>
   /// Gets the <b>VCAP_SERVICES</b> environment variable and return it as a <seealso cref="JsonObject"/>.
   /// </summary>
   /// <returns> the VCAP_SERVICES as a <seealso cref="JsonObject"/>. </returns>


   /// <summary>
   /// Sets the VCAP_SERVICES variable. This is utility variable for testing
   /// </summary>
   /// <param name="services"> the VCAP_SERVICES </param>
   public static string Services
   {
       set
       {
           CredentialUtils.services = value;
       }
   }




   private static List<VCAPService> VCAPServices
        {
            get
            {
                //JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
                //ORIGINAL LINE: final String envServices = services != null ? services : System.getenv("VCAP_SERVICES");
                string envServices = services != null ? services : Environment.GetEnvironmentVariable("VCAP_SERVICES");
                if (envServices == null)
                {
                    return null;
                }

                List<VCAPService> servicesDic = new List<VCAPService>();

                return servicesDic;
            }
        }

        /// <summary>
        /// Class represents a VCAPService
        /// https://docs.cloudfoundry.org/devguide/deploy-apps/environment-variable.html#VCAP-SERVICES
        /// 
        /// </summary>
        public class VCAPService
        {
            public string Name { get; private set; }
            public string Label { get; private set; }
            public JArray Tags { get; private set; }
            //credentials vary in which properties they have

            public Dictionary<string,string> Credentials { get; private set; }

            public VCAPService(string JsonString)
            {
                JObject VcapJsonObject = JObject.Parse(JsonString);
                this.Name = (string)VcapJsonObject["name"];
                this.Label = (string)VcapJsonObject["label"];
                this.Tags = ((JArray)VcapJsonObject["tags"]);
                string credString = ((JObject)VcapJsonObject["credentials"]).ToString();
                this.Credentials = JsonConvert.DeserializeObject<Dictionary<string, string>>(credString);
            }
     }

   }




    
 }

