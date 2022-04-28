using System;
using System.Collections.Generic;
using System.Text;
using Xam.Forms.Markdown;
using Xamarin.Forms;

namespace SimpleNimbleExtended.Resources {
    internal class CustomMarkdownTheme: MarkdownTheme {
        public static readonly Color DefaultBackgroundColor = (Color)Application.Current.Resources["darkBackground"];

        public static readonly Color DefaultAccentColor = (Color)Application.Current.Resources["Primary"];

        public static readonly Color DefaultTextColor = (Color)Application.Current.Resources["TextColor"];

        public static readonly Color DefaultCodeBackground = Color.FromHex("#4f5b66");

        public static readonly Color DefaultSeparatorColor = Color.FromHex("#65737e");

        public static readonly Color DefaultQuoteTextColor = Color.FromHex("#a7adba");

        public static readonly Color DefaultQuoteBorderColor = Color.FromHex("#a7adba");

        public CustomMarkdownTheme() {
            base.BackgroundColor = DefaultBackgroundColor;
            base.Paragraph.ForegroundColor = DefaultTextColor;
            base.Heading1.ForegroundColor = DefaultTextColor;
            base.Heading1.BorderColor = DefaultSeparatorColor;
            base.Heading2.ForegroundColor = DefaultTextColor;
            base.Heading2.BorderColor = DefaultSeparatorColor;
            base.Heading3.ForegroundColor = DefaultTextColor;
            base.Heading4.ForegroundColor = DefaultTextColor;
            base.Heading5.ForegroundColor = DefaultTextColor;
            base.Heading6.ForegroundColor = DefaultTextColor;
            base.Link.ForegroundColor = DefaultAccentColor;
            base.Code.ForegroundColor = DefaultTextColor;
            base.Code.BackgroundColor = DefaultCodeBackground;
            base.Quote.ForegroundColor = DefaultQuoteTextColor;
            base.Quote.BorderColor = DefaultQuoteBorderColor;
            base.Separator.BorderColor = DefaultSeparatorColor;
        }
    }
}
