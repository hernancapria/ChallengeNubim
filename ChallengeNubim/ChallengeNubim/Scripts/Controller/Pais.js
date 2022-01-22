$(document).ready(function () {

    // se crea la variable dataTable y se inicializara en el metodo IntializeDataTable
    var dataTable;
    IntializeDataTable();


    $('#tblPaises').on('draw.dt', function () {
        //alert('Table redrawn');
    });



});

// obtiene los datos del item por su id y los asigna a los controles
function GetById(id) {
    $.ajax({
        url: "/Pais1/AddOrEdit/" + id,
        method: 'get'
    }).done(function (response) {
        $('#id').val(response.id);
        $('#descripcion').val(response.descripcion);
        
        $('#modalAgregarItem').modal({
            show: 'true'
        });
    });
}

function OpenDeleteItem(id) {
    $("#hdnEliminarItem").val(id);
    $('#modalBorrarItem').modal({
        show: 'true'
    });
}
function DeleteItem() {
    $.ajax({
        url: "/Pais1/Delete/" + $("#hdnEliminarItem").val(),
        method: 'DELETE',
        success: function (response) {
            $('#modalBorrarItem').modal('hide');
            dataTable.ajax.reload();
            $.notify("Operacion exitosa", "success");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            $.notify("Se produjo un error", "error");
        }
    });

    return false;
}

// manda los datos al servidor y luego de que se procesan se actualiza el dataTable
function SubmitForm(form) {
    //var frm = $("#frm");
    //var frmValid = frm.validate();
    //if (frmValid.valid() == false)
    //    return false;

    var formSerialized = $(form).serialize();

    $.ajax({
        type: "POST",
        url: form.action,
        data: formSerialized,
        success: function (response) {
            $('#modalAgregarItem').modal('hide');
            dataTable.ajax.reload();
            $.notify("Operacion exitosa", "success");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            $.notify("Se produjo un error", "error");
        }
    });

    return false;




}

// inicializa el dataTable
function IntializeDataTable() {

    // https://datatables.net/
    dataTable = $("#tblPaises").DataTable({
        ajax: {
            "url": "/Pais1/GetData",
            "type": "GET",
            "datatype": "json"
        },
        columns: [

            { "data": "descripcion" },
            {
                "data": "id", "render": function (data) {
                    var buttons = "<a class='btn btn-default' data-target='#modalAgregarItem' onClick='GetById(" + data + ");'>Editar</a>&nbsp;";
                    buttons = buttons + "<a class='btn btn-default' data-target='#modalBorrarItem' onClick='OpenDeleteItem(" + data + ")';>Eliminar</a>";
                    return buttons;
                }
            }
        ]
    });
}