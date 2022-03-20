using System.Collections.Generic;

namespace MoneyTracker.Web.ViewModels
{
    public class Chart
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> XAxisCategories { get; set; }
        public string YAxisTitle { get; set; }
        public IEnumerable<Series> Series { get; set; }
    }
}