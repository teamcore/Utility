jQuery.formPost = function (url, data, inputName) {
    if (url && data) {
        var inputs = '';
        jQuery.each(data, function (index, value) {
            inputs += '<input type="hidden" name="' + inputName  + '[' + index + ']" value="' + value + '" />';
        });
        jQuery('<form action="' + url + '" method="post">' + inputs + '</form>')
		.appendTo('body').submit().remove();
    };
};