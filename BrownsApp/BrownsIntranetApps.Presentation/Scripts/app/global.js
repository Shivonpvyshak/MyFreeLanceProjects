//Need to install the Nuget package  jquery.ui.combined for drag and drop
$(function () {
    //Phonenumber
    $.formatPhoneNumber('phoneNumber');
    //-----------------------------------------------------------------------------------
});

$.formatPhoneNumber = function (classname) {
    var control = $("." + classname);
    control.attr('maxlength', '10');
    control.focusout(function () {
        this.value = this.value.replace(/(\d{3})\-?(\d{3})\-?(\d{4})/, '$1-$2-$3');

    });
}

//Validate DataType - int, decimal and set the proper error message on given errSpanClass

$.validateDataTypeOnKeyPressEvent = function (event, dataType, errorSpanClass) {
    var preventDefaultFlag = false;
    var val = event.key;
    var regex;

    if (dataType === "int") {
        //Regex for numeric validation
        regex = /^[-+]?\d+$/;

        if (regex.test(val)) {
            $("." + errorSpanClass).text("");
        }
        else {
            preventDefaultFlag = true;
            $("." + errorSpanClass).text("Please enter a valid numeric value");
        }

        if (event.shiftKey == true) {
            event.preventDefault();
            $("." + errorSpanClass).text("Please enter a valid numeric value");
        }
    }
    else if (dataType === "double" || dataType === "decimal") {
        val = event.key;

        //Regex for decimal validation
        regex = /^\d*\.?\d*$/;

        if (regex.test(val)) {
            $("." + errorSpanClass).text("");
        }
        else {
            preventDefaultFlag = true;
            $("." + errorSpanClass).text("Please enter a valid decimal value");
        }

        //Prevent shift key press
        if (event.shiftKey == true) {
            preventDefaultFlag = true;
            $("." + errorSpanClass).text("Please enter a valid decimal value");
        }

        //prevent the duplicate entry of "."
        if ($(event.target).val().indexOf(".") !== -1 && (event.keyCode === 190 | event.keyCode === 110)) {
            $("." + errorSpanClass).text("You have already entered a decimal point");
            preventDefaultFlag = true;
        }
    }

    //Common Key stroke Validations
    // Allow the below keys
    // 8 - Back Space,9 - Tab, 35 - end, 36 - Home, 37 - Left Arrow, 39 - right Arrow, 46 - delete
    if (event.keyCode === 8 || event.keyCode === 9 || event.keyCode === 36 || event.keyCode === 35 || event.keyCode === 37 || event.keyCode === 39 || event.keyCode === 46) {
        $("." + errorSpanClass).text("");
        preventDefaultFlag = false;
    }

    if (preventDefaultFlag) {
        event.preventDefault();
    }
}

//Validate for proper email and set the proper error message on given errSpanClass
$.validateEmailId = function (event,errorSpanClass) {
    var value = event.key;
    if (value === "")
        return;
    var regex =
        /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    if (!regex.test(value)) {
        $("." + errorSpanClass).text("Invalid Email Id");
        event.preventDefault();
        return;
    } else {
        $("." + errorSpanClass).text("");
    }
}