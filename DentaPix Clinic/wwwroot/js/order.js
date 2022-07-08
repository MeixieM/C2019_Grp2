var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed")) {
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved")) {
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },

        "columns": [
            { "data": "id", "width": "5%" },

            {
                "data": "firstName", "width": "20%",
                "render": function (data, type, row) {
                    return data + ' ' + row["lastName"];
                }
            },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "address", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="w-80" role="group">
								<a href="/Admin/Order/Details?orderId=${data}" class="badge rounded-pill bg-primary"><i class="bi bi-pencil-square"></i></a>

							</div>
                           `
                },
                "width": "5% "
            }

        ]
    });
}