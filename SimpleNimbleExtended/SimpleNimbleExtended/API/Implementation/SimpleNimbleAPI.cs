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

        private  object Post(object data,string path,Dictionary<string,string> headers = null) {

            var client = new RestClient(URL+"/"+path);

            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            if (headers != null) {
                foreach (string key in headers.Keys) { 
                    request.AddHeader(key, headers[key]);
                }
            }

            request.AddJsonBody(data);

            RestResponse response = client.PostAsync(request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject(response.Content); 
        }

        private object Delete(object data, string path, Dictionary<string, string> headers = null) {

            var client = new RestClient(URL + "/" + path);

            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            if (headers != null) {
                foreach (string key in headers.Keys) {
                    request.AddHeader(key, headers[key]);
                }
            }

            request.AddJsonBody(data);

            RestResponse response = client.DeleteAsync(request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject(response.Content);
        }

        private object Get(string path, Dictionary<string, string> headers = null) {

            var client = new RestClient(URL + "/" + path);

            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            if (headers != null) {
                foreach (string key in headers.Keys) {
                    request.AddHeader(key, headers[key]);
                }
            }

            RestResponse response = client.GetAsync(request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject(response.Content);
        }

        public dynamic Login(string username, string password) {

            dynamic log_fom = new ExpandoObject();
            log_fom.name = username;
            log_fom.password = password;

            return Post(log_fom,"user/login");
        }

        public dynamic Register(string username,string email, string password) {

            dynamic log_fom = new ExpandoObject();
            log_fom.name = username;
            log_fom.email = email;
            log_fom.password = password;

            return Post(log_fom, "user/register"); ;
        }

        public dynamic FindUsers(string username) {
            return Get("user/s/"+username);
        }

        public dynamic AddNewPost(string username, string token, string title, string content, string imgUrl) {
            dynamic post_form = new ExpandoObject();
            post_form.title = title;
            post_form.content = content;
            post_form.imgUrl = imgUrl;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("user", username);
            headers.Add("token", token);

            return Post(post_form, "post/new",headers);
        }

        public dynamic GetPostOfUser(string id) {
            return Get("user/posts/" + id);

        }

        public dynamic GetUserInfo(string id) {
            return Get("user/i/" + id);

        }

        public dynamic Follow(string username, string token, string id) {
            dynamic follow_form = new ExpandoObject();
            follow_form.id = id;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("user", username);
            headers.Add("token", token);

            return Post(follow_form, "user/follow", headers);
        }

        public dynamic UnFollow(string username, string token, string id) {
            dynamic follow_form = new ExpandoObject();
            follow_form.id = id;

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("user", username);
            headers.Add("token", token);

            return Delete(follow_form, "user/follow", headers);
        }

        public dynamic GetFollowedUser(string username, string token) {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("user", username);
            headers.Add("token", token);

            return Get("user/follow", headers);
        }
    }
}
