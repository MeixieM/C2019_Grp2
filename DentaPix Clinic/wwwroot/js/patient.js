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
            {
                "data": "patientId",
                "render": function (data) {
                    return `
                            <div class="w-80" role="group">
								<a href="/Admin/Patient/Upsert?id=${data}" class="badge rounded-pill bg-primary"><i class="bi bi-pencil-square"></i></a>
								<a onClick=Delete('/Admin/Patient/Delete/${data}') 
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