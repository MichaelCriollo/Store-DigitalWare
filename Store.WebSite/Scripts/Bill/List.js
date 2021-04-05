function DeleteBill(idBill) {
    swal({
        type: 'warning',
        text: '¿Está seguro de eliminar la factura?',
        showCancelButton: true,
        confirmButtonText: 'Si, Eliminar!',
        cancelButtonText: 'No, Cancelar!',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger mr-3',
        buttonsStyling: false,
        reverseButtons: true
    }).then((result) => {
        if (result) {
            $.ajax({
                type: "POST",
                url: $("#HdnUrlDeleteBill").val(),
                data: JSON.stringify({ IdBill: idBill }),
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                console.log(response)
                swal({
                    type: response.type,
                    text: response.message,
                    title: response.title,
                    confirmButtonText: 'Aceptar',
                    confirmButtonClass: 'btn btn-primary',
                }).then(function () {
                    if (response.type == "success") {
                        window.location.href = $("#HdnUrlList").val()
                    }
                });
            })
        }
    })
}