// Filtering logic
const filterInput = document.getElementById('filterInput');
const tableRows = document.querySelectorAll('.table-sortable tbody tr');

filterInput.addEventListener('input', function () {
    const searchText = filterInput.value.toLowerCase();

    tableRows.forEach(function (row) {
        const rowData = row.textContent.toLowerCase();

        if (rowData.includes(searchText)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
});

// Custom filtering logic for specific columns
const birthdayColumnIndex = 1; // Index of the "Birthday" column

function filterByAge(age) {
    tableRows.forEach(function (row) {
        const birthdayCell = row.cells[birthdayColumnIndex];
        const birthday = new Date(birthdayCell.textContent.trim());
        const today = new Date();
        const ageDifference = today.getFullYear() - birthday.getFullYear();

        if (ageDifference >= age) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
}