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
    public partial class WordPressWebPage : ContentPage
    {
        Page webPage;
        public WordPressWebPage(string url)
        {
            InitializeComponent();
            webPage = new Page();
            
            Browser.Source = url;
            
        }

        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {            
            string js = "var x = document.getElementById('site-header').style.display = 'none';document.getElementById('footer').style.display = 'none';";
            Browser.Eval(js);
            progress.IsVisible = true;
        }

        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            string js = "var x = document.getElementById('site-header').style.display = 'none';document.getElementById('footer').style.display = 'none';";
            Browser.Eval(js);
            progress.IsVisible = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string js = "var x = document.getElementById('site-header').style.display = 'none';document.getElementById('footer').style.display = 'none';";
            Browser.Eval(js);
            await progress.ProgressTo(0.9, 900, Easing.SpringIn);
        }
    }
}