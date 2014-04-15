﻿$(document).ready(function () {

    var dataSource = prepareDataSource(window.feedUrl);

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
                field: "Description",
                title: "Description"
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