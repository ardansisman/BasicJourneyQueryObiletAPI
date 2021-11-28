$(document).ready(function () {
    $('.select2').select2();
    debugger;
    //let now = new Date();
    //let tomorrow = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + (now.getDate() + 1);
    //$('#departureDate').val(tomorrow);
    
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

$("#FindTicket").on('click', function (e) {
    debugger;
    
    var departureDate = new Date(toValidDate($("#departureDate").val()));
    var currentTime = new Date();
    
    if (departureDate < currentTime) {
        e.preventDefault();
        SweetAlert('error', '', 'Tarih seçimi bugün veya bugünden sonra olmalıdır.', 'Tamam');
        //alert("Tarih seçimi bugün veya bugünden sonra olmalıdır.");
    }

    if ($("#origin option:selected").val() == $("#destination option:selected").val()) {
        e.preventDefault();
        SweetAlert('error', '', 'Kalkış ve varış yerleri farklı olmalıdır.', 'Tamam');
        //alert("Kalkış ve varış yerleri farklı olmalıdır.");
    }

});
function SweetAlert(state, title, text, buttonText, redirectUrl) {

    Swal.fire({
        title: title,
        icon: state,
        html: text,
        confirmButtonText: buttonText,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    }).then(function () {
        if (redirectUrl) {
            location.href = redirectUrl;
        }

    });



}
function toValidDate(datestring) {
    debugger
    return datestring.replace(/(\d{2})(\/)(\d{2})/, "$3$2$1");
}