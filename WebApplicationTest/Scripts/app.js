$(document).ready(function () {
    $("#Cliente_Nome").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '@Url.Action("Index", "Propostas")',
                datatype: "json",
                data: {
                    term: request.term
                },
                success: function (data) {
                    response($.map(data, function (val, item) {
                        return {
                            label: val.Cliente.Nome,
                            value: val.Cliente.Nome,
                            customerId: val.Cliente.Id
                        }
                    }))
                }
            })
        },
        select: function (event, ui) {
            $("#CustomerID").val(ui.item.Cliente.Id);
        }
    });
});