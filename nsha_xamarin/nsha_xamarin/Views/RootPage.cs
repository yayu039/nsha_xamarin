using nsha_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using nsha_xamarin.Controls;
using nsha_xamarin.ViewModels;

namespace nsha_xamarin.Views
{
    public class RootPage : MasterDetailPage
    {
        public static bool IsUWPDesktop { get; set; }
        Dictionary<int, NavigationPage> Pages { get; set; }
        public RootPage()
        {
            if (IsUWPDesktop)
                this.MasterBehavior = MasterBehavior.Popover;
            Pages = new Dictionary<int, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
            {
                Title = "NSHA",
                Icon = "slideout.png"
            };
            //setup home page
            Pages.Add((int)MenuType.Home, new NshaNavigationPage(new HomePage()));
            Detail = Pages[(int)MenuType.Home];

            InvalidateMeasure();
        }

        public async Task NavigateAsync(int id)
        {

            if (Detail != null)
            {
                if (IsUWPDesktop || Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(300);
            }

            Page newPage;
            if (!Pages.ContainsKey(id))
            {

                switch (id)
                {
                    case (int)MenuType.Home:
                        Pages.Add(id, new NshaNavigationPage(new HomePage()));
                        break;
                    case (int)MenuType.Services:
                        Pages.Add(id, new NshaNavigationPage(new ServicesPage()));
                        break;
                    case (int)MenuType.Booking:
                        Pages.Add(id, new NshaNavigationPage(new BookingPage()));
                        break;
                    case (int)MenuType.About:
                        Pages.Add(id, new NshaNavigationPage(new AboutUsPage()));
                        break;
                    case (int)MenuType.Contact:
                        Pages.Add(id, new NshaNavigationPage(new ContactUsPage()));
                        break;
                    case (int)MenuType.FeedBack:
                        Pages.Add(id, new NshaNavigationPage(new FeedBackPage()));
                        break;
                    
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            //if (Detail != null && Device.RuntimePlatform == Device.WinPhone)
            //{
            //    await Detail.Navigation.PopToRootAsync();
            //}

            Detail = newPage;
        }
    }
}
