function loadCurrentTaskModalAjax() {
    let taskGuid = arguments[0];
    let targetId = arguments[1];
    let id = arguments[2];
    $.ajax({
        url: "../Task/GetCurrentTaskById",
        type: "GET",
        datatype: "html",
        data: { taskGuid },
        success: function (response) {
            $('#currentTaskPartialViewContainer').html(response);
            if (`taskContainer[${id}]` === targetId) {
                $('#currentTaskModal').modal('show');
            }
        }
    })
}