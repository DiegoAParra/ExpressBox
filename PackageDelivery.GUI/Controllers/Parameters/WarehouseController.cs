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
    public class WarehouseController : Controller
    {
        private IWarehouseApplication _app;
        private ICityApplication _dtapp;

        public WarehouseController(IWarehouseApplication app, ICityApplication dtapp)
        {
            this._app = app;
            this._dtapp = dtapp;
        }

        // GET: Warehouse
        public ActionResult Index(string filter = "")
        {
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));

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

        // GET: Warehouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (WarehouseModel == null)
            {
                return HttpNotFound();
            }
            CityGUIMapper cmapper = new CityGUIMapper();
            CityModel CityModel = cmapper.DTOToModelMapper(_dtapp.getRecordById(((int)WarehouseModel.Id_City)));
            WarehouseModel.CityName = CityModel.Name;
            return View(WarehouseModel);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            WarehouseModel model = new WarehouseModel()
            {
                CityList = dtMapper.DTOToModelMapper(dtList)
            };
            return View(model);
        }

        // POST: Warehouse/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Direction,Code,Latitude,Longitude," +
            "Id_City")] WarehouseModel WarehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.createRecord(mapper.ModelToDTOMapper(WarehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(WarehouseModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(WarehouseModel);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            WarehouseModel.CityList = dtMapper.DTOToModelMapper(dtList);
            if (WarehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(WarehouseModel);
        }

        // POST: Warehouse/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Direction,Code,Latitude,Longitude," +
            "Id_City")] WarehouseModel WarehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.updateRecord(mapper.ModelToDTOMapper(WarehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(WarehouseModel);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (WarehouseModel == null)
            {
                return HttpNotFound();
            }
            CityGUIMapper cmapper = new CityGUIMapper();
            CityModel CityModel = cmapper.DTOToModelMapper(_dtapp.getRecordById(((int)WarehouseModel.Id_City)));
            WarehouseModel.CityName = CityModel.Name;
            return View(WarehouseModel);
        }

        // POST: Warehouse/Delete/5
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