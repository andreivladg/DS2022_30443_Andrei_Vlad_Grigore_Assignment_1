var connection = new signalR.HubConnectionBuilder().withUrl("/notifyHub").build();

connection.on("ReceiveMessage", function (message) {
    console.log(message);
    alert("Consumption limit exceeded!");
})

connection.start().then(function () {
    console.log("connection started");
    notificationsCount = localStorage.getItem("notifications");
}).catch(function (err) {
    return console.error(err.toString());
})

 