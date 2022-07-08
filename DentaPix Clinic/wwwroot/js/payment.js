var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Payment/GetAll"
        },

        "columns": [
            {
                "data": "patient.firstName", "width": "3%",
                "render": function (data, type, row) {
                    return data ;
                }
            },
            {
                "data": "patient.lastName", "width": "8%",
                "render": function (data, type, row) {
                    return data;
                }
            },
            { "data": "patient.phoneNo", "width": "15%" },

            {
                "data": "date",
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                }
            },
            { "data": "description", "width": "15%" },
            { "data": "method", "width": "15%" },
            { "data": "amount", "width": "15%" },
            { "data": "paymentStatus", "width": "15%" },
            {
                "data": "paymentId",
                "render": function (data) {
                    return `
                            <div class="w-80" role="group">
								<a href="/Admin/Payment/Upsert?id=${data}" class="badge rounded-pill bg-primary"><i class="bi bi-pencil-square"></i></a>
								<a onClick=Delete('/Admin/Payment/Delete/${data}')
                                class="badge rounded-pill bg-danger"><i class="bi bi-trash"></i></a>
							</div>
                           `
                },
                "width": "15% "
            }

        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}    