using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNimbleExtended {
    public class UserInfo {
        public string id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }

        public UserInfo(string id_, string name_, string imgUrl_) {
            id = id_;
            name = name_;
            imgUrl = imgUrl_;
        }
    }
}
