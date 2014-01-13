///<reference path="typings/jquery/jquery.d.ts"/>
var RedisAB;
(function (RedisAB) {
    var ABLogger = (function () {
        function ABLogger() {
        }
        ABLogger.prototype.LogSuccess = function (viewName, actionName) {
            $.ajax({
                url: "/ABSuccess",
                data: { viewName: viewName, actionName: actionName },
                async: false,
                type: "POST"
            });
        };
        return ABLogger;
    })();
    RedisAB.ABLogger = ABLogger;
})(RedisAB || (RedisAB = {}));

$(function () {
    $("a[data-view-name][data-action-name]").on("click", function () {
        var viewName = $(this).attr("data-view-name");
        var actionName = $(this).attr("data-action-name");
        new RedisAB.ABLogger().LogSuccess(viewName, actionName);
    });
});
//# sourceMappingURL=ABLogger.js.map
