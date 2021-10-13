var showOptionsOnHover = function () {
    let id = arguments[0];
    document.getElementById(`priorityDropdown[${id}]`).style.visibility = 'visible';
}

var hideOptionsOffHover = function () {
    let id = arguments[0];
    document.getElementById(`priorityDropdown[${id}]`).style.visibility = 'hidden';
}

var functionsShow = [];
var functionsHide = [];

$(document).ready(function () {
    var elements = document.getElementsByName('taskContainer');

    for (var i = 0; i < elements.length; i++) {
        let index = i;
        var showFunction = function () { showOptionsOnHover(index) };
        var hideFunction = function () { hideOptionsOffHover(index) };
        functionsShow.push(showFunction);
        functionsHide.push(hideFunction);

        elements[i].addEventListener('mouseover', showFunction);
        elements[i].addEventListener('mouseout', hideFunction);
    }
});

function lockDropdown() {
    let containerId = arguments[0];
    let dropdownId = arguments[1];
    let dropdownOptionsId = arguments[2];
    let idNumber = arguments[3];

    document.getElementById(containerId).removeEventListener('mouseout', functionsHide[idNumber]);
    document.getElementById(containerId).focus();

    document.getElementById(dropdownId).style.visibility = 'visible';

    var elements = document.getElementsByName('taskContainer');
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.pointerEvents = 'none';
    }
    document.getElementById(dropdownOptionsId).style.pointerEvents = 'auto';

    $(document).click(function () {
        unlockDropdown(containerId, dropdownId, dropdownOptionsId, idNumber);
    });
}

function unlockDropdown() {
    let containerId = arguments[0];
    let dropdownId = arguments[1];
    let dropdownOptionsId = arguments[2];
    let idNumber = arguments[3];

    document.getElementById(containerId).addEventListener('mouseout', functionsHide[idNumber]);
    document.getElementById(containerId).blur();

    document.getElementById(dropdownId).style.visibility = 'hidden';

    var elements = document.getElementsByName('taskContainer');
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.pointerEvents = 'auto';
    }
    document.getElementById(dropdownOptionsId).style.pointerEvents = 'none';
}