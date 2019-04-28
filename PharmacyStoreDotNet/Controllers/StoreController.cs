using PharmaStoreData;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PharmacyStoreDotNet.Controllers
{
    public class StoreController : Controller
    {
        private readonly PharmaContext context;
        public StoreController()
        {
            context = new PharmaContext();
        }
        // GET
        public ActionResult Main() => View();

        [Route("~/store/medicines")]
        public async Task<ActionResult> Drugs()
        {
            var model = await context.DrugsAsync();
            return View(model);
        }
    }
}