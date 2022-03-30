using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNimbleExtended.API {
    internal interface ISNapi {

        Guid Login(string email, string password);

        Guid Register(string email, string password);

    }
}
