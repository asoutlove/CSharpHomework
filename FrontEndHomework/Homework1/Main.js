$(document).ready(function () {
    function checkRequiredField(jqObj) {
        if (!jqObj)
            return false;

        if (!jqObj.val())
            return false;

        return true;
    }


    $("#btn1").click(function () {
        var errorMsgArr = [];

        if (!checkRequiredField($("input[name=acount]"))) {
            errorMsgArr.push("Account is required.");
        }

        if (!checkRequiredField($("input[name=pwd]"))) {
            errorMsgArr.push("Password is required.");
        }

        if (!checkRequiredField($("input[name=repwd]"))) {
            errorMsgArr.push("Recheck Password is required.");
        }

        if (!checkRequiredField($("input[name=name]"))) {
            errorMsgArr.push("Name is required.");
        }

        if ($("input[name=pwd]").val() != $("input[name=rewd]").val()) {
            errorMsgArr.push("Password should be the same.");
        }

        var birthdayText = $("input[name=birthday]").val()
        if (birthdayText) {
            if (!new Date(birthdayText)) {
                errorMsgArr.push("Birthday should be a date.");
            }
        }

        $("#divMsgArea").html('');
        if (errorMsgArr.length > 0) {
            var txt = "<p>" + errorMsgArr.join("</p><p>") + "</p>";
            $("#divMsgArea").append(txt);
        }
    });
});