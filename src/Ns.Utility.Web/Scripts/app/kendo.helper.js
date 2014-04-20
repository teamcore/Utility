var grid = this;

grid.deleteRow = function (e) {
    e.preventDefault();
    var sure = confirm("Are you sure to delete this record?\n\nClick [OK] to delete or [Cancel] to cancel the action.");
    if (sure) {
        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        executeOnServer(dataItem.Id, window.feedUrl, 'DELETE', function () {
            location.reload();
        });
    }
};

grid.deleteRows = function (ids) {
    executeOnServer(ids, window.feedUrl, 'DELETE', function () {
        location.reload();
    });
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
