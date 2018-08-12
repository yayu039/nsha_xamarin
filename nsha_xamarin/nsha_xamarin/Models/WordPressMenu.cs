using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsha_xamarin.Models
{
    /// <summary>
    /// This class is Data Transfer Object for Json
    /// Object retrieved from WordPress Menu API.
    /// </summary>
    public class WordPressMenu
    {
        /// <summary>
        /// The Property of ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Property of Items.
        /// </summary>
        public List<Item> Items { get; set; }
    }
}
