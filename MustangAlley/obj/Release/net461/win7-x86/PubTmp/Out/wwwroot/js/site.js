function hidePreviousPosition() {
    $('#PreviousPosition').hide();
}

function showPreviousPosition() {
    $('#PreviousPosition').show();
}

function hideVehicleRegistration() {
    $('#vehicle').hide();
}

function showVehicleRegistration() {
    $('#vehicle').show();
}

function hideVolunteerRegistration() {
    $('#volunteer').hide();
}

function showVolunteerRegistration() {
    $('#volunteer').show();
}

function recaptchaCallback() {
    $('#registerBtn').removeAttr('disabled');
};