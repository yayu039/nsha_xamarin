using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsha_xamarin.Models
{
    /// <summary>
    /// This class is the data model of Menu Items of the
    /// Drawer Menu of the app
    /// </summary>
    public class HomeMenuItem : INotifyPropertyChanged
    {
        public HomeMenuItem()
        {
        }

        /// <summary>
        /// This Property is the Title of Menu Item
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// This Property is the Icon of the Menu Item
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// This Property is the Order of the Menu Item in the Menu
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// This Property is the Navigation URL of the Menu Item.
        /// </summary>
        public string URL { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
