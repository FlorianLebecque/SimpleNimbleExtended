﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNimbleExtended {
    internal partial class Controler {

        public bool SavePost(string title,string content) {

            dynamic res = sNapi.AddNewPost(username, currentToken.ToString(), title, content, "Not implemented");

            if (res != null) { 
                return true;
            }
            return false;

        }

        public List<PostInfo> GetUserPost(string id) {
            try {
                dynamic result = sNapi.GetPostOfUser(id);

                List<PostInfo> posts = new List<PostInfo>();
                foreach (dynamic postObj in result) {

                    PostInfo resultPostInfo = new PostInfo(
                        (string)postObj.id,
                        (string)postObj.title,
                        (string)postObj.content
                    );

                    resultPostInfo.createdAt = Convert.ToDateTime(postObj.createdAt);

                    posts.Add(resultPostInfo);
                }

                return posts;

            } catch (Exception e) {
                return new List<PostInfo>();
            }
        }

        public List<PostInfo> GetTimeLinePost() {

            List<string> followedUser = GetFollowedUser();

            List<PostInfo> all_posts = new List<PostInfo>();

            foreach (string user_id in followedUser) {
                List<PostInfo> posts = GetUserPost(user_id);

                all_posts.AddRange(posts);
            }

            all_posts.Sort((y, x) => x.createdAt.CompareTo(y.createdAt));

            return all_posts;
        }

    }
}
