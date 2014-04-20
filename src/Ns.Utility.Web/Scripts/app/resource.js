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
                title: "Action",
                template: "<a href='AddEdit/#=Id#'>Edit</a>"
            },
            {
                command: { text: "Delete", click: DeleteRecord },
                title: "Delete"
            }
        ]
    });

    var grid = $("#grid").data("kendoGrid");
    var checkbox;
    $('#grid').on("change", ".checkbox-all", function () {
        checkbox = $(this);
        grid.table.find("tr").find("td:first input").prop("checked", checkbox.is(":checked"));
    });

    $('#grid').on("change", ".k-checkbox", function () {
        checkbox.prop("checked", false);
    });
});