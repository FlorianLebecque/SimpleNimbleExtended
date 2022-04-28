using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNimbleExtended {
    internal partial class Controler{
        public bool Login(string username, string password, bool keep) {

            try {
                string hashPass = Scramble(password);
                dynamic userObj = sNapi.Login(username, hashPass);

                currentToken = new Guid((string)userObj.token);

                this.username_ = (string)userObj.name;
                this.id_ = (string)userObj.id;

                if (keep) {
                    SaveAccount(username, hashPass, (string)userObj.id);
                }

                return true;
            } catch (Exception e) {

                return false;
            }

        }

        public bool Register(string username, string email, string password, bool keep) {

            try {
                string hashPass = Scramble(password);
                dynamic userObj = sNapi.Register(username, email, hashPass);

                currentToken = new Guid((string)userObj.token);

                this.username_ = (string)userObj.name;
                this.id_ = (string)userObj.id;

                if (keep) {
                    SaveAccount(username, hashPass, (string)userObj.id);
                }

                return true;
            } catch (Exception e) {

                return false;
            }
        }

        public List<UserInfo> FindUsers(string username) {

            try {
                dynamic result = sNapi.FindUsers(username);

                List<UserInfo> users = new List<UserInfo>();
                foreach (dynamic userObj in result) {

                    dynamic resultUserInfo = new UserInfo(
                        (string)userObj.id,
                        (string)userObj.name,
                        string.Format("https://avatars.dicebear.com/api/bottts/{0}.png", (string)userObj.name)
                    );

                    users.Add(resultUserInfo);
                }

                return users;

            } catch (Exception e) {
                return new List<UserInfo>();
            }

        }

        public UserInfo GetUserInfo(string id) { 

            dynamic userObj = sNapi.GetUserInfo(id);

            return new UserInfo(
                (string)(userObj.id),
                (string)userObj.name,
                string.Format("https://avatars.dicebear.com/api/bottts/{0}.png", (string)userObj.name)
            );
        }

        public bool FollowUser(string id) {
            try {
                dynamic followResult = sNapi.Follow(username, currentToken.ToString(), id);
           
                if (followResult) {
                    return true;
                }

                return false;
            } catch (Exception e) {

                return false;
            }
        }

        public bool UnFollowUser(string id) {
            try {
                dynamic followResult = sNapi.UnFollow(username, currentToken.ToString(), id);

                if (followResult) {
                    return true;
                }

                return false;
            } catch (Exception e) {

                return false;
            }
        }

        public List<string> GetFollowedUser() {
            try {
                dynamic result = sNapi.GetFollowedUser(username,currentToken.ToString());

                List<string> user_ids = new List<string>();
                foreach (dynamic userObj in result) {

                    user_ids.Add((string)userObj.id_user_2);
                }

                return user_ids;

            } catch (Exception e) {
                return new List<string>();
            }
        }

    }
}
