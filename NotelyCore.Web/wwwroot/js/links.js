function addNewLink() {
    $.confirm({
        title: 'Add Super Link!',
        content: '' +
            '<form action="" class="formName">' +
            '<div class="form-group">' +
            '<input type="text" placeholder="Url" class="url form-control" required />' +
            '</br>'+
            '<input type="text" placeholder="Description" class="description form-control" />' +
            '</div>' +
            '</form>',
        buttons: {
            formSubmit: {
                text: 'Submit',
                btnClass: 'btn-blue',
                action: function () {
                    var url = this.$content.find('.url').val();
                    var desc = this.$content.find('.description').val();

                    if (!url) {
                        $.alert('You must provide a url');
                        return false;

                    }
                    console.log("add new link accepted");

                    var options = {};
                    options.url = "/Links/Index?handler=AddLink";
                    options.type = "POST";

                    options.data = { url: url , description: desc};

                    options.beforeSend = function (xhr) {
                        xhr.setRequestHeader("MY-XSRF-TOKEN",
                            $('input:hidden[name="__RequestVerificationToken"]').val());
                    };
                    options.success = function (msg) {
                        console.log(msg);
                        window.location.reload();
                    };
                    options.error = function (err) {
                        console.log("Error while making Ajax call!", err);
                    };
                    $.ajax(options);
                }
            },
            cancel: function () {
                //close
            },
        },
        onContentReady: function () {
            // bind to events
            var jc = this;
            this.$content.find('form').on('submit', function (e) {
                // if the user submits the form by pressing enter in the field.
                e.preventDefault();
                jc.$$formSubmit.trigger('click'); // reference the button and click it
            });
        }
    });
}

function editLink(e) {
    $.confirm({
        title: 'Edit Super Link!',
        content: '' +
            '<form action="" class="formName">' +
            '<div class="form-group">' +
            `<input type="text" placeholder="Url" class="url form-control" required />` +
            '</br>' +
            '<input type="text" placeholder="Description" class="description form-control" />' +
            '</div>' +
            '</form>',
        buttons: {
            formSubmit: {
                text: 'Submit',
                btnClass: 'btn-blue',
                action: function () {
                    var url = this.$content.find('.url').val();
                    var desc = this.$content.find('.description').val();

                    if (!url) {
                        $.alert('You must provide a url');
                        return false;

                    }
                    console.log("add new link accepted");

                    var options = {};
                    options.url = "/Links/Index?handler=AddLink";
                    options.type = "POST";

                    options.data = { url: url, description: desc };

                    options.beforeSend = function (xhr) {
                        xhr.setRequestHeader("MY-XSRF-TOKEN",
                            $('input:hidden[name="__RequestVerificationToken"]').val());
                    };
                    options.success = function (msg) {
                        console.log(msg);
                        window.location.reload();
                    };
                    options.error = function (err) {
                        console.log("Error while making Ajax call!", err);
                    };
                    $.ajax(options);
                }
            },
            cancel: function () {
                //close
            },
        },
        onContentReady: function () {
            // bind to events
            var jc = this;
            this.$content.find('form').on('submit', function (e) {
                // if the user submits the form by pressing enter in the field.
                e.preventDefault();
                jc.$$formSubmit.trigger('click'); // reference the button and click it
            });
        }
    });
}
