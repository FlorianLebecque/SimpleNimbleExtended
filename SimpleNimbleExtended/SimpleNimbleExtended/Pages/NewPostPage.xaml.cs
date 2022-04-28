using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNimbleExtended.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPostPage : ContentPage {
        public NewPostPage() {
            InitializeComponent();

        }

        public void Btn_save_click(object sender, EventArgs e) {
            string title = tb_title.Text;
            string content = tb_content.Text;

            bool res = Controler.GetInstance().SavePost(title, content);

            if (res) {
                DisplayAlert("Info", "Your post has been saved", "OK");
            } else {
                DisplayAlert("Info", "An error has occured, please try again later", "OK");
            }

            Navigation.PopAsync();
        }
    }
}