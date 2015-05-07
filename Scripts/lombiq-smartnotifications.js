(function ($) {
    $.extend({
        smartNotifications: {
            removeMessagesContainerIfNecessary: function () {
                if ($(".zone-messages").is(":empty") || $(".zone-messages :not(:hidden)").length == 0) {
                    $("#messages").remove();
                }
            }
        }
    });
})(jQuery);