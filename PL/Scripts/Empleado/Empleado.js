

$(document).ready(function () {
    GetAll();

});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:9943/api/empleado/GetAll',
        success: function (result) {
            $('#tblEmpleado tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a class="glyphicon glyphicon-edit" href="#" onclick="GetById(' + empleado.Id_NumEmp + ')">'

                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='hidden'>" + empleado.Id_NumEmp + "</td>"

                    + "<td class='text-center'>" + empleado.Nombre + " " + empleado.Apellido_Paterno + " " + empleado.Apellido_Materno + "</td>"
                    + "<td class='hidden'>" + empleado.Puesto.IdPuesto + "</td>"
                    + "<td class='text-center'>" + empleado.Puesto.Nombre + "</td>"


                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.Id_NumEmp + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";


                $("#tblEmpleado tbody").append(filas);

                
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function PuestoGetAll() {
    $("#ddlEstados").empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:9943/api/puesto/GetAll',
        success: function (result) {
            $("#ddlIdPuesto").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, puesto) {
                $("#ddlIdPuesto").append('<option value="'
                    + puesto.IdPuesto + '">'
                    + puesto.Nombre + '</option>');
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);

        }
    });
}

function Add(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:9943/api/empleado/add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#ModalForm').modal('hide');
            $('#myModal').modal();

            PuestoGetAll();

        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function ShowModal() {

    $('#ModalForm').modal('show');

    PuestoGetAll();

    InitializeControls();
    $('#lblTitulo').modal('Agregar Empleado');

}

function Guardar() {

    var empleado = {
        Id_NumEmp: $('#txtId_NumEmp').val(),
        Nombre: $('#txtNombre').val(),
        Apellido_Paterno: $('#txtApellido_Paterno').val(),
        Apellido_Materno: $('#txtApellido_Materno').val(),
        Puesto: {
            IdPuesto: $('#ddlIdPuesto').val()
        }
    }
    if ($('#txtId_NumEmp').val() == "") {
        Add(empleado);
    }
    else {
        Update(empleado);
    }

}

function Eliminar(Id_NumEmp) {

    if (confirm("¿Estas seguro de eliminar al Empleado seleccionado?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:9943/api/empleado/delete/' + Id_NumEmp,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

function InitializeControls() {

    $('#txtId_NumEmp').val('');
    $('#txtNombre').val('');
    $('#txtApellido_Paterno').val('');
    $('#txtApellido_Materno').val('');
    $('#ddlIdPuesto').val(0);
    $('#ModalForm').modal('show');

}

function GetById(Id_NumEmp) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:9943/api/empleado/getById/' + Id_NumEmp,
        success: function (result) {
            $('#txtId_NumEmp').val(result.Object.Id_NumEmp);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellido_Paterno').val(result.Object.Apellido_Paterno);
            $('#txtApellido_Materno').val(result.Object.Apellido_Materno);
            $('#ddlIdPuesto').val(result.Object.Puesto.IdPuesto);


            $('#ModalForm').modal('show');
            $('#lblTitulo').modal('Modificar Empleado');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }

    });

} 

function Update(empleado) {
    var empleado = {
        Id_NumEmp: $('#txtId_NumEmp').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellido_Paterno').val(),
        ApellidoMaterno: $('#txtApellido_Materno').val(),
        Puesto: {
            IdPuesto: $('#ddlIdPuesto').val()
        }
    }
    $.ajax({
        type: 'PUT',
        url: 'http://localhost:9943/api/empleado/update/',
        dataType: 'json',
        data: empleado,
        success: function (result) {

            $('#ModalForm').modal('hide');
            $('#myModal').modal();

            PuestoGetAll();
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

