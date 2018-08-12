using System;
using Xamarin.Forms;

namespace nsha_xamarin.Controls
{    
    /// <summary>
    /// This class wraps the NavigationPage 
    /// and initialize all the content pages in the project
    /// with BarBackgroundColor and BarTextColor
    /// </summary>
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

        /// <summary>
        /// Initialize the NavigationPage's 
        /// BarBackgroundColor and BarTextColor
        /// </summary>
        void Init()
        {
            BarBackgroundColor = Color.FromHex("#03A9F4");
            BarTextColor = Color.White;
        }
    }
}

