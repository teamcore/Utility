$(document).ready(function () {

    var dataSource = prepareDataSource(window.apiUrl);

    $("#grid").kendoGrid({
        dataSource: dataSource,
        height: 380,
        pageable: true,
        columns: [
            {
                field: "Id",
                title: "Project ID",
                width: "80px"
            },
            {
                field: "Name",
                title: "Project Name"
            },
            {
                field: "Code",
                title: "Project Code",
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