var usersTable;
var Users = (function () {
    var toolbarOptions = [
        [{
            'header': [1, 2, 3, 4, 5, 6, false]
        }],
        ['bold', 'italic', 'underline', 'strike'],
        [{
            'list': 'ordered'
        }, {
            'list': 'bullet'
        }],
        ['link', 'image', 'video']
    ];
    function getUserInfo(avatar, email, firstName, lastName, isactive) {
        let result = "<div>" +
            "<span class='avatar brround cover-image' data-bs-image-src='../assets/images/users/11.jpg' style='background: url(&quot;" + avatar + "&quot;) center center;float: left;margin-right: 8px;'>" +
            (isactive ? "<span class='avatar-status bg-green'></span>" : "") + "</span>" +
            "<div class='ms-2 mt-0 mt-sm-2 d-block'>" +
            "<h6 class='mb-0 fs-14 fw-semibold'>" + (firstName ?? '') + " " + (lastName ?? '') + "</h6>" +
            "<span class='fs-12 text-muted'>" + email + "</span>" +
            "</div>" +
            "</div>";
        return result;
    }
    function loadConfirmDeleteUser(userId, firstName, lastName) {
        App.confirmDialog("Delete User", "Are you sure you want to delete the user <b>\"" + (firstName ?? "") + " " + (lastName ?? "") + "\"</b>?", true, "Agree", function () {
            $.ajax({
                dataType: "json",
                url: urlDeleteUser + "?userId=" + userId,
                type: 'POST',
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {
                    Users.reloadUsers();
                    $('#dialog-confirm-modal').modal('hide');
                },
                error: function (res) {
                    if (res.status == 200) {
                        $('#dialog-confirm-modal').modal('hide');
                    }
                }
            });
        }, true, "Cancel", function () { });
    }
    function init() {
        //$("#page-loader").fadeIn("slow");
        let columns = [
            {
                target: 0,
                title: "Id",
                name: "Id",
                data: "id",
                visible: false,
                orderable: false,
            },
            {
                target: 1,
                title: "<div class='text-center'>App User</div>",
                /*name: "CreatedBy",*/
                data: function (data) {
                    return getUserInfo(data.avatar == null ? '../assets/images/users/8.jpg' : data.avatar, data.email, data.firstName, data.lastName, data.isActive);
                },
                class: "align-middle",
                name: "AppUser",
                orderable: true,
            },
            {
                target: 2,
                title: "<div class='text-center'>Role</div>",
                data: function (data) {
                    switch (data.role) {
                        case "Director":
                            return "<span class='badge bg-primary-gradient fs-13'>" + data.role + "</span>";
                        case "Coach":
                            return "<span class='badge bg-success-gradient fs-13'>" + data.role + "</span>";
                        case "Player":
                            return "<span class='badge bg-warning-gradient fs-13'>" + data.role + "</span>";
                        default:
                            break;
                    }
                    return "";
                },
                orderable: true,
                class: "text-center align-middle",
                name: "Role"
            },
            {
                target: 3,
                orderable: true,
                title: "<div class='text-center'>Points</div>",
                data: function (data) {

                    switch (data.role) {
                        case "Director":
                            return "<span class='badge bg-primary-gradient fs-13'>" + "0 MP" + "</span>";
                        case "Coach":
                            return "<span class='badge bg-success-gradient fs-13'>" + (data.coach?.coachPoint ?? 0) + " CP</span>";
                        case "Player":
                            return "<span class='badge bg-warning-gradient fs-13'>" + (data.player?.workPoint ?? 0) + " WP</span>";
                        default:
                            break;
                    }
                    return "";
                },
                class: "text-center align-middle",
                name: "Points",

            },
            {
                target: 4,
                orderable: true,
                name: "Level",
                title: "<div class='text-center'>Level</div>",
                data: function (data) {
                   
                    switch (data.role) {
                        case "Director":
                            return "<span class='badge bg-primary-gradient fs-13'>" + "None" + "</span>";
                            break;
                        case "Coach":
                            return "<span class='badge bg-success-gradient fs-13'>" + ((data.coach?.coachLevel?.category?.id ?? 0) == 0 ? "None" : data.coach?.coachLevel?.category?.value) + "</span>";
                            break;
                        case "Player":
                            return "<span class='badge bg-warning-gradient fs-13'>" + ((data.player?.playerLevel?.category?.id ?? 0) == 0 ? "None" : data.player?.playerLevel?.category?.value) + "</span>";
                            break;
                        default:
                            break;
                    }
                    return "";
                },
                class: "text-center align-middle",
            },
            {
                target: 5,
                orderable: true,
                name: "Experience",
                title: "<div class='text-center'>Experience</div>",
                data: function (data) {

                    switch (data.role) {
                        case "Director":
                            return "<span class='badge bg-primary-gradient fs-13'>" + "0 EP" + "</span>";
                        case "Coach":
                            return "<span class='badge bg-success-gradient fs-13'>" + (data.coach?.coachLevel?.experiencePoint ?? 0) + " EP</span>";
                        case "Player":
                            return "<span class='badge bg-warning-gradient fs-13'>" + (data.player?.playerLevel?.experiencePoint ?? 0) + " EP</span>";
                            break;
                        default:
                            break;
                    }
                    return "";
                },
                class: "text-center align-middle",
            },
            {
                target: 6,
                orderable: true,
                name: "Address",
                title: "<div class='text-center'>Address</div>",
                data: function (data) {
                    return  data.location?.address;
                },
                class: "align-middle",
            },
            {
                target: 7,
                title: "<div class='text-center'>Phone Number</div>",
                data: function (data) {

                    return data.phoneNumber ?? "";
                },
                orderable: true,
                class: "text-center align-middle",
                name: "PhoneNumber"
            },
            {
                target: 8,
                orderable: true,
                title: "<div class='text-center'>Joined date</div>",
                name: "CreatedDate",
                /* data: "createdDate",*/
                data: function (data) {
                    return data.createdDate ? moment(data.createdDate).format('YYYY-MM-DD HH:mm') : null;
                },
                class: "text-center align-middle",
            },
            {
                target: 9,
                //title: "<div class='text-center'></div>",
                data: function (data) {
                    var dropdownAction = "<div class='btn-group'><button type='button' class='btn btn-outline-primary dropdown-toggle' data-bs-toggle='dropdown'>Action <span class='caret'></span></button>";
                    dropdownAction += "<ul class='dropdown-menu' role='menu'>";
                    if (data.role == "Director" || data.role == "Coach") {
                        dropdownAction += "<li><a href='javascript:void(0);' onclick='Users.showPaymentLinksModal(\"" + data.id + "\", \"" + data.firstName + "\", \"" + data.lastName + "\")'>Payment Links</a></li>";
                        //dropdownAction += "<li class='divider'></li>";
                    }
                    dropdownAction += "<li><a href='javascript:void(0);' onclick='Users.changeUserStatusDialog(\"" + data.id + "\", \"" + data.firstName + "\", \"" + data.lastName + "\",\"" + data.isActive + "\")'>" + (data.isActive ? "Deactivate": "Activate") + "</a></li>";
                    dropdownAction += "<li><a href='javascript:void(0);' onclick='Users.loadConfirmDeleteUser(\"" + data.id + "\", \"" + data.firstName + "\", \"" + data.lastName + "\")'>Delete</a></li>";
                    dropdownAction += "</ul></div>";
                    return dropdownAction;
                },
                orderable: false,
                class: "text-center align-middle",
                width: "8%"
            },
        ];
        usersTable = $('#usersTable').DataTable({
            autoWidth: false,
            processing: false,
            serverSide: true,
            info: true,
            lengthMenu: [10, 20, 30, 50, 100],
            pageLength: 10,
            lengthChange: true,
            searching: true,
            columns: columns,
            paging: true,
            scrollX: false,
            ordering: true,
            order: [[0, "desc"]],
            language: {
                searchPlaceholder: 'Search...',
                sSearch: '',
            },
            ajax: {
                type: "POST",
                url: urlGetUsers,
            },
            initComplete: function (settings, json) {
                $('.select2').select2({
                    minimumResultsForSearch: Infinity
                });


            },
            error: function (settings, json) {
            },
            success: function (data) {
            },
            fnDrawCallback: function () {
                loadPageSpinner(false);
            },
            preDrawCallback: function (settings) {
                loadPageSpinner(true);
            }
        });
        
    }
    function loadPageSpinner(status) {
        if (status) {
            $("#page-loader").fadeIn("fast");
        } else {
            $("#page-loader").fadeOut("fast");
        }
    }
    function loadGlobalSpinner(status) {
        if (status) {
            $("#global-loader").fadeIn("fase");
        } else {
            $("#global-loader").fadeOut("slow");
        }
    }
    function copyToClipboard(element) {
        var $temp = $("<input>");
        $("body").append($temp);
        $temp.val($(element).val());
        $temp[0].select();
        $temp[0].setSelectionRange(0, 99999);
        navigator.clipboard.writeText($temp[0].value);
        $temp.remove();

        notif({
            msg: "Copied",
            type: "success"
        });
    }
    function reloadUsers() {
        $('#usersTable').DataTable().ajax.reload();
    }
    function showPaymentLinksModal(appUserId, firstName, lastName) {
        //loadGlobalSpinner(true);
        $.ajax({
            type: "GET",
            url: urlGetPaymentLinks + (appUserId != undefined ? "?appUserId=" + appUserId : ""),
            success: function (data) {
                $("#modal-loader-paymentlinks").fadeOut("fast");
                $("#modal-container-paymentlinks").find('.modal-body > #paymentlinkTitle').html(String("Send payment links to " + firstName + " " + lastName));
                $("#modal-container-paymentlinks").find('.modal-body > #paymentlinkList').html(String(data));
                $("#modal-container-paymentlinks").find('.modal-body > #paymentlinkButtons').html("<button class='btn btn-light' type='button' data-bs-dismiss='modal' aria-label='Close'>Cancel</button> <button class='btn btn-success pd-y-25' onclick='Users.sendPaymentLinks(\"" + appUserId + "\", \"" + firstName + "\", \"" + lastName + "\")' type='button'>Send</button>");
                $("#modal-container-paymentlinks").modal("show");
                //loadGlobalSpinner(false);
            },
            error: function (data) {
                
            }
        });
    }
    function changeUserStatusDialog(appUserId, firstName, lastName, isActive) {
        let title = isActive ? "Deactivate User" : "Active User";
        let message = "Are you sure you want to " + (isActive == 'true' ? "deactivate" : "active") + " the user <b>\"" + (firstName ?? "") + " " + (lastName ?? "") + "\"</b>?"
        App.confirmDialog(title, message, true, "Agree", function () {
            let data = {
                appUserId: appUserId,
                isActive: !(isActive == 'true')
            }
            $.ajax({
                type: "POST",
                url: urlChangeUserStatus,
                data: data,
                dataType: "json",
                success: function (res) {
                    Users.reloadUsers();
                    $('#dialog-confirm-modal').modal('hide');
                },
                error: function () {
                    if (res.status == 200) {
                        $('#dialog-confirm-modal').modal('hide');
                    }
                }


            });
        }, true, "Cancel", function () { });
    }
    function sendPaymentLinks(appUserId, firstName, lastName) {
        $("#modal-loader-paymentlinks").fadeIn("fast");
        //loadGlobalSpinner(true);
        $.ajax({
            type: "POST",
            url: urlSendPaymentLinks + (appUserId != undefined ? "?appUserId=" + appUserId : ""),
            success: function (data) {
                $("#modal-loader-paymentlinks").fadeOut("fast");
                $("#modal-container-paymentlinks").modal('hide');
                //$.growl.notice({
                //    message: "You have 4 notification"
                //})
                notif({
                    msg: "Payment links sent Successfully",
                    type: "success"
                });
            },
            error: function () {
            }
        });
    }
    return {
        init: init,
        reloadUsers: reloadUsers,
        showPaymentLinksModal: showPaymentLinksModal,
        copyToClipboard: copyToClipboard,
        sendPaymentLinks: sendPaymentLinks,
        changeUserStatusDialog: changeUserStatusDialog,
        loadConfirmDeleteUser: loadConfirmDeleteUser
    }
})();
$(document).ready(function () {
    Users.init();

});

$(document).on('focus', '.dataTables_filter input', function () {

    $(this).unbind().bind('keyup', function (e) {
        if (e.keyCode === 13) {
            usersTable.search(this.value).draw();
        }
    });

});