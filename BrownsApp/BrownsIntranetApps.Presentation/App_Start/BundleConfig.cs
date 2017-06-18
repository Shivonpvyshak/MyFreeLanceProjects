using System.Web.Optimization;

namespace BrownsIntranetApps.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/Scripts/CommonScripts").Include(
                // App
                "~/Scripts/app/app.js",

                //Config
                "~/Scripts/app/config.js"

               ));

            bundles.Add(new ScriptBundle("~/Scripts/CustomerScripts").Include(
                 //"~/Scripts/app/controllers/customerController.js",
                // "~/Scripts/app/services/customerdataservice.js",
                "~/Scripts/app/services/stateDataService.js",
                "~/Scripts/app/services/notificationService.js"
                ));

            bundles.Add(new Bundle("~/scripts/application").Include(

                // App
                "~/Scripts/app/app.js",

                //Config
                "~/Scripts/app/config.js",

                // Services
                "~/Scripts/app/services/searchDataService.js",
                "~/Scripts/app/services/companyDataService.js",
                "~/Scripts/app/services/partDataService.js",
                "~/Scripts/app/services/searchEventService.js",
                "~/Scripts/app/services/notificationService.js",
                "~/Scripts/app/services/fileUploadService.js",
                "~/Scripts/app/services/logsDataService.js",
                "~/Scripts/app/services/stateDataService.js",
                "~/Scripts/app/services/laborDataService.js",
                "~/Scripts/app/services/invoiceStatusDataService.js",
                "~/Scripts/app/services/shippingMethodDataService.js",
                "~/Scripts/app/services/paymentStatusDataService.js",
                "~/Scripts/app/services/partsInvoiceDataService.js",
                "~/Scripts/app/services/serviceInvoiceDataService.js",
                "~/Scripts/app/services/billingHomeDataService.js",
                "~/Scripts/app/services/searchInvoiceDataService.js",
                "~/Scripts/app/services/countydataservice.js",

                // Controllers
                "~/Scripts/app/controllers/homeController.js",
                "~/Scripts/app/controllers/searchController.js",
                "~/Scripts/app/controllers/addPartController.js",
                "~/Scripts/app/controllers/fileUploadController.js",
                "~/Scripts/app/controllers/reportController.js",
                 "~/Scripts/app/controllers/partsHomeController.js",
                 "~/Scripts/app/controllers/logsController.js",
                 "~/Scripts/app/controllers/partsInvoiceController.js",
                 "~/Scripts/app/controllers/billingHomeController.js",
                 "~/Scripts/app/controllers/serviceInvoiceController.js",
                 "~/Scripts/app/controllers/searchInvoiceController.js"

            ));

            bundles.Add(new Bundle("~/scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"
            ));

            bundles.Add(new Bundle("~/scripts/angularbase").Include(
                "~/Scripts/angular/angular.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls-{version}.js",
                "~/Scripts/angular-ui/date.js",
                "~/Scripts/angular/angular-sanitize.js",
                "~/Scripts/angular/angular-growl.min.js"
            ));

            bundles.Add(new Bundle("~/scripts/tools").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/ui-select/select.min.js",
                "~/Scripts/modernizr-*",
                "~/Scripts/respond.js",
                "~/Scripts/notify.min.js",
                "~/Scripts/d3/d3.js",
                "~/Scripts/bootstrap-filestyle.min.js",
                "~/Scripts/moment.min.js",
                "~/Scripts/bootstrap-datetimepicker.js"

            ));
        }
    }
}