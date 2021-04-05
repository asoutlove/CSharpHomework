var arr = [
    { "Name": "超圖解 ESP32 深度實作", "ISBN": "9863126608", "Price": 880 },
    { "Name": "大話設計模式 ", "ISBN": "9866761797", "Price": 620 }
];


var init = function () {
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
    }
}

init();