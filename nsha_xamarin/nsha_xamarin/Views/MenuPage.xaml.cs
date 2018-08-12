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
    /// <summary>
    /// This Page is for rendering the Menu of the App.
    /// </summary>
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
        
    }
}