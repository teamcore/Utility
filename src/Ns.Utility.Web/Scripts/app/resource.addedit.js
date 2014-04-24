$(document).ready(function () {
    $("#apply-term").click(function () {
        var text = $("#Text").val();
        var textArr = text.split(" ");
        var url = window.apiUrl + '/replace';
        executeOnServer(textArr, url, "POST", function (data) {
            $("#Text").val(data);
        });

        return false;
    });
});