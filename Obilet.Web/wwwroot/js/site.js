$(document).ready(function () {
    $('.select2').select2();
    var table = $('.dataTable').DataTable({
        "searching": false,
        "lengthChange": false,
        "order": false
    });
    DatePickerPastTimeControl();
});

$("#swap").click(function (e) {
    e.preventDefault();

    let originId = $("#origin option:selected").val();
    let destinationId = $("#destination option:selected").val();

    if ($('#origin').find("option[value='" + destinationId + "']").length) {
        $('#origin').val(destinationId).trigger('change');
    }
    if ($('#destination').find("option[value='" + originId + "']").length) {
        $('#destination').val(originId).trigger('change');
    }

});

$("#FindTicket").on('click', function (e) {
    var currentTime = new Date();

    if ($.date(departureDate) < $.date(currentTime)) {
        e.preventDefault();
        SweetAlert('error', '', 'Tarih seçimi bugün veya bugünden sonra olmalıdır.', 'Tamam');
    }

    if ($("#origin option:selected").val() == $("#destination option:selected").val()) {
        e.preventDefault();
        SweetAlert('error', '', 'Kalkış ve varış yerleri farklı olmalıdır.', 'Tamam');
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
function DatePickerPastTimeControl() {
    var dtToday = new Date();

    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if (month < 10)
        month = '0' + month.toString();
    if (day < 10)
        day = '0' + day.toString();

    var maxDate = year + '-' + month + '-' + day;

    $('#departureDate').attr('min', maxDate);
}
function SetDate(date) {
    $('#departureDate').val(date);
}
$.date = function (dateObject) {
    var d = new Date(dateObject);
    var day = d.getDate();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    if (day < 10) {
        day = "0" + day;
    }
    if (month < 10) {
        month = "0" + month;
    }
    var date = day + "/" + month + "/" + year;

    return date;
};