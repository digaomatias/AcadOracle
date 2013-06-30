$(document).ready(function () {
    $('#CursoId').change(function () {
        retrieveDisciplinas();
    });
    
    retrieveDisciplinas();
});

function retrieveDisciplinas() {
    var req = getCursoId();
    var json = JSON.stringify(req);

    $.ajax({
        type: 'POST',
        url: '/Disciplina/GetDisciplinas',
        dataType: 'json',
        data: json,
        contentType: 'application/json; charset=utf-8',
        success: populaDisciplinas
    });
}


function getCursoId() {
    var id = $("#CursoId").val();
    if (id == null)
        id = 0;
    var disciplinaId = $("#Id").val();

    // poor man's validation
    return { CursoId: parseInt(id), DisciplinaId: parseInt(disciplinaId) };
}

function populaDisciplinas(data) {
    var markup = '';
    var disciplinaId = $("#Id").val();
    for (var x = 0; x < data.Disciplinas.length; x++) {
        if ((disciplinaId == "" || disciplinaId == null) || disciplinaId != data.Disciplinas[x].Value) {
            markup += '<option value="' + data.Disciplinas[x].Value + '">' + data.Disciplinas[x].Key + '</option>';
        }
    }
    $("#PreRequisitosId").html(markup).show();

    $.each(data.PreRequisitosId, function(index, val) {
        $("#PreRequisitosId option[value='" + val + "']").attr("selected", true);
    });
    
}