$(document).ready(function () {
    $('#productoForm').on('submit', function (event) {
        var isValid = true;

        // Validar Nombre
        if ($('#Nombre').val().trim() === '') {
            alert('El nombre es obligatorio');
            isValid = false;
        }

        // Validar Descripción
        if ($('#Descripcion').val().trim() === '') {
            alert('La descripción es obligatoria');
            isValid = false;
        }

        // Validar Precio
        var precio = $('#Precio').val().trim();
        if (precio === '' || isNaN(precio) || parseFloat(precio) <= 0) {
            alert('El precio debe ser un número mayor que 0');
            isValid = false;
        }

        // Validar Stock
        var stock = $('#Stock').val().trim();
        if (stock === '' || isNaN(stock) || parseInt(stock) < 0) {
            alert('El stock debe ser un número mayor o igual a 0');
            isValid = false;
        }

        // Si no es válido, prevenimos el envío del formulario
        if (!isValid) {
            event.preventDefault();
        }
    });
});