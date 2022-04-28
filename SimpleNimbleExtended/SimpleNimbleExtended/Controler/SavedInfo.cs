using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNimbleExtended {
    public class SavedInfo {
        public string id { get; set; }
        public string name { get; set; }
        public string hashPass { get; set; }

        public SavedInfo(string id_, string name_, string pass_) {
            name = name_;
            id = id_;
            hashPass = pass_;
        }
    }
}
