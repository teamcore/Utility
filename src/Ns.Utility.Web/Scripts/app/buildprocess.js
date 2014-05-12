//var ws;
$(document).ready(function () {

    //var uri = apiUrl.replace('http://', 'ws://') + '/' + $("#BuildName").val();
    //ws = new WebSocket(uri);

    //ws.onopen = function () {
    //    $('#messages').prepend('<div>Connected.</div>');

    //    $('#process-form').submit(function (event) {
    //        websocket.send($('#inputbox').val());
    //        $('#inputbox').val('');
    //        event.preventDefault();
    //    });
    //};

    //ws.onerror = function (event) {
    //    $('#messages').text('ERROR');
    //};

    //ws.onmessage = function (event) {
    //    $('#messages').prepend('<div>' + event.data + '</div>');
    //};

    $(function () {
        var ticker = $.connection.Progress;

        function init() {
            ticker.server.initialize();
        }

        // Add a client-side hub method that the server will call
        ticker.client.show = function (message) {
            $("#messages").prepend('<li>' + htmlEncode(message) + '</li>').slideDown("slow");
        }

        // Start the connection
        $.connection.hub.start().done(init);

    });

    function htmlEncode(value) {
        var encodedValue = $('<div />').text(value).html();
        return encodedValue;
    }

    $("#submit").click(function () {
        var id = $("#Id").val();
        var name = $("#BuildName").val();
        executeOnServer({ Id: id, Name: name }, apiUrl, 'POST', null, null);
        return false;
    });
});