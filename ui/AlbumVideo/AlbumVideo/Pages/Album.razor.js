export function AlertaSuccess(msj) {
    $("#msjSuccess").text(msj);
    $("#success-alert").prop("hidden", false);
    $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#success-alert").slideUp(500);
    });
}

export function AlertaError(msj) {
    $("#msjError").text(msj);
    $("#error-alert").prop("hidden", false);
    $("#error-alert").fadeTo(2000, 500).slideUp(500, function () {
        $("#error-alert").slideUp(500);
    });
}

export function ConfirmaEliminar() {
    $('#ModalConfirmacion').modal('show');
}

export function EliminacionConfirmada() {
    $('#ModalConfirmacion').modal('hide');
}

export function LimpiarControles() {
    $('#txtVideoURL').val('');
}