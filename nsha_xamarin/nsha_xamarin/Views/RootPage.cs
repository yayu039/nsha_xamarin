using nsha_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using nsha_xamarin.Controls;
using nsha_xamarin.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace nsha_xamarin.Views
{
    public class RootPage : MasterDetailPage
    {
        public static bool IsUWPDesktop { get; set; }
        Dictionary<int, NavigationPage> Pages { get; set; }
                
        public List<HomeMenuItem> Menus { get; set; }

        public RootPage(List<HomeMenuItem> menuItems)
        {
            this.Menus = menuItems;

            if (IsUWPDesktop)
                this.MasterBehavior = MasterBehavior.Popover;
            Pages = new Dictionary<int, NavigationPage>();
            
            MenuPage menuPage = new MenuPage(this);
            
            Master = menuPage;
            
            BindingContext = new BaseViewModel
            {
                Title = "NSHA",
                Icon = "slideout.png"
            };
            
            Pages.Add(1, new NshaNavigationPage(new WordPressWebPage(menuItems[0].URL) { Title = menuItems[0].Title }) {BarBackgroundColor = Color.Green});
            Detail = Pages[1];

            InvalidateMeasure();
        }
        
        public async Task NavigateAsync(HomeMenuItem item)
        {            
            if (Detail != null)
            {
                if (IsUWPDesktop || Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(300);
            }
            
            Page newPage;
            if (!Pages.ContainsKey(item.Order))
            {
                Pages.Add(item.Order, new NavigationPage(new WordPressWebPage(item.URL) { Title = item.Title }) { BarBackgroundColor = Color.Green });               
            }

            newPage = Pages[item.Order];
            if (newPage == null)
                return;
            
            Detail = newPage;
            
        }        
    }
}
