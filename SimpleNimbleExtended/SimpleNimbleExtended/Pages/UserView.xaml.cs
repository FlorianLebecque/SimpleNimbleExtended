using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.Markdown;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNimbleExtended.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserView : ContentView {

        public UserInfo userInfo { get; set; }
        public UserView( string id) {
            
            InitializeComponent();

            userInfo = Controler.GetInstance().GetUserInfo(id);

            lb_name.Text = userInfo.name;
            img_pp.Source = userInfo.imgUrl;

            List<PostInfo> posts = Controler.GetInstance().GetUserPost(id);

          
            cl_posts.ItemsSource = posts;
                       
            SetFollowBtn(id);

        }

        public void SetFollowBtn(string id) {
            if (id == Controler.GetInstance().id) {
                bt_follow.IsVisible = false;
            }

            List<string> followed = Controler.GetInstance().GetFollowedUser();

            if (followed.Contains(id)) {
                bt_follow.Text = "Unfollow";
                bt_follow.Style = (Style)Application.Current.Resources["UnFollow"];
            } else {
                bt_follow.Text = "Follow";
                bt_follow.Style = (Style)Application.Current.Resources["Follow"];
            }

        }

        public void Bt_follow_click(object sender,EventArgs e) {
            List<string> followed = Controler.GetInstance().GetFollowedUser();

            if (followed.Contains(userInfo.id)) { 
                Controler.GetInstance().UnFollowUser(userInfo.id);
            } else {
                Controler.GetInstance().FollowUser(userInfo.id);
            }

            SetFollowBtn(userInfo.id);
        }
    }
}