$(document).ready(function () {

    var grid = $("#grid").data("kendoGrid");
    var checkbox;
    $('#grid').on("change", ".checkbox-all", function () {
        checkbox = $(this);
        grid.table.find("tr").find("td:first input").prop("checked", checkbox.is(":checked"));
    });

    $('#grid').on("change", ".k-checkbox", function () {
        if (checkbox) {
            checkbox.prop("checked", false);
        }
    });
});

function DeleteRecord(e) {

    e.preventDefault();
    var sure = confirm("Are you sure to delete this record?\n\n\nClick [OK] to delete or [Cancel] to cancel the action.");
    if (sure) {
        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        executeOnServer(dataItem.Id, window.feedUrl, 'DELETE', function () {
            location.reload();
        });
    }
}