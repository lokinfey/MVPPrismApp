using System;
using System.Collections.ObjectModel;

namespace MVPPrismApp.Lib.Models
{
    public class NewsInfoItem
    {
        public int ID { get; set; }

        public string NewsTitle { get; set; }

        public string NewsDate { get; set; }

        public string NewsLocation { get; set; }

        public ObservableCollection<NewsItem> NewsList { get; set; }
    }
}
