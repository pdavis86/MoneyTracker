using System.Collections.Generic;

namespace MoneyTracker.Web.ViewModels
{
    public class Series
    {
        public string Title { get; set; }
        public IEnumerable<decimal> Data { get; set; }
    }
}