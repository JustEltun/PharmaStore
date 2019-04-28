using PharmaStoreData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PharmacyStoreDotNet.Controllers
{
    public class DrugsController : Controller
    {
        private readonly PharmaContext context;
        public DrugsController()
        {
            context = new PharmaContext();
        }
        // GET: DrugList
        public ActionResult DrugList()
        {
            var model = context.Drugs();
            return PartialView("~/views/drugs/druglist.cshtml", model);
        }
        //SEARCH
        public async Task<JsonResult> Find(string target)
        {
            List<Drug> model;

            if (!string.IsNullOrEmpty(target))
            {
                model = await context.Find("name", target);

                if (model.Count == 0)
                    model = await context.Find("description", target);

                return Json(model);
            }
            return Json("error");
        }
        //ABOUT
        public async Task<ActionResult> About(int? id)
        {
            if (id != null)
            {
                var model = from drug in await context.DrugsAsync()
                            where drug.Id == id
                            select drug;
                if (model.FirstOrDefault() != null)
                    return View(model.FirstOrDefault());
            }

            return HttpNotFound();
        }
    }
}