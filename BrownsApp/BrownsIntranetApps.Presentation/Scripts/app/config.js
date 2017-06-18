(function () {
    'use strict';

    var app = angular.module("theApp");

    var config = {
        endpoints: {
          //  partsAPI: "http://localhost:47268/API/Part/",
            //logsAPI: "http://localhost:47268/API/Logs/",
            //invoiceAPI: "http://localhost:47268/API/Invoice/",
            apiURL: "http://localhost:47268/API/"
        }
    };

    app.value("config", config);
})();