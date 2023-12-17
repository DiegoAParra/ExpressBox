using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.GUI.Models.Parameters;
using PackagePackageHistory.GUI.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers
{
    public class HomeController : Controller
    {
        private IWarehouseApplication _appWarehouse;
        private IPackageHistoryApplication _appPackageHistory;
        private IDeliveryApplication _appDelivery;
        private IAddressApplication _appAddress;
        private ICityApplication _appCity;
        private IDepartmentApplication _appDepartment;

        public HomeController(IWarehouseApplication appWarehouse, IPackageHistoryApplication appPackageHistory, IDeliveryApplication appDelivery, IAddressApplication appAddress, ICityApplication appCity, IDepartmentApplication appDepartment)
        {
            this._appWarehouse = appWarehouse;
            this._appPackageHistory = appPackageHistory;
            this._appDelivery = appDelivery;
            this._appAddress = appAddress;
            this._appCity = appCity;
            this._appDepartment = appDepartment;
        }

        public ActionResult Index(string filter = "")
        {
            PackageHistoryGUIMapper mapper = new PackageHistoryGUIMapper();
            IEnumerable<PackageHistoryModel> list = mapper.DTOToModelMapper(_appPackageHistory.getRecordList(filter));
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(int? id, string filter = "")
        {
            if (id == null)
            {
                // Si ocurre un error, establece un mensaje en TempData
                TempData["MensajeError"] = "Hubo un problema en la solicitud. Es posible que exista NO dicho paquete";

                // Devuelve una redirección a la vista donde se mostrará el mensaje
                return RedirectToAction("Index");
            }
            WarehouseGUIMapper mapperWarehouse = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> listWarehouse = mapperWarehouse.DTOToModelMapper(_appWarehouse.getRecordList(filter));

            PackageHistoryGUIMapper mapperPackageHistory = new PackageHistoryGUIMapper();
            IEnumerable<PackageHistoryModel> listPackageHistory = mapperPackageHistory.DTOToModelMapper(_appPackageHistory.getRecordList(filter));

            PackageHistoryModel PackageHistoryModel = null;
            foreach (var item in listPackageHistory)
            {
                if (item.Id_Package == id)
                {
                    PackageHistoryModel = item;
                    foreach (var itemw in listWarehouse)
                    {
                        if (PackageHistoryModel.Id_Warehouse == itemw.Id)
                        {
                            PackageHistoryModel.WarehouseName = itemw.Name;
                        }
                    }
                }
            }
            if (PackageHistoryModel == null)
            {
                // Si ocurre un error, establece un mensaje en TempData
                TempData["MensajeError"] = "Hubo un problema en la solicitud. Es posible que NO exista dicho paquete";

                // Devuelve una redirección a la vista donde se mostrará el mensaje
                return RedirectToAction("Index");
            }

            // Usar Tuple para combinar los modelos
            var modelosCombinados = Tuple.Create(listWarehouse, listPackageHistory, PackageHistoryModel);

            return View(modelosCombinados);
        }

        // GET: HomeController/Route
        public ActionResult Route()
        {
            WarehouseGUIMapper mapperWarehouse = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> listWarehouse = mapperWarehouse.DTOToModelMapper(_appWarehouse.getRecordList(""));

            IEnumerable<RouteModel> listRoute = new List<RouteModel>();

            // Usar Tuple para combinar los modelos
            var modelosCombinados = Tuple.Create(listWarehouse, listRoute);

            return View(modelosCombinados);
        }

        // POST: HomeController/generateRoute
        [HttpPost]
        public ActionResult Route(string IdWarehouse, DateTime selectedDate)
        {
            WarehouseGUIMapper mapperWarehouse = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> listWarehouse = mapperWarehouse.DTOToModelMapper(_appWarehouse.getRecordList(""));

            PackageHistoryGUIMapper mapperPackageHistory = new PackageHistoryGUIMapper();
            IEnumerable<PackageHistoryModel> listPackageHistory = mapperPackageHistory.DTOToModelMapper(_appPackageHistory.getRecordList(""));

            DeliveryGUIMapper mapperDelivery = new DeliveryGUIMapper();
            IEnumerable<DeliveryModel> listDelivery = mapperDelivery.DTOToModelMapper(_appDelivery.getRecordList(""));

            AddressGUIMapper mapperAddress = new AddressGUIMapper();
            IEnumerable<AddressModel> listAddress = mapperAddress.DTOToModelMapper(_appAddress.getRecordList(""));

            CityGUIMapper mapperCity = new CityGUIMapper();
            IEnumerable<CityModel> listCity = mapperCity.DTOToModelMapper(_appCity.getRecordList(""));

            DepartmentGUIMapper mapperDepartment = new DepartmentGUIMapper();
            IEnumerable<DepartmentModel> listDepartment = mapperDepartment.DTOToModelMapper(_appDepartment.getRecordList(""));

            IEnumerable<RouteModel> listRoute = new List<RouteModel>();

            foreach (var item in listPackageHistory)
            {
                if(item.Id_Warehouse == Convert.ToInt32(IdWarehouse))
                {
                    if(item.DepurateDate == selectedDate)
                    {
                        foreach (var itemd in listDelivery)
                        {
                            if (item.Id_Package == itemd.Id_Package)
                            {
                                foreach (var itema in listAddress)
                                {
                                    if (itemd.Id_DestinationAddress == itema.Id)
                                    {
                                        foreach (var itemc in listCity)
                                        {
                                            if (itema.Id_City == itemc.Id)
                                            {
                                                foreach (var itemad in listDepartment)
                                                {
                                                    if (itemc.Id_Department == itemad.Id)
                                                    {
                                                        RouteModel route = new RouteModel
                                                        {
                                                            Id_Package = item.Id_Package,
                                                            Description = item.Description,
                                                            DestinationAddress = itema.StreetType + " Nro " + itema.Number + " Barrio " + itema.Neighborhood + " " + itemc.Name + ", " + itemad.Name
                                                        };

                                                        List<RouteModel> listaModificable = listRoute.ToList();
                                                        listaModificable.Add(route);
                                                        listRoute = listaModificable;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Usar Tuple para combinar los modelos
            var modelosCombinados = Tuple.Create(listWarehouse, listRoute);

            // Luego, puedes redirigir a otra vista
            return View(modelosCombinados);
        }
    }
}