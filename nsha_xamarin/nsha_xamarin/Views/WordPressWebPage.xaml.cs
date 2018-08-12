using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nsha_xamarin.Views
{
    /// <summary>
    /// This is the navigation page for each Menu Item.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordPressWebPage : ContentPage
    {
        Page webPage;
        public WordPressWebPage(string url)
        {
            InitializeComponent();
            webPage = new Page();
            
            Browser.Source = url;
            
        }

        /// <summary>
        /// Remvoe the header and footer from the content
        /// Start the progress bar
        /// </summary>
        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {            
            string js = "var x = document.getElementById('site-header').style.display = 'none';document.getElementById('footer').style.display = 'none';";
            Browser.Eval(js);
            progress.IsVisible = true;
        }

        /// <summary>
        /// Remvoe the header and footer from the content.
        /// End the progress bar
        /// </summary>
        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            string js = "var x = document.getElementById('site-header').style.display = 'none';document.getElementById('footer').style.display = 'none';";
            Browser.Eval(js);
            progress.IsVisible = false;
        }

        /// <summary>
        /// Show the progress bar when the page is loading.
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string js = "var x = document.getElementById('site-header').style.display = 'none';document.getElementById('footer').style.display = 'none';";
            Browser.Eval(js);
            await progress.ProgressTo(0.9, 900, Easing.SpringIn);
        }
    }
}