function deleteNote(e) {
    $.confirm({
        title: 'Delete the note?',
        content: 'Are you sure? There is no going back!',
        buttons: {
            confirm: function () {
                console.log("delete accepted");
                var noteId = e.getAttribute("data-note-id");
                console.log(noteId);

                var options = {};
                options.url = "/Index?handler=NoteItemDelete";
                options.type = "POST";

                options.data = { noteId: noteId };

                options.beforeSend = function (xhr) {
                    xhr.setRequestHeader("MY-XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                };
                options.success = function (msg) {
                    console.log(msg);
                    window.location.reload();
                };
                options.error = function () {
                    console.log("Error while making Ajax call!");
                };
                $.ajax(options);
            },
            cancel: function () {

            }
        }
    });
}


