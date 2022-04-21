using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Dynamic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Threading.Tasks;

namespace SimpleNimbleExtended.API.Implementation {
    internal class SimpleNimbleAPI : ISNapi {


        private string URL;

        public SimpleNimbleAPI(string url) {
            this.URL = url;

        }

        private  object Post(object data,string path) {

            var client = new RestClient(URL+"/"+path);

            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(data);

            RestResponse response = client.PostAsync(request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject(response.Content); 
        }



        public dynamic Login(string username, string password) {


            //rest api call for login
            dynamic log_fom = new ExpandoObject();
            log_fom.name = username;
            log_fom.password = password;

            
           
            return Post(log_fom,"user/login");

        }

        public dynamic Register(string username,string email, string password) {

            //rest api call for login
            dynamic log_fom = new ExpandoObject();
            log_fom.name = username;
            log_fom.email = email;
            log_fom.password = password;


            return Post(log_fom, "user/register"); ;
        }
    }
}
