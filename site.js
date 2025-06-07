//document.getElementById('apply-filters').addEventListener('click', function () {
//    console.log("Filters applied");
//});

document.getElementById('uploadForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const formData = new FormData();
    formData.append("name", document.getElementById("name").value);
    formData.append("subject", document.getElementById("subject").value);
    formData.append("year", document.getElementById("year").value);
    formData.append("group", document.getElementById("group").value);
    formData.append("file", document.getElementById("file").files[0]);

    console.log("Uploading Question Paper...");
});
