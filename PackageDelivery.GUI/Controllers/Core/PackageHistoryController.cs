using Microsoft.Reporting.WebForms;
using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.GUI.Models.Parameters;
using PackagePackageHistory.GUI.Mappers.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class PackageHistoryController : Controller
    {
        private IPackageHistoryApplication _app;
        private IPackageApplication _dtapp;
        private IWarehouseApplication _dt2app;

        public PackageHistoryController(IPackageHistoryApplication app, IPackageApplication dtapp,
            IWarehouseApplication dt2app)
        {
            this._app = app;
            this._dtapp = dtapp;
            this._dt2app = dt2app;
        }

        // GET: PackageHistory
        public ActionResult Index(string filter = "")
        {
            PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
            IEnumerable<PackageHistoryModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));

            WarehouseGUIMapper tmapper = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> listdt = tmapper.DTOToModelMapper(_dt2app.getRecordList(filter));

            foreach (var item in list)
            {
                foreach (var itemdt in listdt)
                {
                    if (item.Id_Warehouse == itemdt.Id)
                    {
                        item.WarehouseName = itemdt.Name;
                    }
                }
            }
            return View(list);
        }

        // GET: PackageHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
            PackageHistoryModel PackageHistoryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (PackageHistoryModel == null)
            {
                return HttpNotFound();
            }
            WarehouseGUIMapper wmapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = wmapper.DTOToModelMapper(_dt2app.getRecordById(((int)PackageHistoryModel.Id_Warehouse)));
            PackageHistoryModel.WarehouseName = WarehouseModel.Name;
            return View(PackageHistoryModel);
        }

        // GET: PackageHistory/Create
        public ActionResult Create()
        {
            IEnumerable<PackageDTO> dtList = this._dtapp.getRecordList(string.Empty);
            IEnumerable<WarehouseDTO> dt2List = this._dt2app.getRecordList(string.Empty);

            PackageGUIMapper dtMapper = new PackageGUIMapper();
            WarehouseGUIMapper dt2Mapper = new WarehouseGUIMapper();
           
            PackageHistoryModel model = new PackageHistoryModel()
            {
                PackageList = dtMapper.DTOToModelMapper(dtList),
                WarehouseList = dt2Mapper.DTOToModelMapper(dt2List),
            };
            return View(model);
        }

        // POST: PackageHistory/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdmissionDate," +
            "DepurateDate,Description,Id_Package,Id_Warehouse")] PackageHistoryModel PackageHistoryModel)
        {
            if (ModelState.IsValid)
            {
                PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
                PackageHistoryDTO response = _app.createRecord(mapper.ModelToDTOMapper(PackageHistoryModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(PackageHistoryModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(PackageHistoryModel);
        }

        // GET: PackageHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
            PackageHistoryModel PackageHistoryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));

            IEnumerable<PackageDTO> dtList = this._dtapp.getRecordList(string.Empty);
            IEnumerable<WarehouseDTO> dt2List = this._dt2app.getRecordList(string.Empty);

            PackageGUIMapper dtMapper = new PackageGUIMapper();
            WarehouseGUIMapper dt2Mapper = new WarehouseGUIMapper();

            PackageHistoryModel.PackageList = dtMapper.DTOToModelMapper(dtList);
            PackageHistoryModel.WarehouseList = dt2Mapper.DTOToModelMapper(dt2List);
            if (PackageHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(PackageHistoryModel);
        }

        // POST: PackageHistory/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdmissionDate,DepurateDate," +
            "Description,Id_Package,Id_Warehouse")] PackageHistoryModel PackageHistoryModel)
        {
            if (ModelState.IsValid)
            {
                PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
                PackageHistoryDTO response = _app.updateRecord(mapper.ModelToDTOMapper(PackageHistoryModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(PackageHistoryModel);
        }

        // GET: PackageHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
            PackageHistoryModel PackageHistoryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (PackageHistoryModel == null)
            {
                return HttpNotFound();
            }
            WarehouseGUIMapper wmapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = wmapper.DTOToModelMapper(_dt2app.getRecordById(((int)PackageHistoryModel.Id_Warehouse)));
            PackageHistoryModel.WarehouseName = WarehouseModel.Name;
            return View(PackageHistoryModel);
        }

        // POST: PackageHistory/Delete/5
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

        public ActionResult PackageHistory_Report(string format = "PDF")
        {
            var list = _app.getRecordList(string.Empty);
            PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
            List<PackageHistoryModel> recordsList = mapper.DTOToModelMapper(list).ToList();

            WarehouseGUIMapper tmapper = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> listdt = tmapper.DTOToModelMapper(_dt2app.getRecordList(""));

            foreach (var item in recordsList)
            {
                item.PackageName = item.Id_Package.ToString();
                foreach (var itemdt in listdt)
                {
                    if (item.Id_Warehouse == itemdt.Id)
                    {
                        item.WarehouseName = itemdt.Name;
                    }
                }
            }

            string reportPath = Server.MapPath("~/Reports/rdlcFiles/PackageHistoryReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource res = new ReportDataSource("PackageHistoryList", recordsList);
            lr.DataSources.Add(res);


            renderedBytes = lr.Render(
            format,
            string.Empty,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings
            );

            return File(renderedBytes, mimeType);
        }

    }
}