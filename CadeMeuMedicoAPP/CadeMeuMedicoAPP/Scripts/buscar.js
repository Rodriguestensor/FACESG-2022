$(document).ready(function () {
   
    $("#menuHome").addClass("active");

    $("#pesquisar").on("click", function () {

        var pesquisa = { idCidade: $("#cidade").val(), idEspecialidade: $("#especialidade").val() };

        $.getJSON("/Home/Pesquisar", pesquisa, function (data) {

            var resultados = $("#resultados");

            resultados.empty();

            if (data.length == 0) {
                resultados.append('<div class="alert alert-danger">Nenhum médico encontrado :(</div>');
                return false;
            }

            for (var i = 0; i < data.length; {
                resultados.append('<div class="col-sm-6 col-md-4"><div class="thumbnail"><div class="caption"><h3>' + data[i].Nome + '</h3><p>CRM: ' + data[i].Crm + '</p></div><div></div>');
            }

                });
        return false;
    });
    function Limpar() {
        var pesquisa = { idCidade: $("#cidade").val(), idEspecialidade: $("#especialidade").val() };

        $.getJSON("/Home/Pesquisar", pesquisa, function (data) {

            var resultados = $("#resultados");

            resultados.empty();

            if (data.length == 0) {
                resultados.append('<div class="alert alert-danger">Nenhum médico encontrado :(</div>');
                return false;
            }

            for (var i = 0; i < data.length; {
                resultados.append('<div class="col-sm-6 col-md-4"><div class="thumbnail"><div class="caption"><h3>' + data[i].Nome + '</h3><p>CRM: ' + data[i].Crm + '</p></div><div></div>');
            }

                });
        return false;

    }

});
  
        
  

