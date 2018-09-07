/* 
    // BF 10/2/2015 - handle nav menu differently for touch and mouse interactions

    <!-- NavMenu html cross-section -->
    <ul id="mainNavBar">
        <li class="dropdown">
            <ul class="dropdown-menu">
                <li>
                    <a href="page1.com">Page 1</a>
                </li>
                <li>
                    <a href="page2.com">Page 2</a>
                </li>
                etc.
            </ul>
        </li>
        etc.
    </ul>
*/

var NavBarToggle = (function () {
    var _this = this,
        eventTarget;

    _this.dropdownContainsMoreThanXItems = function (numItems) {
        return ($($(eventTarget).siblings().children()).length > numItems);
    };

    _this.showFirstMenuItem = function (show) {
        if (show) {
            $($(eventTarget).siblings().children()[0]).show();
        } else {
            $($(eventTarget).siblings().children()[0]).hide();
        }
    };

    _this.toggleMenu = function (event, inputType) {
        eventTarget = event.target;

        if (inputType === 'hover') {

            if (_this.dropdownContainsMoreThanXItems(1)) {
                _this.showFirstMenuItem(false);
                $(eventTarget).dropdown('toggle');
            }

        } else {

            if (_this.dropdownContainsMoreThanXItems(0)) {
                _this.showFirstMenuItem(true);
            }

            $(eventTarget).dropdown('toggle');
        }

    };

    // Set event listener functions for each section dropdown of items    
    $('#mainNavBar .dropdown').each(function (index, element) {

        // User hovers over navbar dropdown
        $(element).hover(function (event) {
            // Go to URL if top-level menu item is clicked
            $(event.target).click(function () {
                location.replace(event.target);
            });

            // Construct and display rest of dropdown menu using logic for hover
            _this.toggleMenu(event, 'hover');
        });

        if (Modernizr.touchevents) {
            // Setup all dropdowns to work with touch
            $(element).children('.dropdown-menu').each(function (index, element) {

                // User touches the navbar section menu
                $(element).siblings('.dropdown-toggle').on('touchstart', function (event) {

                    // Don't go to URL of parent menu item if clicked
                    event.preventDefault();

                    // Open and construct menu using logic for touch
                    _this.toggleMenu(event, 'touch');
                });
            });
        }
    });

})();

$(".dropdown-menu").mouseleave(function () {
    $(".dropdown").removeClass("open");
});