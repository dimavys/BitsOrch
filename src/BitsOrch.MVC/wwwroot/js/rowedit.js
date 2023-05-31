const editableCells = document.querySelectorAll('.editable');

editableCells.forEach(function (cell) {
    cell.addEventListener('click', function () {
        cell.contentEditable = 'true';
        cell.focus();
    });

    cell.addEventListener('blur', function () {
        cell.contentEditable = 'false';
    });
});