function btn1_onclick() {
    var inputArr = document.getElementsByTagName("input");
    var textareaArr = document.getElementsByTagName("textarea");

    var domNickname, domTitle;
    var domMessage = textareaArr[0];

    for (var i = 0; i < inputArr.length; i++) {
        if (inputArr[i].name == "nickname")
            domNickname = inputArr[i];

        if (inputArr[i].name == "title")
            domTitle = inputArr[i];
    }

    var html =
        '<div style="border: 1px solid black;"><p>NickName: ' +
        domNickname.value + "</p><p> Time: " +
        new Date().toISOString() + "</p><p> Title: " +
        domTitle.value + "</p><p> Message: " +
        domMessage.value + "</p></div>";

    document.getElementById("divContext").innerHTML += html;
}
