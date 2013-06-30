$(document).ready(function () {
    $('#btnReload').click(function () {

        var req = getDisciplinasRequestModel();
        
        $.ajax({
            type: 'POST',
            url: '/OracleService/GetDisciplinasPendentes',
            dataType: 'json',
            data: req,
            contentType: 'application/json; charset=utf-8',
            success: populateCursadas
        });
    });
});

function getDisciplinasRequestModel() {
    var cursadas = [];
    $("#CursadasId :selected").each(function (i, selected) {
        cursadas[i] = $(selected).val();
    });

    var cursoId = $("#CursoId").val();

    // poor man's validation
    return { CursoId: cursoId, CursadasId: cursadas };
}

function populatePreRequisitos(data) {
    var markup = '';
    for (var x = 0; x < data.Disciplinas.length; x++) {
        markup += '<option value="' + data.Disciplinas[x].Value + '">' + data.Disciplinas[x].Key + '</option>';
    }
    $("#CursadasId").html(markup).show();
    $("#CursadasId").val(data.CursadasId);

    $("#RestricaoDisciplinasId option").remove();
    $("#CursadasId :not(:selected)").clone().each(function (i, opt) { $("#RestricaoDisciplinasId").append(opt); });
}

function populateCursadas(data) {
    var markup = '';
    for (var x = 0; x < data.Disciplinas.length; x++) {
        markup += '<option value="' + data.Disciplinas[x].Value + '">' + data.Disciplinas[x].Key + '</option>';
    }
    $("#CursadasId").html(markup).show();
    $("#CursadasId").val(data.CursadasId);

    $("#RestricaoDisciplinasId option").remove();
    $("#CursadasId :not(:selected)").clone().each(function (i, opt) { $("#RestricaoDisciplinasId").append(opt); });
}

function showNoResultsFoundMessage() {
    $( "#dialog-message" ).dialog({
        modal: true,
        buttons: {
            Ok: function() {
                $( this ).dialog( "close" );
            }
        }
    });
}