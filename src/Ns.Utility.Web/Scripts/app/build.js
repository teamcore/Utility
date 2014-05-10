$(document).ready(function () {

    $("#addpackage").click(function () {
        $("#package-section input:last").after("<input type=\"file\" name=\"packages\" class=\"form-control\" />");
    });
    $("#removepackage").click(function () {
        if ($("#package-section > input").length > 1) {
            $("#package-section input:last").remove();
        }

    });

    $("#addscript").click(function () {
        $("#script-section input:last").after("<input type=\"file\" name=\"scripts\" class=\"form-control\" />");
    });
    $("#removescript").click(function () {
        if ($("#script-section > input").length > 1) {
            $("#script-section input:last").remove();
        }

    });

    $("#submit").click(function () {
        var validPackage = validate("#package-section", "exe", "Select valid package file.");
        var validScript = validate("#script-section", "sql", "Select valid script file.");
        return validPackage && validScript;
    });
});

function validate(selector, extn, message)
{
    var allValidUplaod = true;
    $(selector + " > input").each(function (index) {
        var validUpload = false;
        var fullFileName = $(this).val();
        var fileName = file.getFileName(fullFileName);
        if (fileName != null) {
            var extension = fileName.substr((fileName.lastIndexOf('.') + 1));
            switch (extension) {
                case extn:
                    validUpload = true;
                    $(this).removeClass("input-validation-error");
                    break;
                default:
                    validUpload = false;
                    $(selector + " > span").text(message).removeClass("field-validation-valid").addClass("field-validation-error");
                    $(this).addClass("input-validation-error");
            }
        }
        else {
            $(selector + " > span").text("Select package file.").removeClass("field-validation-valid").addClass("field-validation-error");
            $(this).addClass("input-validation-error");
        }

        allValidUplaod = allValidUplaod && validUpload;
    })

    if (allValidUplaod)
    {
        $(selector + " > span").removeClass("field-validation-error").addClass("field-validation-valid");
    }

    return allValidUplaod;
}

var file = {};

file.getFileName = function (filePath) {
    var reg = new RegExp(/([^\/\\]+)$/);
    var fileName = reg.exec(filePath);

    if (fileName == null) {
        return null;
    }
    else {
        return fileName[0];
    }
}