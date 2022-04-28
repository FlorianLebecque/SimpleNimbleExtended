using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SimpleNimbleExtended.API;

namespace SimpleNimbleExtended {
    internal partial class Controler {

        private static Controler _instance;

        private ISNapi sNapi;

        private static ISettings settings => CrossSettings.Current;

        public static Controler GetInstance() {
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
        private string username_ { get; set; }
        private string id_ { get; set; }

        public string username { get{ return username_; } }
        public string id { get{ return id_; } }

        private string Scramble(string s) {
            using (var alg = SHA256.Create())
                return string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(s)).Select(x => x.ToString("x2")));
        }

        private void SaveAccount(string username, string hashPass, string guid) {
            Dictionary<string, SavedInfo> savedAccount = GetSavedAccounts();

            if (!savedAccount.ContainsKey(guid)) {
                savedAccount.Add(guid, new SavedInfo(guid, username, hashPass));
            }

            settings.AddOrUpdateValue("SAVED_ACCOUNT", JsonConvert.SerializeObject(savedAccount));
        }

        public Dictionary<string, SavedInfo> GetSavedAccounts() {
             return JsonConvert.DeserializeObject<Dictionary<string, SavedInfo>>(settings.GetValueOrDefault("SAVED_ACCOUNT","{}"));
        }

        public bool QuickLogin(SavedInfo account) {

            try {
                string hashPass = account.hashPass;
                dynamic userObj = sNapi.Login(account.name, hashPass);

                currentToken = new Guid((string)userObj.token);

                this.username_ = (string)userObj.name;
                this.id_ = (string)userObj.id;

                return true;
            } catch (Exception e) {

                return false;
            }
        }

        public void RemoveSavedInfo(string guid) {
            Dictionary<string, SavedInfo> savedAccount = GetSavedAccounts();

            if (savedAccount.ContainsKey(guid)) {
                savedAccount.Remove(guid);
            }

            settings.AddOrUpdateValue("SAVED_ACCOUNT", JsonConvert.SerializeObject(savedAccount));
        }



    }

    

    
}
