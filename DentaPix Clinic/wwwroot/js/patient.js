var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Patient/GetAll"
        },
        "columns": [
            {
                "data": "firstName", "width": "20%",
                "render": function (data, type, row) {
                    return data + ' ' + row["lastName"] +'<br>' + row["email"];
                }
            },
        
                    { "data": "phoneNo", "width": "15%" },
                    { "data": "address", "width": "15%" },
                    { "data": "registeredDate", "width": "15%" },

            ]
        });
        }

       