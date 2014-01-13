///<reference path="typings/jquery/jquery.d.ts"/>
var RedisAB;
(function (RedisAB) {
    var ABLogger = (function () {
        function ABLogger() {
        }
        ABLogger.prototype.LogSuccess = function (viewName, actionName) {
            $.post("/ABSuccessController", { viewName: viewName, actionName: actionName });
        };
        return ABLogger;
    })();
    RedisAB.ABLogger = ABLogger;
})(RedisAB || (RedisAB = {}));

$(function () {
    $("a").click(function () {
        var viewName = $(this).attr("data-view-name");
        var actionName = $(this).attr("data-action-name");
        new RedisAB.ABLogger().LogSuccess(viewName, actionName);
    });
});
//# sourceMappingURL=ABLogger.js.map
