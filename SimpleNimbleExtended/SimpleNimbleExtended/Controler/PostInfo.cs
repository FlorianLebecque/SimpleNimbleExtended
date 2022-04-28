using SimpleNimbleExtended.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xam.Forms.Markdown;

namespace SimpleNimbleExtended {
    public class PostInfo {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string imgurl { get; set; }
        public DateTime createdAt { get; set; }

        public MarkdownTheme MDTheme { get; set; }

        public PostInfo(string id_,string title_,string content_) { 
            id = id_;
            title = title_;
            content = content_;

            MDTheme = new CustomMarkdownTheme();
        }

    }
}
