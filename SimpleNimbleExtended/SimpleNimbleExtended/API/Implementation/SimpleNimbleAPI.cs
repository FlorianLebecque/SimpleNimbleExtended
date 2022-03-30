using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SimpleNimbleExtended.API.Implementation {
    internal class SimpleNimbleAPI : ISNapi {


        private string URL;

        public SimpleNimbleAPI(string url) {
            this.URL = url;

        }

        private void CreateObject() {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";

            //request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII)) {
                //requestWriter.Write(DATA);
            }

            try {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream)) {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            } catch (Exception e) {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
        }

        public Guid Login(string email, string password) {


            //rest api call for login



            throw new NotImplementedException();
        }

        public Guid Register(string email, string password) {
            throw new NotImplementedException();
        }
    }
}
