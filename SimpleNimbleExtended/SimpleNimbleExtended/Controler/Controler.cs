using System;
using System.Collections.Generic;
using System.Text;

using SimpleNimbleExtended.API;

namespace SimpleNimbleExtended.Controler {
    internal class Controler {

        private static Controler _instance;

        private ISNapi sNapi;

        public Controler GetInstance() {
            if (_instance == null) {
                _instance = new Controler();
            }
            return _instance;
        }

        public void Load(ISNapi sNapi) { 
            this.sNapi = sNapi;
        }

        private Controler() { }


        private Guid currentToken;

        public bool Login(string email, string password) {

            return false;
        }

        public bool Register(string email, string username, string password) {

            return false;
        }


    }
}
