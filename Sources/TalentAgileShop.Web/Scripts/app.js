"use strict";
function addLogPanel(message, panelType) {
    $("#logContent").append(`<div class='alert alert-${panelType} alert-dismissible' role='alert'><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>${message}</div>`);
}
function logInfo(message) {
    addLogPanel(message, "info");
}
function logWarning(message) {
    addLogPanel(message, "warning");
}
function logSuccess(message) {
    addLogPanel(message, "success");
}
function logDanger(message) {
    addLogPanel(message, "danger");
}
//# sourceMappingURL=app.js.map