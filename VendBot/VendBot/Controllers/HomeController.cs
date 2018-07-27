using System.Web.Mvc;

namespace VendBot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // connect to MySQL db and run get all for vending machines
            var vendingMachine = InventoryManager.GetInventory();

            return View(vendingMachine);
        }

        [HttpPost]
        public ActionResult GetItem(string type, int id)
        {
            var quantity = InventoryManager.GetItem(type, id);

            return Json(new { Type = type, Id = id, Quantity = quantity }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult StockItem(string type, int id, int count)
        {
            var quantity = InventoryManager.StockItem(type, id, count);

            return Json(new { Type = type, Id = id, Quantity = quantity }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}