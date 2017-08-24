using Store.Core.Models;
using Store.Data.Services;
using Store.Web.ViewModels;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace Store.Web.Controllers
{
    public class PencilController : Controller
    {
        private readonly IStoreService _service; 
        public PencilController(IStoreService service)
        {
            _service = service; 
        }
        // GET: Pencil
        public ActionResult Index(int Id)
        {
            return View(_service.GetPencilById(Id));
        }
        public ActionResult Create()
        {
            ViewBag.Buyers = _service.GetAllBuyers();
            return View("Create");
        }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(  PencilViewModel model)
        {
            var newItem =  new Pencil(model.Title,model.Price,model.Description);
            var buyers = _service.GetAllBuyers();
            foreach (var item in model.Buyers)
            {
                var sellectedBuyer = buyers.FirstOrDefault(b => b.Id == item);
                newItem.Buyers.Add(sellectedBuyer);
            }
        
            _service.CreateNewPencil(newItem, model.File.InputStream, model.File.FileName);
            return Redirect("/");
        }
    }
}