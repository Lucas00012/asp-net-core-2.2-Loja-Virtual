$(document).ready(function () {
    AjaxCalcularFreteFinal();
    AnalisaCookieCEP();
    TipoFreteClick();

})

function AjaxCalcularFreteFinal() {
    $('input[name ="endereco"]').click(function () {

        if (request != undefined) request.abort();

        reiniciaCampoResultado();
        ocultaMsgErro();
        reiniciarCampos();
        imgSetLoad();

        var cep =  $(this).parent().find("input")[0].value.replace("-","");

        var request=$.ajax({
            
            timeout:180000,
            type: "GET",
            async:true,
            url: "/carrinhocompra/calcularfrete?cepDestino=" + cep,
            error: function (data) {
                console.log(data);
                imgSetDefault();
                $(this).prop('checked', false);
                mostraMsgErro("Oops! Não foi possível calcular o frete! Tente novamente");
            },
            success: function (data) {
                for (var i = 0; i < data.valores.length; i++) {
                    var valor = AlteraMoedaBr(parseFloat(data.valores[i].valor));
                    var nome;
                    var prazo = data.valores[i].prazo;

                    if (data.valores[i].tipoFrete == "04014") nome = "SEDEX";
                    else if (data.valores[i].tipoFrete == "40215") nome = "SEDEX10";
                    else if (data.valores[i].tipoFrete == "04510") nome = "PAC";

                    $(".valor-" + nome).html("<strong>Valor:</strong> " + valor);
                    $(".prazo-" + nome).html("<strong>Prazo:</strong> " + prazo + " dias");
                    $("#" + nome).removeAttr("disabled");
                }
                analisaCookieTipoFrete();
                imgSetDefault();
            }
        })
    }) 
}

function mostraMsgErro(msg) {
    $(".msg-erro").css("display", "block");
    $(".msg-erro").find("p").html(msg);
}

function ocultaMsgErro() {
    $(".msg-erro").css("display", "none");
}

function TipoFreteClick() {
    $("input[name='tipoFrete']").click(function () {
        $.cookie("Carrinho.TipoFrete", $(this).val(), { expires: 7, path: "/" });
        var nome = $(this).attr("id");
        var valorProduto = parseFloat($(".prod-valor").html().replace("R$ ","").replace(",","."));
        var valorFrete = parseFloat($(this).parent().parent().find(".valor-" + nome).html().split(" ")[2].replace(",", "."));
        $(".tot-valor").html(AlteraMoedaBr(valorProduto + valorFrete));
        $(".frete-valor").html(AlteraMoedaBr(valorFrete));
    })
}

function reiniciaCampoResultado() {
    $(".tot-valor").html("Indisponível");
    $(".frete-valor").html("Indisponível");
}

function AnalisaCookieCEP() {
    var cookieCEP = $.cookie("Carrinho.CEP");
    var inputs = $("input[name='endereco']");
    if (cookieCEP != undefined) {
        for (var i = 0; i < inputs.length && valorCEP!=cookieCEP; i++) {
            var valorCEP = inputs.eq(i).parent().find("input").eq(0).val().replace("-", "");
            if (valorCEP == cookieCEP) 
                inputs.eq(i).click();
        }
    }
}

function analisaCookieTipoFrete() {
    var tipoFrete = $.cookie("Carrinho.TipoFrete");
    var inputs = $("input[name='tipoFrete']");
    if (tipoFrete != undefined) {
        for (var i = 0; i < inputs.length; i++) {
            if (tipoFrete == inputs.eq(i).val())
                inputs.eq(i).click();
        }
    }
}

function reiniciarCampos() {
    $(".valor-PAC").html("<strong>Valor:</strong> Indisponível");
    $(".prazo-PAC").html("<strong>Prazo:</strong> Indisponível");
    $("#PAC").prop("checked", false);
    $("#PAC").attr("disabled");
    $(".valor-SEDEX").html("<strong>Valor:</strong> Indisponível");
    $(".prazo-SEDEX").html("<strong>Prazo:</strong> Indisponível");
    $("#SEDEX").removeAttr("checked");
    $("#SEDEX").prop("checked", false);
    $(".valor-SEDEX10").html("<strong>Valor:</strong> Indisponível");
    $(".prazo-SEDEX10").html("<strong>Prazo:</strong> Indisponível");
    $("#SEDEX10").prop("checked", false);
    $("#SEDEX10").attr("disabled");
}

function imgSetLoad() {
    $(".img-PAC").get(0).src = "/img/img-loading.gif";
    $(".img-SEDEX").get(0).src = "/img/img-loading.gif";
    $(".img-SEDEX10").get(0).src = "/img/img-loading.gif";
}

function imgSetDefault() {
    $(".img-PAC").get(0).src = "/img/pac.png";
    $(".img-SEDEX").get(0).src = "/img/sedex.jpg";
    $(".img-SEDEX10").get(0).src = "/img/sedex10.png";
}

function AlteraMoedaBr(valor) {
    return "R$ " + valor.toFixed(2).replace('.', ',');
}
