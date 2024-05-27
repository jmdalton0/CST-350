$(function () {
    console.log("Page is ready");

    // Add timestamp
    var timestampDiv = $("#timestamp");
    setInterval(function () {
        var now = new Date();
        timestampDiv.text("Last updated: " + now.toLocaleString());
    }, 1000); // Update every second

});

document.addEventListener('DOMContentLoaded', () => {
    //display();
});

async function display() {
    let res = await fetch('/Game/Display');
    let board = await res.text();
    document.getElementById('board').innerHTML = board;
}

async function reset() {
    await fetch('/Game/Reset');
    display();
}

async function leftClick(ind) {
    console.log(ind);
    await fetch('/Game/HandleLeftClick?ind=' + ind);
    display();
}

async function rightClick(id) {
    display();
}

