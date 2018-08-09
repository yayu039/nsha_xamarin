using Newtonsoft.Json;
using nsha_xamarin.Models;
using nsha_xamarin.ViewModels;
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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        RootPage rootPage;
        List<HomeMenuItem> menuItems;

        private MenuViewModel ViewModel
        {
            get { return BindingContext as MenuViewModel; }
        }

        public MenuPage (RootPage rootPage)
		{
            this.rootPage = rootPage;
            InitializeComponent ();
                        
            BindingContext = new MenuViewModel
            {
                Title = "NSHA.Forms",
                Subtitle = "NSHA.Forms",
                Icon = "slideout.png"
            };
            
            ListViewMenu.ItemsSource = this.rootPage.Menus;
            
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                await this.rootPage.NavigateAsync((HomeMenuItem)e.SelectedItem);
 
                ListViewMenu.SelectedItem = null;
            };
        }
        
        async Task RefreshDataAsync()
        {
            var httpClient = new HttpClient();
            var uri = new Uri(string.Format("https://nsha-demo.000webhostapp.com/wp-json/wp-api-menus/v2/menus/2", string.Empty));
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
                        menuItem.Icon = "about.png";                        
                        menuItems.Add(menuItem);
                    }
                    
                }
                else
                {
                    await DisplayAlert("Alert", "items is null", "OK");
                    Debug.WriteLine("items is null ");
                }
            }
            else
            {
                await DisplayAlert("Alert", "response.IsSuccessStatusCode:" + response.IsSuccessStatusCode, "OK");
                Debug.WriteLine("items is not null " + response.IsSuccessStatusCode);
            }

        }

    }
}