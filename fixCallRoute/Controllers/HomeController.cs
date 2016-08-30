using System.Web.Mvc;

namespace fixCallRoute.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var results = new CallController().Get();

            return View(results);
        }

        public void Fix()
        {
            var controller = new CallController();
            var repo = new Models.CallRepository();
            foreach (var call in controller.Get())
            {
                repo.FixCall(call);
            }
            Response.Redirect("http://walwss01ifnba.na.tigplc.com/fixclaim");
        }
    }
}
