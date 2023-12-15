using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class DepartmentController : Controller
    {
        private IDepartmentApplication _app;

        public DepartmentController(IDepartmentApplication app)
        {
            this._app = app;
        }

        // GET: Department
        public ActionResult Index(string filter = "")
        {
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            IEnumerable<DepartmentModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel DepartmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DepartmentModel == null)
            {
                return HttpNotFound();
            }
            return View(DepartmentModel);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DepartmentModel DepartmentModel)
        {
            if (ModelState.IsValid)
            {
                DepartmentGUIMapper mapper = new DepartmentGUIMapper();
                DepartmentDTO response = _app.createRecord(mapper.ModelToDTOMapper(DepartmentModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(DepartmentModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(DepartmentModel);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel DepartmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DepartmentModel == null)
            {
                return HttpNotFound();
            }
            return View(DepartmentModel);
        }

        // POST: Department/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DepartmentModel DepartmentModel)
        {
            if (ModelState.IsValid)
            {
                DepartmentGUIMapper mapper = new DepartmentGUIMapper();
                DepartmentDTO response = _app.updateRecord(mapper.ModelToDTOMapper(DepartmentModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(DepartmentModel);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel DepartmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DepartmentModel == null)
            {
                return HttpNotFound();
            }
            return View(DepartmentModel);
        }

        // POST: Department/Delete/5
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