$(document).ready(function () {
    
    $("#IDMedicoExcluir").click(function () {
        $.ajax({
            url: "/Medicos/Excluir",
            data: {
                IDMedico: $("#idMedicoEX").val(),               
            },
            dataType: "json",
            type: "GET",
            async: true,
           
          
        });
    });
});