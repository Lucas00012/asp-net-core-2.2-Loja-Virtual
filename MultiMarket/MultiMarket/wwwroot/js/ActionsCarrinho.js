$(document).ready(function () {

    $(".cep").mask("00000-000");

    var produto = new Produto(null, null, null, null, null, null);
    $(".qtd-produto").focus(function () {
        produto.qtdAntiga = $(this).get(0).value;
    })
    $(".qtd-produto").change(function () {
        removeMsgErro();

        produto.campoQtd = $(this).get(0);
        produto.id = parseInt($(this).parent().find("input")[0].value);
        produto.qtdNova = parseInt(produto.campoQtd.value);
        produto.campoValor = $(this).parent().parent().find(".price").get(0);
        produto.campoQtdMax = $(this).parent().find(".qtd-max").get(0);
        produto.valor = parseFloat($(this).parent().find("input")[1].value.replace(',', '.'));

        produto.campoValor.innerText = AlteraMoedaBr(produto.qtdNova * produto.valor);

        AlteraCampoTotal();
        CalculaPagamentoTotal();
        AjaxAlteraCookieCarrinhoProduto(produto);
    })
    $(".btn-calcular-frete").click(function () {
        removeMsgErro();
        AjaxCalcularFrete(true);
    })
})

function AlteraMoedaBr(valor) {
    return "R$ " + valor.toFixed(2).replace('.', ',');
}

function AlteraCampoTotal() {
    var campoValores = $(".price");
    var somaValores = 0;
    var campoValorTotal = $(".valor-soma").get(0);
    for (var i = 0; i < campoValores.length; i++) {
        var Valor = parseFloat(campoValores[i].innerText.replace(/[R$ ]/g, "").replace(',', '.'));
        somaValores += Valor;
    }
    campoValorTotal.innerText = AlteraMoedaBr(somaValores);
}

function AlteraValorFrete(tipo) {
    var campoFrete = $(".valor-frete").get(0);
    campoFrete.innerHTML = tipo.get(0).innerHTML;
    CalculaPagamentoTotal();
}

//SOMA PRODUTO+FRETE
function CalculaPagamentoTotal() {
    var campoFrete = $(".valor-frete").get(0);

    if (campoFrete.innerText != "Não calculado") {
        var campoValorTotal = $(".valor-soma").get(0);
        var campoPagamentoTotal = $(".valor-total").get(0);

        var ValorProdutos = parseFloat(campoValorTotal.innerText.replace(/[R$ ]/g, "").replace(',', '.'));
        var ValorFrete = parseFloat(campoFrete.innerText.replace(/[R$ ]/g, "").replace(',', '.'));

        campoPagamentoTotal.innerText = AlteraMoedaBr(ValorProdutos + ValorFrete);
    }
}

function resetaFrete_resetaPagamentoTotal() {
    var campoFrete = $(".valor-frete").get(0);
    campoFrete.innerHTML = "Não calculado";

    var campoPagamentoTotal = $(".valor-total").get(0);
    campoPagamentoTotal.innerText = "Indisponível";
}

function admBtnContinua(habilitar) {
    var btnContinua = $(".pedido-continuar");

    if (habilitar) {
        if (btnContinua.hasClass("disabled"))
            btnContinua.removeClass("disabled");
    }
    else {
        if (!btnContinua.hasClass("disabled"))
        btnContinua.addClass("disabled");
    }
}

function mostraMsgErro(msg) {
    var msgCampo = $(".msg-error").get(0);
    msgCampo.style.display = "block";
    msgCampo.innerHTML = msg;
}

function removeMsgErro(msg) {
    var msgCampo = $(".msg-error").get(0);
    msgCampo.style.display = "none";
}

function AjaxAlteraCookieCarrinhoProduto(produto) {

    $.ajax({
        type: "GET",
        url: "/CarrinhoCompra/AlterarQuantidade?id="+ produto.id +"&quantidade="+produto.qtdNova,
        error: function (data) {

            //ROLLBACK
            produto.campoQtd.value = produto.qtdAntiga;
            produto.campoQtd.max = data.responseJSON.qtdMax;
            produto.campoQtdMax.innerText = data.responseJSON.qtdMax + " un.";
            produto.qtdNova = produto.qtdAntiga;
            produto.campoValor.innerText = AlteraMoedaBr(produto.qtdNova * produto.valor);

            mostraMsgErro(data.responseJSON.mensagem);
            AlteraCampoTotal();
        },
        success: function () {
            var campoResultadoFrete = $(".frete-resultado").get(0);
            campoResultadoFrete.innerHTML = "";
            admBtnContinua(false);
            resetaFrete_resetaPagamentoTotal();
        }
    })
}

function AjaxCalcularFrete(byButton) {


    var cep = $(".cep").get(0).value.replace("-", "");

    if (cep.length == 8) {

        resetaFrete_resetaPagamentoTotal();

        var campoJquery = $(".frete-resultado");
        var campoResultadoFrete = $(".frete-resultado").get(0);

        campoResultadoFrete.innerHTML = "<td colspan=4><img src='/img/img-loading2.gif'/></td>";

        $.ajax({
            type: "GET",
            url: "/CarrinhoCompra/CalcularFrete?cepDestino=" + cep,
            error: function (data) {
                campoResultadoFrete.innerHTML = "";
                mostraMsgErro("Oops! Não foi possível calcular o frete. Tente novamente");
                console.info(data);
            },
            success: function (data) {

                campoResultadoFrete.innerHTML = "";

                for (var i = 0; i < data.valores.length; i++) {
                    var valor = AlteraMoedaBr(parseFloat(data.valores[i].valor));
                    var nome;
                    var prazo = data.valores[i].prazo;

                    if (data.valores[i].tipoFrete == "04014") nome = "SEDEX";
                    else if (data.valores[i].tipoFrete == "40215") nome = "SEDEX10";
                    else if (data.valores[i].tipoFrete == "04510") nome = "PAC";

                    if (i == 0) {
                        campoResultadoFrete.innerHTML += ("<tr><th> <input type=\"radio\" checked value=\"" + nome + "\" name=\"frete\" /></th ><td> " + nome + " - <span>" + valor + "</span></td><th>Prazo: </th><td>" + prazo + " dias</td></tr >");
                        $.cookie("Carrinho.TipoFrete", nome);
                        AlteraValorFrete(campoJquery.find("span"));
                        CalculaPagamentoTotal();
                    }
                    else campoResultadoFrete.innerHTML += ("<tr><th> <input type=\"radio\" value=\"" + nome + "\" name=\"frete\" /></th ><td> " + nome + " - <span>" + valor + "</span></td><th>Prazo: </th><td>" + prazo + " dias</td></tr >");
                }

                $('input[name ="frete"]').click(function () {
                    $.cookie("Carrinho.TipoFrete", $(this).val(), {expires:7,path:"/"});
                    AlteraValorFrete($(this).parent().parent().find("span"));
                })

                admBtnContinua(true);
                console.info(data);
            }
        });
    }
    else {
        if(byButton)
            mostraMsgErro("O CEP está inválido! Verifique e tente novamente");
    }
}

function Produto(id, qtdNova, qtdAntiga, campoValor, valor,campoQtd,campoQtdMax) {
    this.id = id;
    this.qtdNova = qtdNova;
    this.qtdAntiga = qtdAntiga;
    this.campoValor = campoValor;
    this.valor = valor;
    this.campoQtd = campoQtd;
    this.campoQtdMax = campoQtdMax;
}