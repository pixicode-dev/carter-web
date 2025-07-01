var quillObjectives;
var quillInstruction;
var quillEvolution;
var exercisesTable;
var Exercises = (function () {
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
    function getCreatedBy(avatar, email, firstName, lastName) {
        let result = "<div>" +
            "<img src='" + avatar + "' alt='profile-user' class='nav-link icon profile-user brround cover-image' style='padding: 3px !important;float: left !important;margin: -3px 0px 0 -10px;'>" +
            "<div class='ms-2 mt-0 mt-sm-2 d-block'>" +
            "<h6 class='mb-0 fs-14 fw-semibold'>" + (firstName ?? '') + " " + (lastName ?? '') + "</h6>" +
            "<span class='fs-12 text-muted'>" + email + "</span>" +
            "</div>" +
            "</div>";
        return result;
    }
    function loadAddExercise() {
        $.ajax({
            type: "GET",
            url: urlAddExercise,
            success: function (data) {
                showExerciseModal(data, "Add Exercise", "Exercises.addExercise()");
                $("#modal-loader").fadeOut("fast");
            },
            error: function () {
            }
        });
    }
    function loadEditExercise(exerciseId) {
        //loadGlobalSpinner(true);
        $.ajax({
            type: "GET",
            url: urlEditExercise + (exerciseId != undefined ? "?exerciseId=" + exerciseId : ""),
            success: function (data) {
                showExerciseModal(data, "Edit Exercise", "Exercises.updateExercise()");
                $("#modal-loader").fadeOut("fast");
                //loadGlobalSpinner(false);
            },
            error: function () {
            }
        });
    }
    function loadConfirmDeleteExercise(exerciseId, title) {
        App.confirmDialog("Delete Exercise", "Are you sure you want to delete the exercise <b>\"" + title +"\"</b>?", true, "Agree", function () {
            $.ajax({
                dataType: "json",
                url: urlDeleteExercise + "?exerciseId=" + exerciseId,
                type: 'POST',
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {
                    Exercises.reloadExercises();
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
                visible: false
            },
            {
                target: 1,
                title: "Title",
                name: "Title",
                data: "title",
                class: "align-middle"
            },
            {
                target: 2,
                title: "<div class='text-center'>Created date</div>",
                name: "CreatedDate",
                /* data: "createdDate",*/
                data: function (data) {
                    return data.createdDate ? moment(data.createdDate).format('YYYY-MM-DD HH:mm') : null;
                },
                class: "text-center align-middle",
                width: "10%"
            },
            {
                target: 3,
                title: "<div class='text-center'>Modify date</div>",
                name: "ModifyDate",
                data: function (data) {
                    return data.modifyDate ? moment(data.modifyDate).format('YYYY-MM-DD HH:mm') : null;
                },
                class: "text-center align-middle",
                width: "10%"
            },
            //{
            //    target: 4,
            //    title: "<div class='text-center'>Category</div>",
            //    name: "CategoryId",
            //    data: function (data) {
            //        if (data.categories != null) {
            //            let categorytags = "";
            //            for (var i = 0; i < data.categories.length; i++) {
            //                categorytags += "<span class='badge bg-success fs-12'>" + data.categories[i].value + "</span>";
            //            }
            //            return categorytags;
            //        }
            //        return "<span class='badge bg-success fs-12'>None</span>";
            //    },
            //    class: "text-center align-middle",
            //    width: "10%"
            //},
            {
                target: 5,
                title: "<div class='text-center'>Type</div>",
                name: "TypeId",
                data: function (data) {
                    //if (data.type.key == 'INDIVIDUAL') {
                    //    return "<span class='badge bg-secondary fs-12'>" + data.types.value + "</span> ";
                    //}
                    let typeNames = data.types.map(t => t.value).join(' / ');
                    return "<span class='badge bg-success fs-12'>" + typeNames +"</span>";
                },
                class: "text-center align-middle",
                width: "10%"
            },
            {
                target: 6,
                title: "<div class='text-center'>Status</div>",
                name: "StatusId",
                data: function (data) {
                    if (data.status.key == 'PRIVATE') {
                        return "<span class='badge bg-danger fs-12'>" + data.status.value + "</span>";
                    }
                    return "<span class='badge bg-success fs-12'>" + data.status.value + "</span>";
                },
                class: "text-center align-middle",
                width: "10%"
            },
            {
                target: 7,
                title: "<div class='text-center'>Created by</div>",
                /*name: "CreatedBy",*/
                data: function (data) {
                    return getCreatedBy(data.appUser.avatar == null ? '../assets/images/users/8.jpg':data.appUser.avatar, data.appUser.email, data.appUser.firstName, data.appUser.lastName);
                },
                orderable: false,
                class: "align-middle",
                width: "12%"
            },
            {
                target: 8,
                //title: "<div class='text-center'>Action</div>",
                data: function (data) {
                    //let editButton = '<a class="btn btn-primary btn-sm rounded-11 me-2" data-id="' + data.id + '" onclick="Exercises.loadEditExercise(this.attributes[\'data-id\'].value);" data-bs-toggle="tooltip" data-bs-original-title="Edit"><i><svg class="table-edit" xmlns="http://www.w3.org/2000/svg" height="20" viewBox="0 0 24 24" width="16"><path d="M0 0h24v24H0V0z" fill="none"/><path d="M3 17.25V21h3.75L17.81 9.94l-3.75-3.75L3 17.25zM5.92 19H5v-.92l9.06-9.06.92.92L5.92 19zM20.71 5.63l-2.34-2.34c-.2-.2-.45-.29-.71-.29s-.51.1-.7.29l-1.83 1.83 3.75 3.75 1.83-1.83c.39-.39.39-1.02 0-1.41z"/></svg></i></a>';
                    //let deleteButton = '<a class="btn btn-danger btn-sm rounded-11" data-title="' + data.title + '" data-id="' + data.id + '" onclick="Exercises.loadConfirmDeleteExercise(this.attributes[\'data-id\'].value,this.attributes[\'data-title\'].value)" data - bs - toggle="tooltip" data - bs - original - title="Delete" > <i><svg class="table-delete" xmlns="http://www.w3.org/2000/svg" height="20" viewBox="0 0 24 24" width="16"><path d="M0 0h24v24H0V0z" fill="none" /><path d="M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V7H6v12zM8 9h8v10H8V9zm7.5-5l-1-1h-5l-1 1H5v2h14V4h-3.5z" /></svg></i></a > ';
                    //return editButton + deleteButton;
                    var dropdownAction = "<div class='btn-group'><button type='button' class='btn btn-outline-primary dropdown-toggle' data-bs-toggle='dropdown'>Action <span class='caret'></span></button>";
                    dropdownAction += "<ul class='dropdown-menu' role='menu'>";
                    dropdownAction += "<li><a href='javascript:void(0);' onclick='Exercises.loadEditExercise(\"" + data.id + "\")'>Edit</a></li>";
                    dropdownAction += "<li><a href='javascript:void(0);' onclick='Exercises.loadConfirmDeleteExercise(\"" + data.id + "\", \"" + data.title + "\")'>Delete</a></li>";
                    dropdownAction += "</ul></div>";
                    return dropdownAction;
                },
                orderable: false,
                class: "text-center align-middle",
                width: "10%"
            },
        ];
        exercisesTable = $('#exercisesTable').DataTable({
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
            order: [[1, "desc"]],
            language: {
                searchPlaceholder: 'Search...',
                sSearch: '',
            },
            ajax: {
                type: "POST",
                url: urlGetexercises,
            },
            initComplete: function (settings, json) {
                $('.select2').select2({
                    minimumResultsForSearch: Infinity
                });
               
                
            },
            error: function (settings, json) {
                console.log(json);
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
        $("#btn-add-exercise").on('click', function () {
            loadAddExercise();
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
    function loadInputExercise() {
        quillObjectives = new Quill('#quillObjectives', {
            modules: {
                toolbar: toolbarOptions
            },
            /*placeholder: 'Compose an epic...',*/
            theme: 'snow'
        });
        quillObjectives.container.firstChild.innerHTML = $("#Objectives")[0].value;
        quillInstruction = new Quill('#quillInstruction', {
            modules: {
                toolbar: toolbarOptions
            },
            /*placeholder: 'Compose an epic...',*/
            theme: 'snow'
        });
        quillInstruction.container.firstChild.innerHTML = $("#Instruction")[0].value;
        quillEvolution = new Quill('#quillEvolution', {
            modules: {
                toolbar: toolbarOptions
            },
            /*placeholder: 'Compose an epic...',*/
            theme: 'snow'
        });
        quillEvolution.container.firstChild.innerHTML = $("#Evolution")[0].value;
        $("#modal-container-exercise").modal("show");
        loadTacticalBoards();
        //fancyfileuplod
        $('#files').FancyFileUpload({
            url: urlUploadTacticalBoard,
            //params: {
            //    action: 'fileuploader'
            //},
            maxfilesize: 1000000,
            added: function (e, data) {
                // It is okay to simulate clicking the start upload button.
                
                this.find('.ff_fileupload_actions button.ff_fileupload_start_upload').click();

            },
            uploadcompleted: function (e, data) {
                let tacticalboardIndex = $("#tacticalboardfiles > .testclass").length;
                let tacticalboardId = "Tacticalboards_" + tacticalboardIndex + "_";
                let lightgalleryId = "Tacticalboards_" + tacticalboardIndex + "_glr";
                let tacticalboardName = "Tacticalboards[" + tacticalboardIndex + "]";
                let fileUrl = data._response.result.data;
                $("#lightgallery").append("<div id='" + lightgalleryId + "' class='col-lg-3 col-md-6 file-image' data-responsive='" + fileUrl + "'><a href='javascript:void(0);'><ul class='icons'><li><button type='button' onclick=\"Exercises.removeTacticalboard('" + tacticalboardId + "', '" + lightgalleryId + "')\" class='btn btn-icon btn-danger'><i class='fe fe-trash'></i></button></li></ul><img class='img-fluid  mb-2 br-7' src='" + fileUrl + "' alt='banner image'></a></div>");
                $("#tacticalboardfiles").append("<input class='testclass' id='" + tacticalboardId + "' name='" + tacticalboardName + "' type='hidden' value='" + fileUrl + "'>")
                //console.log(data.ff_info);
                //data.ff_info.RemoveFile();
            }
        });
        $('#TagNames').select2({
            width: '100%',
            data: allTags,
            //minimumResultsForSearch: Infinity,
            tags: true,
            dropdownParent: $("#modal-container-exercise")
        }).val(selectedTags).trigger('change');

        $('#StatusId').select2({
            width: '100%',
            minimumResultsForSearch: -1,
            dropdownParent: $("#modal-container-exercise")
        });
        $('#CategoryNames').select2({
            width: '100%',
            data: allCategories,
            //minimumResultsForSearch: Infinity,
            tags: true,
            dropdownParent: $("#modal-container-exercise")
        }).val(selectedCategories).trigger('change');

        $('#TypeNames').select2({
            width: '100%',
            data: allTypes,
            //minimumResultsForSearch: Infinity,
            //tags: true,
            dropdownParent: $("#modal-container-exercise")
        }).val(selectedTypes).trigger('change');
    }
    function addExercise() {
        $("#Objectives")[0].value = quillObjectives.root.innerHTML;
        $("#Instruction")[0].value = quillInstruction.root.innerHTML;
        $("#Evolution")[0].value = quillEvolution.root.innerHTML;
        $("#frmAddExercise").submit();
    }
    function updateExercise() {
        
        $("#Objectives")[0].value = quillObjectives.root.innerHTML;
        $("#Instruction")[0].value = quillInstruction.root.innerHTML;
        $("#Evolution")[0].value = quillEvolution.root.innerHTML;
        $("#frmUpdateExercise").submit();
    }
    function reloadExercises() {
        $('#exercisesTable').DataTable().ajax.reload();
    }
    function showExerciseModal(data, title, submitfn) {
        $("#modal-container-exercise").find('.modal-title').html(String(title));
        $("#modal-container-exercise").find('.modal-body').html(String(data));
        $("#modal-container-exercise").find('.modal-footer').html("<button class='btn btn-light' type='button' data-bs-dismiss='modal' aria-label='Close'>Cancel</button><button class='btn btn-primary' type='button' onclick='" + submitfn+"'>Save changes</button>");
        $(".input-validation-error").addClass("is-invalid");
        loadInputExercise();
    }
    function removeTacticalboard(tacticalboardId, lightgalleryId) {
        $("#" + tacticalboardId).remove();
        $("#" + lightgalleryId).remove();
        loadTacticalBoards();
    }
    function loadTacticalBoards() {
        let tacticalboardfiles = $(".testclass");
        $("#lightgallery").html('');
        for (var i = 0; i < tacticalboardfiles.length; i++) {
            let tacticalboardId = "Tacticalboards_" + i + "_";
            tacticalboardfiles[i].id = tacticalboardId;
            tacticalboardfiles[i].name = "Tacticalboards[" + i + "]";
            let lightgalleryId = tacticalboardId + "glr";
            let fileUrl = tacticalboardfiles[i].value;
            $("#lightgallery").append("<div id='" + lightgalleryId + "' class='col-lg-3 col-md-6 file-image' data-responsive='" + fileUrl + "'><a href='javascript:void(0);'><ul class='icons'><li><button type='button' onclick=\"Exercises.removeTacticalboard('" + tacticalboardId + "', '" + lightgalleryId + "')\" class='btn btn-icon btn-danger'><i class='fe fe-trash'></i></button></li></ul><img class='img-fluid  mb-2 br-7' src='" + fileUrl + "' alt='banner image'></a></div>");
        }
    }
    return {
        init: init,
        addExercise: addExercise,
        updateExercise: updateExercise,
        loadInputExercise: loadInputExercise,
        loadAddExercise: loadAddExercise,
        loadEditExercise: loadEditExercise,
        loadConfirmDeleteExercise: loadConfirmDeleteExercise,
        reloadExercises: reloadExercises,
        showExerciseModal: showExerciseModal,
        removeTacticalboard: removeTacticalboard,
        loadTacticalBoards: loadTacticalBoards
        //getCreatedBy: getCreatedBy,
        //loadAddExercise: loadAddExercise
    }
})();
$(document).ready(function () {
    //$("#page-loader").fadeOut("fast");
    Exercises.init();

});

$(document).on('focus', '.dataTables_filter input', function () {

    $(this).unbind().bind('keyup', function (e) {
        if (e.keyCode === 13) {
            exercisesTable.search(this.value).draw();
        }
    });

});