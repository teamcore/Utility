$(document).ready(function () {

    var dataSource = prepareDataSource(window.feedUrl);

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
                template: "<a href='AddEdit/#=Id#'>Edit</a>",
                width: "80px"
            },
            {
                command: { text: "Delete", click: grid.deleteRow },
                title: "Delete",
                width: "120px"
            }
        ]
    });
    
});