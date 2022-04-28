using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNimbleExtended.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentView {
        public HomeView() {
            InitializeComponent();

            List<PostInfo> posts = Controler.GetInstance().GetTimeLinePost();


            cl_posts.ItemsSource = posts;
        }

        public void Btn_add_click(object sender, EventArgs e) { 
            Navigation.PushAsync(new NewPostPage());
        }
    }
}