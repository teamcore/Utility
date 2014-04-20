$(document).ready(function () {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-bottom-right",
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    var IDs = [];
    var kGrid = $("#grid").data("kendoGrid");
    var checkbox;
    $('#grid').on("change", ".checkbox-all", function () {
        checkbox = $(this);
        kGrid.table.find("tr").find("td:first input").prop("checked", checkbox.is(":checked"));
    });

    $('#grid').on("change", ".k-checkbox", function () {
        if (checkbox) {
            checkbox.prop("checked", false);
        }
    });

    
    $("#delete").click(function () {
        var kGrid = $("#grid").data("kendoGrid");
        IDs = grid.select(kGrid);
        if (IDs.length == 0) {
            //alert("No row(s) checked to delete.");
            toastr.error('No row(s) checked to delete.')
            return;
        }

        $('#delete-confirm').modal()
    });
});
