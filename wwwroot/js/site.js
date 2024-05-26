$(function () {
    console.log("Page is ready");

    // Add timestamp
    var timestampDiv = $("#timestamp");
    setInterval(function () {
        var now = new Date();
        timestampDiv.text("Last updated: " + now.toLocaleString());
    }, 1000); // Update every second

});
