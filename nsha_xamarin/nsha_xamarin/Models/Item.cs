using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsha_xamarin.Models
{
    /// <summary>
    /// This class is Data Transfer Object for Json
    /// Object retrieved from WordPress Menu API
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The Property of ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Property of Order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The Property Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The Property of URL
        /// </summary>
        public string URL { get; set; }

    }
}
