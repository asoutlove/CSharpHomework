var init = function (arr) {
    var table1 = document.getElementById("tableList");

    for (var i = 0; i < arr.length; i++) {
        var newDom = document.createElement("tr");
        var item = arr[i];

        var html =
            '<td>' +
            item.Name + "</td><td> " +
            item.ISBN + "</td><td> $" +
            item.Price + "</td>";

        newDom.innerHTML = html;
        table1.appendChild(newDom);
    }
}