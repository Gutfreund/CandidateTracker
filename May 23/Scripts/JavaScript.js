$(() => {
    $("#confirm-button").on('click', function () {
        const candidateId = $(this).data("id");
        $.post('/Home/Confirm', { candidateId: candidateId }, function () {
            updateStatus();
        });
    });

    $("#refuse-button").on('click', function () {
        const candidateId = $(this).data("id");
        $.post('/Home/Refuse', { candidateId: candidateId }, function () {
            updateStatus();
        });
    });

    function updateStatus() {
        $.get("/Home/UpdateStatus", function (status) {
            $("#PendingCount").text(status.Pending);
            $("#ConfirmedCount").text(status.Confirmed);
            $("#RefusedCount").text(status.Refused);
        });
        $("#confirm-button").hide();
        $("#refuse-button").hide();
    }

    $(".btn-success").on('click', function () {
        $(".notes").toggle();
    });
});

