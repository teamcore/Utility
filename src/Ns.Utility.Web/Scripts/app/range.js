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
        
});