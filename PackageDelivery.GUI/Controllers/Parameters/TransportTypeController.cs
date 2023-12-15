using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System;
using PackageDelivery.GUI.Mappers.Parameters;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class TransportTypeController : Controller
    {
        private ITransportTypeApplication _app;

        public TransportTypeController(ITransportTypeApplication app)
        {
            this._app = app;
        }

        // GET: TransportType
        public ActionResult Index(string filter = "")
        {
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            IEnumerable<TransportTypeModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: TransportType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel TransportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (TransportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(TransportTypeModel);
        }

        // GET: TransportType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TransportTypeModel TransportTypeModel)
        {
            if (ModelState.IsValid)
            {
                TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
                TransportTypeDTO response = _app.createRecord(mapper.ModelToDTOMapper(TransportTypeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(TransportTypeModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(TransportTypeModel);
        }

        // GET: TransportType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel TransportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (TransportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(TransportTypeModel);
        }

        // POST: TransportType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TransportTypeModel TransportTypeModel)
        {
            if (ModelState.IsValid)
            {
                TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
                TransportTypeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(TransportTypeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(TransportTypeModel);
        }

        // GET: TransportType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel TransportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (TransportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(TransportTypeModel);
        }

        // POST: TransportType/Delete/5
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