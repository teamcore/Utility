
executeOnServer = function (model, url, type, onsucess, onerror) {
    if (type === 'DELETE')
    {
        url += "/" + model;
    }

    $.ajax({
        url: url,
        type: type,
        data: (type === 'GET' || type === 'DELETE') ? {} : JSON.stringify(model),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (onsucess) {
                onsucess(data);
            }
        },
        error: function (error) {
            if (onerror) {
                onerror();
            } else {

                alert("There was an error posting the data to the server: " + error.responseText);
            }

        }
    });
};

prepareDataSource = function (url) {

    var dataSource = {
        type: "json",
        transport: {
            read: {
                url: url,
                contentType: "application/json"
            },
            parameterMap: function (data, operation) {
                return JSON.stringify(data);
            }
        },
        schema: {
            data: "Data",
            total: "Total",
            errors: "error"
        },
        error: function (e) {
            var message = "Http Status Code: " + e.xhr.status + "\nError Message: " + e.xhr.responseText;
            alert(message);
        },
        pageSize: 15,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true
    };

    return dataSource;
};

prepareDataSource = function (url, id) {

    var dataSource = {
        type: "json",
        transport: {
            read: {
                url: url,
                data: { id: id },
                contentType: "application/json"
            },
            parameterMap: function (data, operation) {
                return JSON.stringify(data);
            }
        },
        schema: {
            data: "Data",
            total: "Total",
            errors: "error"
        },
        error: function (e) {
            var message = "Http Status Code: " + e.xhr.status + "\nError Message: " + e.xhr.responseText;
            //Notify("error", e.xhr.statusText, message);
            alert(message);
        },
        pageSize: 15,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true
    };

    return dataSource;
};