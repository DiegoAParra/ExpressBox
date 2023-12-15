using Microsoft.Reporting.WebForms;
using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class DeliveryController : Controller
    {
        private IDeliveryApplication _app;
        private IAddressApplication _dtapp;
        private IPackageApplication _dt2app;
        private IDeliveryStatusApplication _dt3app;
        private IPersonApplication _dt4app;
        private ITransportTypeApplication _dt5app;

        public DeliveryController(IDeliveryApplication app, IAddressApplication dtapp, IPackageApplication dt2app,
            IDeliveryStatusApplication dt3app, IPersonApplication dt4app, ITransportTypeApplication dt5app)
        {
            this._app = app;
            this._dtapp = dtapp;
            this._dt2app = dt2app;
            this._dt3app = dt3app;
            this._dt4app = dt4app;
            this._dt5app = dt5app;
        }

        // GET: Delivery
        public ActionResult Index(string filter = "")
        {
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            IEnumerable<DeliveryModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));

            AddressGUIMapper amapper = new AddressGUIMapper();
            IEnumerable<AddressModel> lista = amapper.DTOToModelMapper(_dtapp.getRecordList(filter));

            DeliveryStatusGUIMapper dsmapper = new DeliveryStatusGUIMapper();
            IEnumerable<DeliveryStatusModel> listds = dsmapper.DTOToModelMapper(_dt3app.getRecordList(filter));

            PersonGUIMapper pmapper = new PersonGUIMapper();
            IEnumerable<PersonModel> listp = pmapper.DTOToModelMapper(_dt4app.getRecordList(filter));

            TransportTypeGUIMapper tmapper = new TransportTypeGUIMapper();
            IEnumerable<TransportTypeModel> listt = tmapper.DTOToModelMapper(_dt5app.getRecordList(filter));

            foreach (var item in list)
            {
                foreach (var itema in lista)
                {
                    if (item.Id_DestinationAddress == itema.Id)
                    {
                        item.DestinationAddressName = itema.StreetType + "  #" + itema.Number + " " + itema.Neighborhood;
                    }
                }
                foreach (var items in listds)
                {
                    if (item.Id_DeliveryStatus == items.Id)
                    {
                        item.DeliveryStatusName = items.Name;
                    }
                }
                foreach (var itemp in listp)
                {
                    if (item.Id_Sender == itemp.Id)
                    {
                        item.SenderName = itemp.FirstName + " " + itemp.FirstLastName;
                    }
                }
                foreach (var itemt in listt)
                {
                    if (item.Id_TransportType == itemt.Id)
                    {
                        item.TransportTypeName = itemt.Name;
                    }
                }
            }
            return View(list);
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            DeliveryModel DeliveryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DeliveryModel == null)
            {
                return HttpNotFound();
            }
            AddressGUIMapper amapper = new AddressGUIMapper();
            AddressModel AddressModel = amapper.DTOToModelMapper(_dtapp.getRecordById(((int)DeliveryModel.Id_DestinationAddress)));
            DeliveryModel.DestinationAddressName = AddressModel.StreetType + "  #" + AddressModel.Number + " " + AddressModel.Neighborhood;
            
            DeliveryStatusGUIMapper dmapper = new DeliveryStatusGUIMapper();
            DeliveryStatusModel DeliveryStatusModel = dmapper.DTOToModelMapper(_dt3app.getRecordById(((int)DeliveryModel.Id_DeliveryStatus)));
            DeliveryModel.DeliveryStatusName = DeliveryStatusModel.Name;

            PersonGUIMapper pmapper = new PersonGUIMapper();
            PersonModel PersonModel = pmapper.DTOToModelMapper(_dt4app.getRecordById(((int)DeliveryModel.Id_Sender)));
            DeliveryModel.SenderName = PersonModel.FirstName + " " + PersonModel.FirstLastName;

            TransportTypeGUIMapper tmapper = new TransportTypeGUIMapper();
            TransportTypeModel TransportTypeModel = tmapper.DTOToModelMapper(_dt5app.getRecordById(((int)DeliveryModel.Id_TransportType)));
            DeliveryModel.TransportTypeName = TransportTypeModel.Name;
            return View(DeliveryModel);
        }

        // GET: Delivery/Create
        public ActionResult Create()
        {
            IEnumerable<AddressDTO> dtList = this._dtapp.getRecordList(string.Empty);
            IEnumerable<PackageDTO> dt2List = this._dt2app.getRecordList(string.Empty);
            IEnumerable<DeliveryStatusDTO> dt3List = this._dt3app.getRecordList(string.Empty);
            IEnumerable<PersonDTO> dt4List = this._dt4app.getRecordList(string.Empty);
            IEnumerable<TransportTypeDTO> dt5List = this._dt5app.getRecordList(string.Empty);
            AddressGUIMapper dtMapper = new AddressGUIMapper();
            PackageGUIMapper dt2Mapper = new PackageGUIMapper();
            DeliveryStatusGUIMapper dt3Mapper = new DeliveryStatusGUIMapper();
            PersonGUIMapper dt4Mapper = new PersonGUIMapper();
            TransportTypeGUIMapper dt5Mapper = new TransportTypeGUIMapper();
            DeliveryModel model = new DeliveryModel()
            {
                DestinationAddressList = dtMapper.DTOToModelMapper(dtList),
                PackageList = dt2Mapper.DTOToModelMapper(dt2List),
                DeliveryStatusList = dt3Mapper.DTOToModelMapper(dt3List),
                SenderList = dt4Mapper.DTOToModelMapper(dt4List),
                TransportTypeList = dt5Mapper.DTOToModelMapper(dt5List),
            };
            return View(model);
        }

        // POST: Delivery/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeliveryDate,Price,Id_DestinationAddress," +
            "Id_Package,Id_DeliveryStatus,Id_Sender,Id_TransportType")] DeliveryModel DeliveryModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryGUIMapper mapper = new DeliveryGUIMapper();
                DeliveryDTO response = _app.createRecord(mapper.ModelToDTOMapper(DeliveryModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(DeliveryModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(DeliveryModel);
        }

        // GET: Delivery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            DeliveryModel DeliveryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));

            IEnumerable<AddressDTO> dtList = this._dtapp.getRecordList(string.Empty);
            IEnumerable<PackageDTO> dt2List = this._dt2app.getRecordList(string.Empty);
            IEnumerable<DeliveryStatusDTO> dt3List = this._dt3app.getRecordList(string.Empty);
            IEnumerable<PersonDTO> dt4List = this._dt4app.getRecordList(string.Empty);
            IEnumerable<TransportTypeDTO> dt5List = this._dt5app.getRecordList(string.Empty);
            AddressGUIMapper dtMapper = new AddressGUIMapper();
            PackageGUIMapper dt2Mapper = new PackageGUIMapper();
            DeliveryStatusGUIMapper dt3Mapper = new DeliveryStatusGUIMapper();
            PersonGUIMapper dt4Mapper = new PersonGUIMapper();
            TransportTypeGUIMapper dt5Mapper = new TransportTypeGUIMapper();

            DeliveryModel.DestinationAddressList = dtMapper.DTOToModelMapper(dtList);
            DeliveryModel.PackageList = dt2Mapper.DTOToModelMapper(dt2List);
            DeliveryModel.DeliveryStatusList = dt3Mapper.DTOToModelMapper(dt3List);
            DeliveryModel.SenderList = dt4Mapper.DTOToModelMapper(dt4List);
            DeliveryModel.TransportTypeList = dt5Mapper.DTOToModelMapper(dt5List);
            if (DeliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(DeliveryModel);
        }

        // POST: Delivery/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeliveryDate,Price,Id_DestinationAddress," +
            "Id_Package,Id_DeliveryStatus,Id_Sender,Id_TransportType")] DeliveryModel DeliveryModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryGUIMapper mapper = new DeliveryGUIMapper();
                DeliveryDTO response = _app.updateRecord(mapper.ModelToDTOMapper(DeliveryModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(DeliveryModel);
        }

        // GET: Delivery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            DeliveryModel DeliveryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DeliveryModel == null)
            {
                return HttpNotFound();
            }
            AddressGUIMapper amapper = new AddressGUIMapper();
            AddressModel AddressModel = amapper.DTOToModelMapper(_dtapp.getRecordById(((int)DeliveryModel.Id_DestinationAddress)));
            DeliveryModel.DestinationAddressName = AddressModel.StreetType + "  #" + AddressModel.Number + " " + AddressModel.Neighborhood;

            DeliveryStatusGUIMapper dmapper = new DeliveryStatusGUIMapper();
            DeliveryStatusModel DeliveryStatusModel = dmapper.DTOToModelMapper(_dt3app.getRecordById(((int)DeliveryModel.Id_DeliveryStatus)));
            DeliveryModel.DeliveryStatusName = DeliveryStatusModel.Name;

            PersonGUIMapper pmapper = new PersonGUIMapper();
            PersonModel PersonModel = pmapper.DTOToModelMapper(_dt4app.getRecordById(((int)DeliveryModel.Id_Sender)));
            DeliveryModel.SenderName = PersonModel.FirstName + " " + PersonModel.FirstLastName;

            TransportTypeGUIMapper tmapper = new TransportTypeGUIMapper();
            TransportTypeModel TransportTypeModel = tmapper.DTOToModelMapper(_dt5app.getRecordById(((int)DeliveryModel.Id_TransportType)));
            DeliveryModel.TransportTypeName = TransportTypeModel.Name;
            return View(DeliveryModel);
        }

        // POST: Delivery/Delete/5
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

        public ActionResult Delivery_Report(string format = "PDF")
        {
            var list = _app.getRecordList(string.Empty);
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            List<DeliveryModel> recordsList = mapper.DTOToModelMapper(list).ToList();

            AddressGUIMapper amapper = new AddressGUIMapper();
            IEnumerable<AddressModel> lista = amapper.DTOToModelMapper(_dtapp.getRecordList(""));

            DeliveryStatusGUIMapper dsmapper = new DeliveryStatusGUIMapper();
            IEnumerable<DeliveryStatusModel> listds = dsmapper.DTOToModelMapper(_dt3app.getRecordList(""));

            PersonGUIMapper pmapper = new PersonGUIMapper();
            IEnumerable<PersonModel> listp = pmapper.DTOToModelMapper(_dt4app.getRecordList(""));

            TransportTypeGUIMapper tmapper = new TransportTypeGUIMapper();
            IEnumerable<TransportTypeModel> listt = tmapper.DTOToModelMapper(_dt5app.getRecordList(""));

            foreach (var item in recordsList)
            {
                item.PackageName = item.Id_Package.ToString();
                foreach (var itema in lista)
                {
                    if (item.Id_DestinationAddress == itema.Id)
                    {
                        item.DestinationAddressName = itema.StreetType + "  #" + itema.Number + " " + itema.Neighborhood;
                    }
                }
                foreach (var items in listds)
                {
                    if (item.Id_DeliveryStatus == items.Id)
                    {
                        item.DeliveryStatusName = items.Name;
                    }
                }
                foreach (var itemp in listp)
                {
                    if (item.Id_Sender == itemp.Id)
                    {
                        item.SenderName = itemp.FirstName + " " + itemp.FirstLastName;
                    }
                }
                foreach (var itemt in listt)
                {
                    if (item.Id_TransportType == itemt.Id)
                    {
                        item.TransportTypeName = itemt.Name;
                    }
                }
            }

            string reportPath = Server.MapPath("~/Reports/rdlcFiles/DeliveriesReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource res = new ReportDataSource("DeliveryList", recordsList);
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