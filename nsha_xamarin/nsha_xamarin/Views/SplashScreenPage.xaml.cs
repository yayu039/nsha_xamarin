using Newtonsoft.Json;
using nsha_xamarin.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nsha_xamarin.Views
{
    /// <summary>
    /// This is Splash Screen when the app starts.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage : ContentPage
    {
        Image splashImage;
        List<HomeMenuItem> menuItems;
        string[] icons = new string[] { "menu_home.png", "menu_services.png", "menu_booking.png", "menu_feedback.png", "menu_about.png", "menu_contact.png", "menu_needles.png", "menu_needles.png", "menu_needles.png" };

        public SplashScreenPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "nshalogo.png",
                WidthRequest = 100,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#42e3b8");
            this.BackgroundImage = "splash.jpg";
            this.Content = sub;
        }
        /// <summary>
        /// Check Internet Availability 
        /// and run the initialization tasks.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("No Internet Connectivity", "Device is currently not connected to the internet", "OK");
                return;
            }
            else
            {

                Task splashTask = DisplaySplashAsync();
                Task initDataTask = RefreshDataAsync();
                await Task.WhenAll(splashTask, initDataTask);
                
                Application.Current.MainPage = new RootPage(menuItems);
            }
            
        }

        /// <summary>
        /// Display the splash screen.
        /// </summary>
        private async Task DisplaySplashAsync()
        {
            await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            splashImage.RotateTo(720, 4000);
            await splashImage.ScaleTo(0.9, 2000, Easing.Linear);
            await splashImage.ScaleTo(3.5, 2000, Easing.Linear);
        }

        /// <summary>
        /// Retrieve the Menu Items from the server.
        /// </summary>
        async Task RefreshDataAsync()
        {

            var httpClient = new HttpClient();
            var uri = new Uri(string.Format("https://nsha-web.000webhostapp.com/wp-json/wp-api-menus/v2/menus/2", string.Empty));
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                WordPressMenu wordPressMenu = JsonConvert.DeserializeObject<WordPressMenu>(content);
                List<Item> items = wordPressMenu.Items;

                menuItems = new List<HomeMenuItem>();

                if (items != null)
                {
                    Debug.WriteLine("items is not null, count:" + items.Count);

                    for (int i = 0; i < items.Count; i++)
                    {
                        HomeMenuItem menuItem = new HomeMenuItem();
                        menuItem.Title = items[i].Title;
                        menuItem.Order = items[i].Order;
                        menuItem.URL = items[i].URL;
                        menuItem.Icon = icons[i];                        
                        menuItems.Add(menuItem);
                    }

                    Debug.WriteLine("items is not null" + items.Count);
                    
                }
                else
                {                    
                    Debug.WriteLine("items is null ");
                }
            }
            else
            {                
                Debug.WriteLine("items is not null " + response.IsSuccessStatusCode);
            }

        }
    }
}