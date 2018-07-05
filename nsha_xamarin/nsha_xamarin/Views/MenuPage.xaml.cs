using nsha_xamarin.Models;
using nsha_xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public MenuPage (RootPage rootPage)
		{
            this.rootPage = rootPage;
            InitializeComponent ();

            BindingContext = new BaseViewModel
            {
                Title = "NSHA.Forms",
                Subtitle = "NSHA.Forms",
                Icon = "slideout.png"
            };

            ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = "Home", MenuType = MenuType.Home, Icon ="about.png" },
                    new HomeMenuItem { Title = "Services", MenuType = MenuType.Services, Icon = "blog.png" },
                    new HomeMenuItem { Title = "Booking", MenuType = MenuType.Booking, Icon = "twitternav.png" },
                    new HomeMenuItem { Title = "About Us", MenuType = MenuType.About, Icon = "hm.png" },
                    new HomeMenuItem { Title = "Contact Us", MenuType = MenuType.Contact, Icon = "ratchet.png" },
                    new HomeMenuItem { Title = "FeedBack", MenuType = MenuType.FeedBack, Icon = "tdl.png"},
                    
                };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                await this.rootPage.NavigateAsync((int)((HomeMenuItem)e.SelectedItem).MenuType);
            };
        }
	}
}