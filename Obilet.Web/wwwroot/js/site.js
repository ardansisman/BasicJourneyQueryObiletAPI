$(document).ready(function () {
    $('.select2').select2();
});
$("#swap").click(function (e) {
    e.preventDefault();

    let tempOriginId = $("#origin option:selected").val();
    let tempOriginName = $("#origin option:selected").text();

    let tempDestinationId = $("#destination option:selected").val();
    let tempDestinationName = $("#destination option:selected ").text();

    if ($('#origin').find("option[value='" + tempDestinationId + "']").length) {
        $('#origin').val(tempDestinationId).trigger('change');
    }
    if ($('#destination').find("option[value='" + tempOriginId + "']").length) {
        $('#destination').val(tempOriginId).trigger('change');
    }

});
$("#todayBtn").on('click', function () {
    let now = new Date();
    let today = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + now.getDate();
    $('#departureDate').val(today);
});
$("#tomorrowBtn").on('click', function () {
    let now = new Date();
    let tomorrow = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + (now.getDate()+1);
    $('#departureDate').val(tomorrow);
});