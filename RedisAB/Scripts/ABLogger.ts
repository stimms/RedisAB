///<reference path="typings/jquery/jquery.d.ts"/>

module RedisAB {
    export class ABLogger {
        LogSuccess(viewName: string, actionName: string) { $.post("/ABSuccessController", { viewName: viewName, actionName: actionName }); }
    }
}

$(function() {
    $("a").click(function () {
        var viewName = $(this).attr("data-view-name");
        var actionName = $(this).attr("data-action-name");
        new RedisAB.ABLogger().LogSuccess(viewName, actionName);
    });
});