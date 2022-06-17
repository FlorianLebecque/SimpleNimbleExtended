using SimpleNimbleExtended.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xam.Forms.Markdown;

namespace SimpleNimbleExtended {
    public class PostInfo {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string authorImg { get; set; }
        public string content { get; set; }
        public string imgurl { get; set; }

        public bool isLike { get; set; }
        public bool isDisLike { get; set; }

        public int score { get; set; }
        public DateTime createdAt { get; set; }

        public MarkdownTheme MDTheme { get; set; }

        public PostInfo(string id_,string title_,string content_) { 
            id = id_;
            title = title_;
            content = content_;

            isDisLike = true;
            isLike = true;
            score = 10;

            author = "pers0ne";
            authorImg = string.Format("https://avatars.dicebear.com/api/bottts/{0}.png", author);

            MDTheme = new CustomMarkdownTheme();
        }

    }
}
