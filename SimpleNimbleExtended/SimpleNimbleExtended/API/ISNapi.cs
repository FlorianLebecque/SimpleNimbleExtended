using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNimbleExtended.API {
    internal interface ISNapi {

        dynamic Login(string username, string password);

        dynamic Register(string username,string email, string password);

        dynamic FindUsers(string username);

        dynamic AddNewPost(string username, string token, string title, string content, string imgUrl);

        dynamic GetPostOfUser(string id);

        dynamic GetUserInfo(string id);

        dynamic Follow(string username, string token,string id);

        dynamic UnFollow(string username, string token,string id);

        dynamic GetFollowedUser(string username, string token);
    }
}
