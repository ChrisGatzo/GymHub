(function () {

    var injectParams = ["$location"];

    var menuHighlighter = function ($location) {

        var link = function (scope, element) {
            function setActive() {
                var path = $location.path();
                var className = scope.highlightClassName || "active";

                if (path) {
                    angular.forEach(element.find("li"), function (li) {
                        var anchor = li.querySelector("a");
                        //Get href from href attribute or data-href in cases where href isn't used (such as login)
                        var href = (anchor && anchor.href) ? anchor.href :
                            anchor.getAttribute("data-href").replace("#", "");
                        //Get value after hash
                        var trimmedHref = href.substr(href.indexOf("#/") + 1, href.length);
                        //Convert path to same length as trimmedHref
                        var basePath = path.substr(0, trimmedHref.length);

                        //See if trimmedHref and basePath match. If so, then highlight that item
                        if (trimmedHref === basePath) {
                            angular.element(li).addClass(className);
                        } else {
                            angular.element(li).removeClass(className);
                        }
                    });
                }
            }

            setActive();
        }

        return {
            restrict: "A",
            scope: {
                highlightClassName: "@"
            },
            link: link
        }

    };

    menuHighlighter.$inject = injectParams;

    angular.module("gymHubApp").directive("menuHighlighter", menuHighlighter);

}());