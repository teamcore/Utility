$(document).ready(function () {

    var dataSource = prepareDataSource(window.apiUrl);

    $("#grid").kendoGrid({
        dataSource: dataSource,
        height: 380,
        pageable: true,
        filterable: true,
        sortable:true,
        columns: [
            {
                field: "Id",
                title: "Project ID",
                width: "100px",
                filterable: false
            },
            {
                field: "Name",
                title: "Project Name",
                filterable: true
            },
            {
                field: "Code",
                title: "Project Code",
                    filterable: false
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

});