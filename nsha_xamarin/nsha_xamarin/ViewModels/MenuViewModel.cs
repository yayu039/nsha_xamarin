using Newtonsoft.Json;
using nsha_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace nsha_xamarin.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        private ObservableCollection<HomeMenuItem> menuItems = new ObservableCollection<HomeMenuItem>();

        public ObservableCollection<HomeMenuItem> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; OnPropertyChanged(); }
        }

        private HomeMenuItem selectedMenuItem;
        public HomeMenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                selectedMenuItem = value;
                OnPropertyChanged();
            }
        }

        private Command loadItemsCommand;

        public Command LoadItemsCommand
        {
            get { return loadItemsCommand ?? (loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand())); }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var error = false;
            var page = new ContentPage();
            try
            {
                var httpClient = new HttpClient();

                var uri = new Uri(string.Format("https://nsha-demo.000webhostapp.com/wp-json/wp-api-menus/v2/menus/2", string.Empty));
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    WordPressMenu wordPressMenu = JsonConvert.DeserializeObject<WordPressMenu>(content);
                    var wpItems = wordPressMenu.Items;

                    //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(content.Substring(content.IndexOf('['), content.LastIndexOf(']') + 1));

                    menuItems.Clear();

                    if (wpItems != null)
                    {
                        Debug.WriteLine("items is not null, count:" + wpItems.Count);


                        foreach (var wpItem in wpItems)
                        {
                            HomeMenuItem menuItem = new HomeMenuItem();
                            menuItem.Title = wpItem.Title;
                            menuItem.Order = wpItem.Order;
                            menuItem.Icon = "about.png";                            
                            menuItems.Add(menuItem);
                        }
                        
                    }
                    else
                    {
                        Debug.WriteLine("items is null ");
                        await page.DisplayAlert("Error", "Unable to load podcast feed.", "OK");
                        
                    }
                }
                else
                {
                    Debug.WriteLine("items is not null " + response.IsSuccessStatusCode);
                    await page.DisplayAlert("Error", "Unable to load podcast feed.", "OK");
                    
                }
            }
            catch
            {
                error = true;
            }
            IsBusy = false;
        }
    }

    
}
