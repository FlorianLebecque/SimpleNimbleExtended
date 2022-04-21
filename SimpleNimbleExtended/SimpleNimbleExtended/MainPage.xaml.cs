using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleNimbleExtended
{
    public partial class MainPage : ContentPage { 
        public MainPage() {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            

        }

        public void LoadAccount() {
            Controler ctrl = Controler.GetInstance();

            SL_Account.Children.Clear();

            Dictionary<string, SavedInfo> savedInfos = ctrl.GetSavedAccounts();
            foreach (string account in savedInfos.Keys) {
                Frame mainFram = new Frame();
                mainFram.Padding = new Thickness(0, 0, 0, 0);
                mainFram.HasShadow = true;
                mainFram.CornerRadius = 5;
                mainFram.Margin = new Thickness(0, 15, 0, 15);

                Grid mainGrid = new Grid();
                mainGrid.Padding = new Thickness(10);
                mainGrid.BackgroundColor = (Color)Application.Current.Resources["darkBackground"];


                ColumnDefinition columnDef1 = new ColumnDefinition();
                columnDef1.Width = GridLength.Auto;

                ColumnDefinition columnDef2 = new ColumnDefinition();
                columnDef2.Width = GridLength.Star;

                mainGrid.ColumnDefinitions.Add(columnDef1);
                mainGrid.ColumnDefinitions.Add(columnDef2);

                Frame picFram = new Frame();
                picFram.BackgroundColor = Color.Transparent;
                picFram.Padding = new Thickness(0, 0, 0, 0);
                picFram.HasShadow = false;
                picFram.CornerRadius = 100;
                picFram.HeightRequest = picFram.WidthRequest = 150;
                picFram.VerticalOptions = picFram.HorizontalOptions = LayoutOptions.Center;
                picFram.IsClippedToBounds = true;

                Image image = new Image();
                image.Source = string.Format("https://avatars.dicebear.com/api/bottts/{0}.png", savedInfos[account].name);
                image.Aspect = Aspect.AspectFill;

                picFram.Content = image;

                StackLayout sl_form = new StackLayout();
                sl_form.Padding = new Thickness(15, 15, 15, 0);

                Label lb_name = new Label();
                lb_name.FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
                lb_name.Text = savedInfos[account].name;

                Entry pass_entry = new Entry();
                pass_entry.Placeholder = "Password";
                pass_entry.Text = savedInfos[account].hashPass;
                pass_entry.IsEnabled = false;
                pass_entry.IsPassword = true;
                pass_entry.HorizontalOptions = LayoutOptions.FillAndExpand;


                Grid ctrlGrid = new Grid();

                Button rm_btn = new Button();
                rm_btn.Text = "X";
                rm_btn.VerticalOptions = LayoutOptions.End;
                rm_btn.HorizontalOptions = LayoutOptions.Start;
                rm_btn.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));
                rm_btn.Padding = new Thickness(15);
                rm_btn.Margin = new Thickness(0, 0, 10, 10);

                rm_btn.Clicked += (s, e) => {
                    ctrl.RemoveSavedInfo(account);
                    LoadAccount();

                };

                Button log_btn = new Button();
                log_btn.Text = "Login";
                log_btn.VerticalOptions = LayoutOptions.End;
                log_btn.HorizontalOptions = LayoutOptions.End;
                log_btn.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));
                log_btn.Padding = new Thickness(15);
                log_btn.Margin = new Thickness(0, 0, 10, 10);



                log_btn.Clicked += (s, e) => {
                    if (ctrl.QuickLogin(savedInfos[account])) {
                        Navigation.PushAsync(new Main());
                    } else {
                        DisplayAlert("Login", "Email or password incorrect", "OK");
                    }
                };


                ctrlGrid.Children.Add(rm_btn);
                ctrlGrid.Children.Add(log_btn);

                sl_form.Children.Add(lb_name);
                sl_form.Children.Add(pass_entry);
                sl_form.Children.Add(ctrlGrid);


                mainGrid.Children.Add(picFram);
                mainGrid.Children.Add(sl_form);

                Grid.SetColumn(picFram, 0);
                Grid.SetColumn(sl_form, 1);

                mainFram.Content = mainGrid;

                SL_Account.Children.Add(mainFram);
            }

            base.OnAppearing();
        }

        protected override void OnAppearing() {
            LoadAccount();
            
        }

        private void Bt_addAcount_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new LoginRegister());
        }

        private void Bt_rm_btn_Clicked(object sender, EventArgs e) { 

        }

        private void Bt_log_btn_Clicked(object sender, EventArgs e) {

        }
    }
}
