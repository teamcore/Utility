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
                field: "Id",
                title: "ID",
                width: "140px"
            },
            {
                field: "Name",
                title: "Range Name"
            },
            {
                field: "Min",
                title: "Minimum Range"
            },
            {
                field: "Max",
                title: "Maximun Ranage"
            },
            {
                field: "Next",
                title: "Next ID"
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