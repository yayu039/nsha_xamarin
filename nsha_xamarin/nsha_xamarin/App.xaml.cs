using Newtonsoft.Json;
using nsha_xamarin.Models;
using nsha_xamarin.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace nsha_xamarin
{
    public partial class App : Application
    {
        SplashScreenPage splash;
        
        public App()
        {
            InitializeComponent();           

            splash = new SplashScreenPage();
            
            Current.MainPage = splash;
                
        }

    }
}
