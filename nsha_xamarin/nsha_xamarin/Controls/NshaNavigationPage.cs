using System;
using Xamarin.Forms;

namespace nsha_xamarin.Controls
{
    public class NshaNavigationPage :NavigationPage
    {
        public NshaNavigationPage(Page root) : base(root)
        {
            Init();
        }

        public NshaNavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Color.FromHex("#03A9F4");
            BarTextColor = Color.White;
        }
    }
}

