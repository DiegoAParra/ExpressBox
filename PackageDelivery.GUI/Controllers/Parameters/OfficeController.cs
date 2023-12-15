using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class OfficeController : Controller
    {
        private IOfficeApplication _app;
        private ICityApplication _dtapp;

        public OfficeController(IOfficeApplication app, ICityApplication dtapp)
        {
            this._app = app;
            this._dtapp = dtapp;
        }

        // GET: Office
        public ActionResult Index(string filter = "")
        {
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            IEnumerable<OfficeModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));

            CityGUIMapper cmapper = new CityGUIMapper();
            IEnumerable<CityModel> listdt = cmapper.DTOToModelMapper(_dtapp.getRecordList(filter));

            foreach (var item in list)
            {
                foreach (var itemdt in listdt)
                {
                    if (item.Id_City == itemdt.Id)
                    {
                        item.CityName = itemdt.Name;
                    }
                }
            }
            return View(list);
        }

        // GET: Office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel OfficeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (OfficeModel == null)
            {
                return HttpNotFound();
            }
            CityGUIMapper cmapper = new CityGUIMapper();
            CityModel CityModel = cmapper.DTOToModelMapper(_dtapp.getRecordById(((int)OfficeModel.Id_City)));
            OfficeModel.CityName = CityModel.Name;
            return View(OfficeModel);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            OfficeModel model = new OfficeModel()
            {
                CityList = dtMapper.DTOToModelMapper(dtList)
            };
            return View(model);
        }

        // POST: Office/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Direction,Code,CellPhone," +
            "Latitude,Longitude,Id_City")] OfficeModel OfficeModel)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                OfficeDTO response = _app.createRecord(mapper.ModelToDTOMapper(OfficeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(OfficeModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(OfficeModel);
        }

        // GET: Office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel OfficeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            OfficeModel.CityList = dtMapper.DTOToModelMapper(dtList);
            if (OfficeModel == null)
            {
                return HttpNotFound();
            }
            return View(OfficeModel);
        }

        // POST: Office/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Direction,Code,CellPhone," +
            "Latitude,Longitude,Id_City")] OfficeModel OfficeModel)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                OfficeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(OfficeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(OfficeModel);
        }

        // GET: Office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel OfficeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (OfficeModel == null)
            {
                return HttpNotFound();
            }
            CityGUIMapper cmapper = new CityGUIMapper();
            CityModel CityModel = cmapper.DTOToModelMapper(_dtapp.getRecordById(((int)OfficeModel.Id_City)));
            OfficeModel.CityName = CityModel.Name;
            return View(OfficeModel);
        }

        // POST: Office/Delete/5
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