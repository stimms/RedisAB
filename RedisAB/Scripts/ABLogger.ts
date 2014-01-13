///<reference path="typings/jquery/jquery.d.ts"/>

module RedisAB {
    export class ABLogger {
        LogSuccess(viewName: string, actionName: string) {
            $.ajax({
                url: "/ABSuccess",
                data: { viewName: viewName, actionName: actionName },
                async: false,
                type: "POST"
            });
        }
    }
}

$(function() {
    $("a[data-view-name][data-action-name]").on("click", function () {
        var viewName = $(this).attr("data-view-name");
        var actionName = $(this).attr("data-action-name");
        new RedisAB.ABLogger().LogSuccess(viewName, actionName);
    });
});