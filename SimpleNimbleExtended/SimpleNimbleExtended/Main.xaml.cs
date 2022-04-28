using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SimpleNimbleExtended.Pages;

namespace SimpleNimbleExtended {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : TabbedPage {
        public Main() {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this,false);

            Label lb = new Label();
            lb.Text = Controler.GetInstance().username;
            lb.FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
            lb.TextColor = Color.White;

            NavigationPage.SetTitleView(this,lb);

            homePage.Content = new HomeView();
            searchPage.Content = new SearchView();
            youPage.Content = new UserView(Controler.GetInstance().id);
        }
    }
}