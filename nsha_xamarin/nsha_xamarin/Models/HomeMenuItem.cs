using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsha_xamarin.Models
{
    public enum MenuType
    {
        Home,
        Services,
        Booking,
        About,
        Contact,
        FeedBack
    }

    class HomeMenuItem
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.Home;
        }

        public string Title { get; set; }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}
