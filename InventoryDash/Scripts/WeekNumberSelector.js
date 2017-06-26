$(document).ready(function () {
    //Set the date and week select elements to current values


    $("#yearSelector").change(function () {
        //Get the value of the year selected.
        $()
        //Determine the list of weeks, Monday to Sunday for the year

        //Populate the select element with the list.
    });

    function getWeekListForYear (year) {

    }

    Date.prototype.getWeek = function () {
        var date = new Date(this.getTime());
        date.setHours(0, 0, 0, 0);
        // Thursday in current week decides the year.
        date.setDate(date.getDate() + 3 - (date.getDay() + 6) % 7);
        // January 4 is always in week 1.
        var week1 = new Date(date.getFullYear(), 0, 4);
        // Adjust to Thursday in week 1 and count number of weeks from date to week1.
        return 1 + Math.round(((date.getTime() - week1.getTime()) / 86400000
            - 3 + (week1.getDay() + 6) % 7) / 7);
    }

});