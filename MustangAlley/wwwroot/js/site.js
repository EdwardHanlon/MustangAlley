function hidePreviousPosition() {
    $('#PreviousPosition').hide();
}

function showPreviousPosition() {
    $('#PreviousPosition').show();
}

function hideVehicleRegistration() {
    $('#vehicle').hide();

    $('#BodyStyle').removeAttr('required');
    $('#Color').removeAttr('required');
    $('#LicensePlateNumber').removeAttr('required');
}

function showVehicleRegistration() {
    $('#vehicle').show();

    $('#BodyStyle').prop('required', true);
    $('#Color').prop('required', true);
    $('#LicensePlateNumber').prop('required', true);
}


function recaptchaCallback() {
    $('#registerBtn').removeAttr('disabled');
};