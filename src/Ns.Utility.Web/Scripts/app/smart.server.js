
executeOnServer = function (model, url, type, onsucess, onerror) {

    $.ajax({
        beforeSend: function (xhr) {
            var authtoken = $.cookie('Authorization-Token');
            xhr.setRequestHeader("Authorization-Token", authtoken);
        },
        url: url,
        type: type,
        data: (type === 'GET' || type === 'DELETE') ? {} : ko.mapping.toJSON(model),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            ko.mapping.fromJS(data, model);
            if (onsucess) {
                onsucess();
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
                beforeSend: function (xhr) {
                    var authtoken = $.cookie('Authorization-Token');
                    xhr.setRequestHeader("Authorization-Token", authtoken);
                }
            }
        },
        schema: {
            data: "Data",
            total: "Count",
            errors: "error"
        },
        error: function (e) {
            var message = "Http Status Code: " + e.xhr.status + "\nError Message: " + e.xhr.responseText;
            //Notify("error", e.xhr.statusText, message);
            alert(message);
        },
        pageSize: 10,
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
                beforeSend: function (xhr) {
                    var authtoken = $.cookie('Authorization-Token');
                    xhr.setRequestHeader("Authorization-Token", authtoken);
                }
            }
        },
        schema: {
            data: "Data",
            total: "Count",
            errors: "error"
        },
        error: function (e) {
            var message = "Http Status Code: " + e.xhr.status + "\nError Message: " + e.xhr.responseText;
            //Notify("error", e.xhr.statusText, message);
            alert(message);
        },
        pageSize: 10,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true
    };

    return dataSource;
};