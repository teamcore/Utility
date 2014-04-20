$(document).ready(function () {

    //var dataSource = prepareDataSource(window.feedUrl);

    //$("#grid").kendoGrid({
    //    dataSource: dataSource,
    //    height: 430,
    //    filterable: false,
    //    sortable: false,
    //    pageable: true,
    //    columns: [
    //        {
    //            field: "Id",
    //            title: "User Group ID",
    //            width: "140px"
    //        },
    //        {
    //            field: "Name",
    //            title: "User Group Name"
    //        },
    //        {
    //            field: "Description",
    //            title: "Description"
    //        },
    //        {
    //            command: { text: "View", click: window.viewModel.View },
    //            title: "View", width: "140px"
    //        },
    //        {
    //            command: { text: "Delete", click: window.viewModel.Remove },
    //            title: "Delete", width: "140px", hidden: !window.viewModel.DeleteRights()
    //        }
    //    ]
    //});

    //var grid = $("#grid").data("kendoGrid");
    //var checkbox;
    //$('#grid').on("change", ".checkbox-all", function () {
    //    checkbox = $(this);
    //    grid.table.find("tr").find("td:first input").prop("checked", checkbox.is(":checked"));
    //});

    //$('#grid').on("change", ".k-checkbox", function () {
    //    checkbox.prop("checked", false);
    //});

    //$("#publish").click(function() {
    //    window.viewModel.SelectedList.removeAll();
    //    grid.table.find("tr").each(function() {
    //        var chkbox = $(this).find("td:first input");
    //        if (chkbox.is(":checked")) {
    //            window.viewModel.SelectedList.push(parseInt(chkbox.val()));
    //        }
    //    });

    //    alert(ko.toJSON(window.viewModel.SelectedList));
    //});
});