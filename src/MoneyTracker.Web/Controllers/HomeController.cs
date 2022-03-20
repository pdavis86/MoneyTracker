using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MoneyTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("/Views/Home.cshtml");
        }

        public ActionResult GetData()
        {
            var db = Core.Factories.DatabaseServiceFactory.GetNewDatabaseService();
            var data = db.GetTransactionsBetween(DateTime.Now.AddMonths(-12), DateTime.Now);

            //todo: don't include this month
            //todo: remove
            data = data.Where(x => x.AccountId == 8).ToList();

            var categories = db.GetTransactionCategories();

            var dateGrouping = data
                //.GroupBy(r => r.Date.ToShortDateString())
                .GroupBy(r => r.Date.ToString("yyyy-MM"))
                .OrderBy(g => g.Key);

            var seriesList = new List<ViewModels.Series>();

            foreach (var category in categories)
            {
                seriesList.Add(new ViewModels.Series
                {
                    Title = category.Description,
                    Data = dateGrouping.Select(g => g
                        .Where(r => r.CategoryId == category.CategoryId)
                        .Sum(r => r.Value * -1)
                    )
                });
            }

            seriesList.Add(new ViewModels.Series
            {
                Title = "[All Income]",
                Data = dateGrouping.Select(g => g
                    .Where(r => r.Value >= 0)
                    .Sum(r => r.Value)
                    )
            });

            seriesList.Add(new ViewModels.Series
            {
                Title = "[All Expenditure]",
                Data = dateGrouping.Select(g => g
                    .Where(r => r.Value < 0)
                    .Sum(r => r.Value * -1)
                    )
            });

            seriesList.Add(new ViewModels.Series
            {
                Title = "[All]",
                Data = dateGrouping.Select(g => g
                    .Sum(r => r.Value)
                    )
            });

            return new JsonResult()
            {
                Data = new ViewModels.Chart
                {
                    Type = "line",
                    Title = "Spending by category",
                    YAxisTitle = "Amount Spent",
                    XAxisCategories = dateGrouping.Select(g => g.Key),
                    Series = seriesList
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            //return new JsonResult()
            //{
            //    Data = new ViewModels.Chart
            //    {
            //        Type = "line",
            //        Title = "Our Fruit Consumption",
            //        YAxisTitle = "Pieces of fruit",
            //        XAxisCategories = new[] { "Lemons", "Limes", "Avocado" },
            //        Series = new []
            //        {
            //            new ViewModels.Series
            //            {
            //                Title = "Paul",
            //                Data = new decimal[] { 8 , 2 , 0 }
            //            },
            //            new ViewModels.Series
            //            {
            //                Title = "Chelsea",
            //                Data = new decimal[] { 1 , 20 , 6 }
            //            }
            //        }
            //    },
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};

            //return new JsonResult()
            //{
            //    Data = new[] {
            //        new {
            //            name = "Jane",
            //            data = new[] {1, 0, 4 }
            //        }, new {
            //        name = "John",
            //            data = new[] {5, 7, 3}
            //        }
            //    },
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};

            //return new ContentResult
            //{
            //    Content = JsonConvert.SerializeObject(new[] {
            //        new {
            //            name = "Jane",
            //            data = new[] {1, 0, 4 }
            //        }, new {
            //        name = "John",
            //            data = new[] {5, 7, 3}
            //        }
            //    })
            //};
        }
    }
}