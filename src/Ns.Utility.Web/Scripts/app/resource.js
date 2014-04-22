$(document).ready(function () {

    var dataSource = prepareDataSource(window.feedUrl);

    $("#grid").kendoGrid({
        dataSource: dataSource,
        height: 380,
        filterable: false,
        sortable: true,
        pageable: true,
        columns: [
            {
                headerTemplate: "<input type=\"checkbox\" class=\"checkbox-all\"/>",
                template: "<input type=\"checkbox\" class=\"k-checkbox\" value=\"#=Id#\"/>",
                width: "40px"
            },
            {
                field: "Id",
                title: "ID",
                width: "140px"
            },
            {
                field: "Key",
                title: "Resource ID"
            },
            {
                field: "Text",
                title: "Text"
            },
            {
                field: "Description",
                title: "Description"
            },
            {
                title: "Edit",
                template: "<a href='AddEdit/#=Id#'>Edit</a>",
                width: "70px"
            },
            {
                command: { text: "Delete", click: grid.deleteRow },
                title: "Delete",
                width: "120px"
            }
        ]
    });

    $("#export").click(function () {
        var kGrid = $("#grid").data("kendoGrid");
        IDs = grid.select(kGrid);
        if (IDs.length == 0) {
            toastr.error('No row(s) checked to export.')
        }
    });

    $("#preview").click(function () {
        var kGrid = $("#grid").data("kendoGrid");
        IDs = grid.select(kGrid);
        if (IDs.length == 0) {
            toastr.error('No row(s) checked to preview.')
            return;
        }

        executeOnServer(IDs, window.feedUrl + '/script', 'POST', function (data) {
            var formattedScript = data.replace(/\\n/g, "<br />");
            $("#code-line").html(formattedScript);
            $("#grid").addClass('hidden');
            $("#grid-buttons").addClass('hidden');
            $("#preview-buttons").removeClass('hidden');
            $("#code-container").removeClass('hidden');
        });
    });

    $("#back").click(function () {
        $("#grid").removeClass('hidden');
        $("#grid-buttons").removeClass('hidden');
        $("#preview-buttons").addClass('hidden');
        $("#code-container").addClass('hidden');
    });

    $("#confirm").click(function () {
        $('#delete-confirm').modal('hide')
        grid.deleteRows(IDs, function () {
            toastr.success(IDs.length + ' row(s) deleted.')
        });

    });
});