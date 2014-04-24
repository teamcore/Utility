var grid = this;

grid.del = function (e) {
    e.preventDefault();
    var sure = confirm("Are you sure to delete this record?\n\nClick [OK] to delete or [Cancel] to cancel the action.");
    if (sure) {
        var row = $(e.currentTarget).closest("tr");
        var dataItem = this.dataItem(row);
        executeOnServer(dataItem.Id, window.apiUrl, 'DELETE', function () {
            $("#grid").data("kendoGrid").removeRow(row);
        });
    }
};

grid.edit = function (e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    location.href = actionUrl + "/" + dataItem.Id
};

grid.select = function (kGrid) {
    var IDs = [];
    kGrid.table.find("tr").each(function () {
        var chkbox = $(this).find("td:first input");
        if (chkbox.is(":checked")) {
            IDs.push(parseInt(chkbox.val()));
        }
    });

    return IDs;
};
