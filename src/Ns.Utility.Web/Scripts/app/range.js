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
                field: "Id",
                title: "ID",
                width: "140px",
                filterable: false
            },
            {
                field: "Name",
                title: "Range Name"
            },
            {
                field: "ProjectName",
                title: "Project Name"
            },
            {
                field: "Min",
                title: "Minimum Range",
                filterable: false
            },
            {
                field: "Max",
                title: "Maximun Ranage",
                filterable: false
            },
            {
                field: "Next",
                title: "Next ID",
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