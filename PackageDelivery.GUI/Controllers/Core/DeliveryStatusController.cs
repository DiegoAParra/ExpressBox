using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class DeliveryStatusController : Controller
    {
        private IDeliveryStatusApplication _app;
        public DeliveryStatusController(IDeliveryStatusApplication app)
        {
            this._app = app;
        }

        // GET: DeliveryStatus
        public ActionResult Index(string filter = "")
        {
            DeliveryStatusGUIMapper mapper = new DeliveryStatusGUIMapper();
            IEnumerable<DeliveryStatusModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: DeliveryStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatusGUIMapper mapper = new DeliveryStatusGUIMapper();
            DeliveryStatusModel DeliveryStatusModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DeliveryStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(DeliveryStatusModel);
        }

        // GET: DeliveryStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryStatus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DeliveryStatusModel DeliveryStatusModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryStatusGUIMapper mapper = new DeliveryStatusGUIMapper();
                DeliveryStatusDTO response = _app.createRecord(mapper.ModelToDTOMapper(DeliveryStatusModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(DeliveryStatusModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(DeliveryStatusModel);
        }

        // GET: DeliveryStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatusGUIMapper mapper = new DeliveryStatusGUIMapper();
            DeliveryStatusModel DeliveryStatusModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DeliveryStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(DeliveryStatusModel);
        }

        // POST: DeliveryStatus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DeliveryStatusModel DeliveryStatusModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryStatusGUIMapper mapper = new DeliveryStatusGUIMapper();
                DeliveryStatusDTO response = _app.updateRecord(mapper.ModelToDTOMapper(DeliveryStatusModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(DeliveryStatusModel);
        }

        // GET: DeliveryStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatusGUIMapper mapper = new DeliveryStatusGUIMapper();
            DeliveryStatusModel DeliveryStatusModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DeliveryStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(DeliveryStatusModel);
        }

        // POST: DeliveryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool response = _app.deleteRecordById(id);
            if (response)
            {
                ViewBag.ClassName = ActionMessages.successClass;
                ViewBag.Message = ActionMessages.succesMessage;
                return RedirectToAction("Index");
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View();
        }
    }
}