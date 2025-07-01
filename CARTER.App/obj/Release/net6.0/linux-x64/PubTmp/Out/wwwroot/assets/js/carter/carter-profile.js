var Profile = (function () {
    function init() {
        //loadSpinner(false, 'modal-loader');
        $("#btn-change-password").on('click', function () {
            loadChangePassword();
        });

        $("#btn-edit-profile").on('click', function () {
            loadEditProfile();
        });
        loadProfile();
    }
    function loadChangePassword() {
        $.ajax({
            type: "GET",
            url: urlChangePassword,
            success: function (data) {
                showChangePasswordModal(data, "Profile.changePassword()");
            },
            error: function () {
            }
        });
    }
    function loadProfile() {
        loadSpinner(true, '#page-loader');
        $.ajax({
            type: "GET",
            url: urlGetProfile,
            success: function (data) {
                console.log(data);
                $('#avatar').attr('src', data.userResponse.data.avatar);
                $("#profileName").html((data.userResponse.data.firstName ?? '') + ' ' + (data.userResponse.data.lastName ?? ''));
                $("#createdDate").html((data.userResponse.data.role ?? '') + ' since: ' + moment.utc(data.userResponse.data.createdDate).local().format('YYYY-MM-DD HH:mm A'));
                $("#email").html(data.userResponse.data.email ?? '');
                $("#fullName").html((data.userResponse.data.firstName ?? '') + ' ' + (data.userResponse.data.lastName ?? ''));
                $("#phoneNumber").html(data.userResponse.data.phoneNumber ?? '');
                $("#address").html(data.userResponse.data.location.address ?? '');
                $("#countDirectors").html(data.directorsResponse.data.totalRecords);
                $("#countCoaches").html(data.coachesResponse.data.totalRecords);
                $("#countPlayers").html(data.playersResponse.data.totalRecords);
                loadSpinner(false, '#page-loader');
            },
            error: function () {
            }
        });
    }
    function loadEditProfile() {
        $.ajax({
            type: "GET",
            url: urlEditProfile,
            success: function (data) {
                showEditProfileModal(data, "Profile.editProfile()");
            },
            error: function () {
            }
        });
    }
    function changePassword() {
        $("#frmChangePassword").submit();
    }
    function editProfile() {
        $("#frmEditProfile").submit();
    }
    function showChangePasswordModal(data, submitfn) {
        $("#modal-container-change-password").find('.modal-body').html(String(data));
        $("#modal-container-change-password").find('.modal-footer').html("<button class='btn btn-light' type='button' data-bs-dismiss='modal' aria-label='Close'>Cancel</button><button class='btn btn-primary' type='button' onclick='" + submitfn + "'>Save changes</button>");
        $(".input-validation-error").addClass("is-invalid");
        $("#modal-container-change-password").modal("show");
        Profile.loadSpinner(false, '#modal-container-change-password #modal-loader');
    }
    function showEditProfileModal(data, submitfn) {
        $("#modal-container-edit-profile").find('.modal-body').html(String(data));
        $("#modal-container-edit-profile").find('.modal-footer').html("<button class='btn btn-light' type='button' data-bs-dismiss='modal' aria-label='Close'>Cancel</button><button class='btn btn-primary' type='button' onclick='" + submitfn + "'>Save changes</button>");
        $(".input-validation-error").addClass("is-invalid");
        $("#modal-container-edit-profile").modal("show");
        Profile.loadSpinner(false, '#modal-container-edit-profile #modal-loader');
    }
    function loadSpinner(status, name) {
        if (status) {
            $(name).fadeIn("fast");
        } else {
            $(name).fadeOut("fast");
        }
    }
   
    
   
    
    return {
        init: init,
        loadSpinner: loadSpinner,
        loadProfile: loadProfile,
        loadChangePassword: loadChangePassword,
        changePassword: changePassword,
        showChangePasswordModal: showChangePasswordModal,
        loadEditProfile: loadEditProfile,
        editProfile: editProfile,
        showEditProfileModal: showEditProfileModal
    }
})();
$(document).ready(function () {
    Profile.init();
});
