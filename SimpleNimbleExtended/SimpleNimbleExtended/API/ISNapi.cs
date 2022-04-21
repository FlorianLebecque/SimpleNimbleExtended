using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNimbleExtended.API {
    internal interface ISNapi {

        dynamic Login(string username, string password);

        dynamic Register(string username,string email, string password);

    }
}
