var connection = new signalR.HubConnectionBuilder().withUrl("/notifyHub").build();
var notificationsCount = 0;
connection.on("ReceiveMessage", function (message) {
    console.log(message);
    notificationsCount++;
    $("#notificationsCount").html(notificationsCount);
})

connection.start().then(function () {
    console.log("connection started");
}).catch(function (err) {
    return console.error(err.toString());
})

$(document).ready(function () {
    var notifications = $("#notificationsCount");
    notifications.html(notificationsCount);
})

