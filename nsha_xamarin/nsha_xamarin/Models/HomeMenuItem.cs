using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsha_xamarin.Models
{    
    public class HomeMenuItem : INotifyPropertyChanged
    {
        public HomeMenuItem()
        {
        }

        public string Title { get; set; }
        public string Icon { get; set; }        
        public int Order { get; set; }
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
