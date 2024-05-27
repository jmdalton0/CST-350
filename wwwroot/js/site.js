$(function () {
    //console.log("Page is ready");

    // Add timestamp
    var timestampDiv = $("#timestamp");
    setInterval(function () {
        var now = new Date();
        timestampDiv.text("Last updated: " + now.toLocaleString());
    }, 1000); // Update every second

});

document.addEventListener('DOMContentLoaded', () => {
    display();
});

async function display() {
    let res = await fetch('/Game/Message');
    let data = await res.text();
    document.getElementById('message').innerHTML = data;

    res = await fetch('/Game/Display');
    data = await res.text();
    document.getElementById('board').innerHTML = data;
}

async function reset() {
    await fetch('/Game/Reset');
    display();
}

async function leftClick(ind) {
    await fetch('/Game/HandleLeftClick?ind=' + ind);
    display();
}

async function rightClick(e, ind) {
    e.preventDefault();
    await fetch('/Game/HandleRightClick?ind=' + ind);
    display();
}

