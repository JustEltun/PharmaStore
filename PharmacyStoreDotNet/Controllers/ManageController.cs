using PharmaStoreData;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PharmacyStoreDotNet.Controllers
{
    public class ManageController : Controller
    {
        private readonly PharmaContext context;

        public ManageController()
        {
            context = new PharmaContext();
        }

        // ADD
        public ActionResult Add() => View();
        [HttpPost]
        public async Task<ActionResult> Add(Drug drug)
        {
            if (ModelState.IsValid)
            {
                await context.Add(drug);
                return RedirectToAction("medicines", "store");
            }
            return View(drug);
        }

        // EDIT
        public async Task<ActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var drug = from drugs in await context.DrugsAsync()
                           where drugs.Id == id
                           select drugs;
                if (drug.FirstOrDefault() != null)
                    return View(drug.FirstOrDefault());               
            }
            return HttpNotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Drug drug)
        {
            if (ModelState.IsValid)
            {
                await context.Edit(drug);
                return RedirectToAction("medicines", "store");
            }

            return View(drug);
        }

        //DELETE
        [HttpPost]
        public async Task Delete(int? id)
        {
            if (id != null)
                await context.Delete(id);
        }
    }
}