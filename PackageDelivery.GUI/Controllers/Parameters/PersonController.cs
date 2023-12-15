using Microsoft.Reporting.WebForms;
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class PersonController : Controller
    {
        private IPersonApplication _app;
        private IDocumentTypeApplication _dtapp;

        public PersonController(IPersonApplication app, IDocumentTypeApplication dtapp)
        {
            this._app = app;
            this._dtapp = dtapp;
        }

        // GET: Person
        public ActionResult Index(string filter = "")
        {
            PersonGUIMapper mapper = new PersonGUIMapper();
            IEnumerable<PersonModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));

            DocumentTypeGUIMapper dtmapper = new DocumentTypeGUIMapper();
            IEnumerable<DocumentTypeModel> listdt = dtmapper.DTOToModelMapper(_dtapp.getRecordList(filter));

            foreach (var item in list)
            {
                foreach (var itemdt in listdt)
                {
                    if (item.Id_DocumentType == itemdt.Id)
                    {
                        item.DocumentTypeName = itemdt.Name;
                    }
                }
            }
            return View(list);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel PersonModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (PersonModel == null)
            {
                return HttpNotFound();
            }
            DocumentTypeGUIMapper dtmapper = new DocumentTypeGUIMapper();
            DocumentTypeModel DocumentTypeModel = dtmapper.DTOToModelMapper(_dtapp.getRecordById((PersonModel.Id_DocumentType)));
            PersonModel.DocumentTypeName = DocumentTypeModel.Name;
            return View(PersonModel);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            IEnumerable<DocumentTypeDTO> dtList = this._dtapp.getRecordList(string.Empty);
            DocumentTypeGUIMapper dtMapper = new DocumentTypeGUIMapper();
            PersonModel model = new PersonModel()
            {
                DocumentTypeList = dtMapper.DTOToModelMapper(dtList)
            };
            return View(model);
        }

        // POST: Person/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastName," +
            "SecondLastName,IdentificationNumber,CellPhone,Email,Id_DocumentType")] PersonModel PersonModel)
        {
            if (ModelState.IsValid)
            {
                PersonGUIMapper mapper = new PersonGUIMapper();
                PersonDTO response = _app.createRecord(mapper.ModelToDTOMapper(PersonModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(PersonModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(PersonModel);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel personModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<DocumentTypeDTO> dtList = this._dtapp.getRecordList(string.Empty);
            DocumentTypeGUIMapper dtMapper = new DocumentTypeGUIMapper();
            personModel.DocumentTypeList = dtMapper.DTOToModelMapper(dtList);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: Person/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastName," +
            "SecondLastName,IdentificationNumber,CellPhone,Email,Id_DocumentType")] PersonModel PersonModel)
        {
            if (ModelState.IsValid)
            {
                PersonGUIMapper mapper = new PersonGUIMapper();
                PersonDTO response = _app.updateRecord(mapper.ModelToDTOMapper(PersonModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(PersonModel);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel PersonModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (PersonModel == null)
            {
                return HttpNotFound();
            }
            DocumentTypeGUIMapper dtmapper = new DocumentTypeGUIMapper();
            DocumentTypeModel DocumentTypeModel = dtmapper.DTOToModelMapper(_dtapp.getRecordById((PersonModel.Id_DocumentType)));
            PersonModel.DocumentTypeName = DocumentTypeModel.Name;
            return View(PersonModel);
        }

        // POST: Person/Delete/5
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
        public ActionResult Person_Report(string format = "PDF")
        {
            var list = _app.getRecordList(string.Empty);
            PersonGUIMapper mapper = new PersonGUIMapper();
            List<PersonModel> recordsList = mapper.DTOToModelMapper(list).ToList();

            DocumentTypeGUIMapper dtmapper = new DocumentTypeGUIMapper();
            IEnumerable<DocumentTypeModel> listdt = dtmapper.DTOToModelMapper(_dtapp.getRecordList(""));

            foreach (var item in recordsList)
            {
                foreach (var itemdt in listdt)
                {
                    if (item.Id_DocumentType == itemdt.Id)
                    {
                        item.DocumentTypeName = itemdt.Name;
                    }
                }
            }

            string reportPath = Server.MapPath("~/Reports/rdlcFiles/PeopleReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource res = new ReportDataSource("PeopleList", recordsList);
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