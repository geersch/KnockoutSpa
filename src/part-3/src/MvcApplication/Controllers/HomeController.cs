using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var mongoDb = MongoDatabase.Create(ConfigurationManager.AppSettings["MongoDBTimesheets"]);
            //var repository = mongoDb.GetCollection<Timesheet>(typeof(Timesheet).Name);
            //var timesheets = new List<Timesheet>
            //{
            //    new Timesheet { FirstName = "Christophe", LastName = "Geers", Month = 8, Year = 2012},
            //    new Timesheet { FirstName = "Ruben", LastName = "Geers", Month = 8, Year = 2012 }
            //};
            //foreach (var timesheet in timesheets)
            //    repository.Insert(timesheet);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
