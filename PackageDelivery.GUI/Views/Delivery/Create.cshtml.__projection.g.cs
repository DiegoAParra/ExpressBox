//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Create_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Create_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
  
    ViewBag.Title = "Create";


#line default
#line hidden

#line 3 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
using (Html.BeginForm()) 
{
    

#line default
#line hidden

#line 4 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
__o = Html.AntiForgeryToken();


#line default
#line hidden

#line 5 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
                            
    
    

#line default
#line hidden

#line 6 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
   __o = Html.ValidationSummary(true, "", new { @class = "text-danger" });


#line default
#line hidden

#line 7 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.LabelFor(model => model.DeliveryDate, htmlAttributes: new { @class = "control-label col-md-2" });


#line default
#line hidden

#line 8 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
           __o = Html.EditorFor(model => model.DeliveryDate, new { htmlAttributes = new { @class = "form-control" } });


#line default
#line hidden

#line 9 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
           __o = Html.ValidationMessageFor(model => model.DeliveryDate, "", new { @class = "text-danger" });


#line default
#line hidden

#line 10 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.LabelFor(model => model.Price, htmlAttributes: new { @class = "control-label col-md-2" });


#line default
#line hidden

#line 11 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
           __o = Html.EditorFor(model => model.Price, new { htmlAttributes = new { @class = "form-control" } });


#line default
#line hidden

#line 12 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
           __o = Html.ValidationMessageFor(model => model.Price, "", new { @class = "text-danger" });


#line default
#line hidden

#line 13 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.LabelFor(model => model.Id_DestinationAddress);


#line default
#line hidden

#line 14 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.DropDownListFor(model => model.Id_DestinationAddress, new SelectList(Model.DestinationAddressList, "Id", "Neighborhood"), new { @class = "form-control chosen-select-single", @id = "selDestinationAddress", data_placeholder = "-- Seleccione el Direccion --" });


#line default
#line hidden

#line 15 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.ValidationMessageFor(model => model.Id_DestinationAddress, "", new { @class = "text-danger" });


#line default
#line hidden

#line 16 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.LabelFor(model => model.Id_Package);


#line default
#line hidden

#line 17 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.DropDownListFor(model => model.Id_Package, new SelectList(Model.PackageList, "Id", "Id"), new { @class = "form-control chosen-select-single", @id = "selPackage", data_placeholder = "-- Seleccione el Paquete --" });


#line default
#line hidden

#line 18 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.ValidationMessageFor(model => model.Id_Package, "", new { @class = "text-danger" });


#line default
#line hidden

#line 19 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.LabelFor(model => model.Id_DeliveryStatus);


#line default
#line hidden

#line 20 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.DropDownListFor(model => model.Id_DeliveryStatus, new SelectList(Model.DeliveryStatusList, "Id", "Name"), new { @class = "form-control chosen-select-single", @id = "selDeliveryStatus", data_placeholder = "-- Seleccione el Estado del Envio --" });


#line default
#line hidden

#line 21 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.ValidationMessageFor(model => model.Id_DeliveryStatus, "", new { @class = "text-danger" });


#line default
#line hidden

#line 22 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.LabelFor(model => model.Id_Sender);


#line default
#line hidden

#line 23 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.DropDownListFor(model => model.Id_Sender, new SelectList(Model.SenderList, "Id", "FirstName"), new { @class = "form-control chosen-select-single", @id = "selSender", data_placeholder = "-- Seleccione el remitente --" });


#line default
#line hidden

#line 24 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.ValidationMessageFor(model => model.Id_Sender, "", new { @class = "text-danger" });


#line default
#line hidden

#line 25 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.LabelFor(model => model.Id_TransportType);


#line default
#line hidden

#line 26 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.DropDownListFor(model => model.Id_TransportType, new SelectList(Model.TransportTypeList, "Id", "Name"), new { @class = "form-control chosen-select-single", @id = "selTransportType", data_placeholder = "-- Seleccione el departamento --" });


#line default
#line hidden

#line 27 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
       __o = Html.ValidationMessageFor(model => model.Id_TransportType, "", new { @class = "text-danger" });


#line default
#line hidden

#line 28 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
          
}

#line default
#line hidden

#line 29 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
__o = Html.ActionLink("Back to List", "Index");


#line default
#line hidden
DefineSection("Scripts", () => {


#line 30 "C:\Users\Yenny Maria\AppData\Local\Temp\59A006B368AE3A1EC31DE8E79C6279D7C481\3\PackageDeliverySystem\PackageDelivery.GUI\Views\Delivery\Create.cshtml"
__o = Scripts.Render("~/bundles/jqueryval");


#line default
#line hidden
});

}
}
}