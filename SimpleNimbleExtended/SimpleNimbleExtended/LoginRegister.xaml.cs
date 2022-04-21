using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleNimbleExtended;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNimbleExtended
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginRegister : ContentPage {
        public LoginRegister() {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            InitializeComponent();
        }



        #region animation

        Boolean isRegisterExpend = false;
        Boolean isLoginExpend = false;

        uint animationTime = 100;

        private void Bt_expendLogin_Clicked(object sender, EventArgs e) {

            if (isLoginExpend) {
                var animation = new Animation(v => gd_login.HeightRequest = v, 170, 0);

                animation.Commit(gd_register, "SimpleAnimation", 1, animationTime, Easing.Linear, (v, c) => gd_login.HeightRequest = 0, () => false);

                Bt_expendLogin.Text = "▼";

            } else {
                var animation = new Animation(v => gd_login.HeightRequest = v, 0, 170);

                animation.Commit(gd_register, "SimpleAnimation", 1, animationTime, Easing.Linear, (v, c) => gd_login.HeightRequest = 170, () => false);
               
                Bt_expendLogin.Text = "▲";

            }

            isLoginExpend = !isLoginExpend;

        }

        private void Bt_expendRegister_Clicked(object sender, EventArgs e) {
            if (isRegisterExpend) {
                var animation = new Animation(v => gd_register.HeightRequest = v, 260, 0);

                animation.Commit(gd_register, "SimpleAnimation", 1, animationTime, Easing.Linear, (v, c) => gd_register.HeightRequest = 0, () => false);

                Bt_expendRegister.Text = "▼";

            } else {
                var animation = new Animation(v => gd_register.HeightRequest = v, 0, 260);

                animation.Commit(gd_register, "SimpleAnimation", 1, animationTime, Easing.Linear, (v, c) => gd_register.HeightRequest = 260, () => false);

                Bt_expendRegister.Text = "▲";

            }

            isRegisterExpend = !isRegisterExpend;
        }
        #endregion

        private void Bt_register_Clicked(object sender, EventArgs e) {
            Controler ctrl = Controler.GetInstance();

            string username = tb_userRegister.Text;
            string email = tb_emailRegister.Text;
            string passw1 = tb_pass1Register.Text;
            string passw2 = tb_pass2Register.Text;

            if ((passw1 == passw2)&&(ctrl.Register(username,email, passw1,sw_KeepRegister.IsToggled)))
            {
                Navigation.PushAsync(new Main());
            }
            else
            {
                DisplayAlert("Register", "Make sure your email is valide and your password match", "OK");
            }
        }

        private void Bt_login_Clicked(object sender, EventArgs e) {

    
            Controler ctrl = Controler.GetInstance();

            string username = tb_userLogin.Text;
            string passw = tb_passLogin.Text;

            if (ctrl.Login(username, passw,sw_KeepLogin.IsToggled)) {
                Navigation.PushAsync(new Main());
            } else {
                DisplayAlert("Login", "Email or password incorrect","OK");
            }

        }
    }
}