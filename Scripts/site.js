// Write your Javascript code.
$(document).ready(function(){
    $.ajax({
        url: "/VendorsData/getFiles",
        type: "GET",
        success: function (mydata) {
            var files = mydata;
            console.log("GotFiles: " + files.toString());
            fillOptions(files);
        }});
    
    function fillOptions(files) {
        var option = '';
        for (var i=0;i<files.length;i++){
            option += '<option value="'+ files[i] + '">' + files[i] + '</option>';
        }
        $('#filesList').append(option);
    }
    
    
    $("#processCSV").click(function(){
        var path = $('#filesList').find(":selected").text();
        alert("FilePath: " + path);
        $.ajax({
            url: "/VendorsData/uploadCSV",
            type: "GET",
            dataType: "json",
            data: {"path": path},
            success: function (mydata) {
                $("#csvDisplay").html(mydata);
            }});
    });
});
