$(document).ready(function () {
    if ($('#Tbl').length) {
        loadDataTable();
    }
});

function loadDataTable() {
    if ($.fn.DataTable.isDataTable('#Tbl')) {
        $('#Tbl').DataTable().clear().destroy();
    }
    $('#Tbl').DataTable({
        "ajax": { url: '/Home/getall' },
        "columns": [
            { data: 'uploaderName', "width": "15%" },
            { data: 'subject', "width": "15%" },
            { data: 'group', "width": "15%" },
            { data: 'year', "width": "15%" },
            { data: 'url',
                "render": function (data) {
                    return `<div>
                     <a href ="${data}" target="_blank" >view</a>
                  </div>
                    `
                },
                "width": "15%"
            }
        ]
    });
}

// Refresh DataTable data after an AJAX operation
//function refreshTable() {
//    if ($.fn.DataTable.isDataTable('#Tbl')) {
//        $('#Tbl').DataTable().ajax.reload();
//    }
//}
//$(document).ready(function () {
//    $('#Tbl').DataTable({
//        responsive: true,
//        autoWidth: false

//    });
//});

function showSection(id) {
    const sections = ['main', 'approved', 'delete', 'edit', 'images','Feedback'];
    sections.forEach(sec => {
        document.getElementById(sec + '-section').classList.add('d-none');
    });
    document.getElementById(id + '-section').classList.remove('d-none');

    const links = document.querySelectorAll('#menu .nav-link');
    links.forEach(link => link.classList.remove('active'));
    event.target.classList.add('active');
}

console.log("srujan good");




function toggleMenu() {
    const menu = document.getElementById('mobileMenu');
    if (menu.style.display === 'flex') {
        menu.style.display = 'none';
    } else {
        menu.style.display = 'flex';
    }
}






