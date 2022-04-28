using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace SimpleNimbleExtended.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentView {

        public List<UserInfo> users;
        public SearchView() {
            InitializeComponent();

            

            tb_search.SearchButtonPressed += (s, e) => {
                users = Controler.GetInstance().FindUsers(tb_search.Text);
                cl_users.ItemsSource = users;
            };
        }

        public void btn_go_click(object sender, EventArgs e) {

            Button btn = (Button)sender;

            Navigation.PushAsync(new UserPage((string)btn.BindingContext));
        }
    }
}