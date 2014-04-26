$(document).ready(function () {
    
    var dataSource = prepareDataSource(window.apiUrl);

    $("#grid").kendoGrid({
        dataSource: dataSource,
        height: actualViewPort,
        filterable: true,
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
                width: "140px",
                filterable: false
            },
            {
                field: "Key",
                title: "Resource ID"
            },
            {
                field: "Text",
                title: "Resource Text"
            },
            {
                field: "DisplayText",
                title: "Display Text",
                filterable: false
            },
            {
                field: "ProjectName",
                title: "Project Name"
            },
            {
                field: "Description",
                title: "Description",
                filterable: false
            },
            {
                title: "Action",
                command: [{ text: "edit", click: grid.edit }, { text: " Delete", imageClass: "glyphicon glyphicon-trash", click: grid.del }],
                width: "220px"
            }
        ]
    });

    $("#export").click(function () {
        var kGrid = $("#grid").data("kendoGrid");
        IDs = grid.select(kGrid);
        if (IDs.length == 0) {
            toastr.error('No row(s) selected to export.')
            return;
        }

        $.formPost('/Resource/Export', IDs, 'ids');
    });

    $("#preview").click(function () {
        var kGrid = $("#grid").data("kendoGrid");
        IDs = grid.select(kGrid);
        if (IDs.length == 0) {
            toastr.error('No row(s) selected to preview.')
            return;
        }

        $.formPost('/Resource/Preview', IDs, 'ids');
    });

    $("#confirm").click(function () {
        $('#delete-confirm').modal('hide')
        grid.deleteRows(IDs, function () {
            toastr.success(IDs.length + ' row(s) deleted.')
        });

    });
});