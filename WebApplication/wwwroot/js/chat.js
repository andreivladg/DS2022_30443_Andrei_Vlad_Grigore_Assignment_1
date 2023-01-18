const msgerInput = $(".msger-input")[0];
const msgerChat = $(".msger-chat");
const RIGHT = "right"
const LEFT = "left";
const USERNAME = $(".msger").data("username");
const SENDER = $(".msger").data("sender");
var connectionChat = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connectionChat.on("ReceiveChat", function (chat) {
    console.log(chat.username);
    console.log(SENDER);
   // console.log(chat.message);
    if (chat.message == null) {
        $("#typing").removeAttr("hidden");
    }
    else if (chat.message != null) {
        $("#typing").attr("hidden", true);
        if (SENDER == "Admin") {
            if (chat.sender == USERNAME) {
                appendMessage(USERNAME, chat.message, LEFT);
            }
        }
        else if (chat.username == SENDER) {
            appendMessage(USERNAME, chat.message, LEFT);
        }
    }
    
})

connectionChat.start().then(function () {
    console.log("chat connection started");
}).catch(function (err) {
    return console.error(err.toString());
})

$(".msger-inputarea").keydown(function () {
    $.ajax({
        type: "POST",
        url: "/Home/Typing",
        cache: false
    })
})

$(".msger-inputarea").on('submit', function (event) {
    event.preventDefault();
    var inputText = msgerInput.value;
    appendMessage(SENDER, inputText, RIGHT);
    var model = {
        UserId: '',
        Sender: SENDER,
        Username: USERNAME,
        Message: inputText
    };
    $.ajax({
        type: "POST",
        url: "/Home/SendMessage",
        cache: false,
        data:model,
    })
})

appendMessage = function (name, message,side) {
    const msgHTML = 
    `<div class="msg ${side}-msg">
      <div class="msg-bubble">
        <div class="msg-info">
          <div class="msg-info-name">${name}</div>
        </div>

        <div class="msg-text">${message}</div>
      </div>
    </div>`;
    msgerChat.append(msgHTML)
    msgerChat.scrollTop += 500;
}