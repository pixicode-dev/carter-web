var App = (function () {
    function confirmDialog(tilte, message, yesButon, yesButtonlabel, callbackYes, noButton, noButtonlabel, callbackNo) {
        yesButon = yesButon || true;
        noButton = noButton || true;
        $("#dialog-confirm-modal").find(".modal-body").find("h4").html(tilte);
        $("#dialog-confirm-modal").find(".modal-body").find("p").html(message);

        if (!noButton) {
            $("#dialog-confirm-modal").find("#btn-no").hide();
        } else {
            $("#dialog-confirm-modal").find("#btn-no").html(noButtonlabel);
            $("#dialog-confirm-modal").find("#btn-no").unbind('click');
            $("#dialog-confirm-modal").find("#btn-no").click(function () {
                $('#dialog-confirm-modal').modal('hide');

                callbackNo();
            });
        }


        if (!yesButon) {
            $("#dialog-confirm-modal").find("#btn-yes").hide();
        } else {
            $("#dialog-confirm-modal").find("#btn-yes").html(yesButtonlabel);
            $("#dialog-confirm-modal").find("#btn-yes").unbind('click');
            $("#dialog-confirm-modal").find("#btn-yes").click(function () {
                $('#dialog-confirm-modal').modal('hide');
                callbackYes();
            });
        }
        $('#dialog-confirm-modal').modal('show');
    };
    return {
        confirmDialog: confirmDialog
    }
})();

$(document).ajaxError(function (e, xhr) {
    switch (xhr.status) {
        case 200: // succeeded
            break;
        case 401: // Authorize (Session expired)
            location.reload();
            break;
        //case 500:
        //    document.location.href = urlError + "?status=500";
        //    break;
        //case 404:
        //    document.location.href = urlError + "?status=400";
        //    break;
        //case 400:
        //    document.location.href = '@Url.Action("BadRequest", "Error")';
        //    break;
        //case 440:
        //    document.location.href = '@Url.Action("Login", "User")';
        //    break;
        default:
            //console.log(xhr);
            document.location.href = urlError + "?status=" + xhr.status + "&message=" + xhr.responseJSON.message;
            break;
    }
    
});
$(document).ready(function () {
    $('.select2').select2({
        minimumResultsForSearch: Infinity
    });
})