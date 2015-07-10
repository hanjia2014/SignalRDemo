using Microsoft.AspNet.SignalR;
using MVCSignalRDemo.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCSignalRDemo.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: /Home/
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,RollNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                var context = GlobalHost.ConnectionManager.GetHubContext<StudentChange>();
                context.Clients.All.Poke("update");
                //return RedirectToAction("Index");
            }

            return View(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
