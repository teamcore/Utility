$(document).ready(function () {

    var dataSource = prepareDataSource(window.apiUrl);

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
                title: "Term"
            },
            {
                field: "Description",
                title: "Description"
            },
            {
                title: "Action",
                command: [{ text: "edit", click: grid.edit }, { text: " Delete", imageClass: "glyphicon glyphicon-trash", click: grid.del }],
                width: "220px"
            }
        ]
    });
});