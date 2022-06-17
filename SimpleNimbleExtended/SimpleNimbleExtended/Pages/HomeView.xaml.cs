using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNimbleExtended.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentView {

        public List<PostInfo> postInfos { get; set; }
        public HomeView() {
            InitializeComponent();

            postInfos = new List<PostInfo>();

            RefreshData();
        }

        public void Refresh(object sender,EventArgs e) {

            RefreshData();

            RefreshView rv = (RefreshView)sender;
            rv.IsRefreshing = false;

        }

        public void RefreshData() {
            List<PostInfo> posts;
            if (postInfos.Count > 0) {

                PostInfo lastPost = postInfos[postInfos.Count - 1];

                posts = Controler.GetInstance().GetTimeLinePost(lastPost.createdAt);

            } else {
                posts = Controler.GetInstance().GetTimeLinePost();
            }

            postInfos.AddRange(posts);

            cl_posts.ItemsSource = postInfos;
        }

        public void Btn_add_click(object sender, EventArgs e) { 
            Navigation.PushAsync(new NewPostPage());
        }
    }
}