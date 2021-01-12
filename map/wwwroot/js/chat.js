"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    
       b(user);
    
  
});


connection.on("ReceiveMessage1", function (user, message) {
    
       ca(user);
       ca1(user);
    
  
});

connection.on("ReceiveMessage2", function (user, message) {
    
    passenger(user);
 

});


connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

 function a(event) {
     
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}



function cancel(event) {
    
   var user = document.getElementById("userInput").value;
   var message = document.getElementById("messageInput").value;
   connection.invoke("cancel", user, message).catch(function (err) {
       return console.error(err.toString());
   });
   event.preventDefault();
}


function acceptdriver(phone) {
    
    var user = phone;
    var message = document.getElementById("messageInput").value;
    connection.invoke("accept", user, message).catch(function (err) {
        return console.error(err.toString());
    });
   
 }