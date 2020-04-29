$(document).ready(function () {
    $(".cpf").mask("000.000.000-00");
    $(".tel").mask("(00) 0000-00000");
    $(".data").mask("00/00/0000");
    $(".cep").mask("00000-000");

    $("#CEP").on("keyup change",function () {
        var cep = $(this).val();
        if(cep.length<9) removeMsgErro();
        if (cep.length == 9) {
            resetaCamposEndereco();
            $.ajax({
                method: "GET",
                dataType: "jsonp",
                url: "https://viacep.com.br/ws/" + cep.replace("-", "") + "/json/?callback=callback_name",
                success: function (data) {
                    if (data.erro == undefined) {
                        $("#Estado").val(data.uf);
                        $("#Cidade").val(data.localidade);
                        $("#Rua").val(data.logradouro);
                        $("#Bairro").val(data.bairro);
                        if (data.bairro == "" || data.rua == "") {
                            mostraMsgErro("Este não é um CEP residencial");
                            resetaCamposEndereco();
                        }
                    }
                    else mostraMsgErro("O CEP não foi encontrado! Verifique os dados e tente novamente");
                },
                error: function (data) {
                    mostraMsgErro("Oops! não foi possível consultar o CEP! Tente novamente mais tarde");
                },
            })
        }
    })
    $("#order-form").change(function () {
        var pesquisa = "";
        var ordem = $(this).val();
        var pagina = 1;

        var QueryString = new URLSearchParams(window.location.search);
        if (QueryString.has("pesquisa")) {
            pesquisa = QueryString.get("pesquisa");
        }

        var protocol = window.location.protocol;
        var host = window.location.hostname;
        var URL = protocol + "//" + host + ":" + window.location.port + window.location.pathname + "?pagina=" + pagina + "&pesquisa=" + pesquisa + "&ordem=" + ordem + "#titlePage";

        window.location.replace(URL);
    });
    $(".item-gallery").click(function () {
        var imgClicada = $(this).find("img").get(0);
        var ancora = $('.img-big-wrap').find('div').find('a').get(0);
        var img = $('.img-big-wrap').find('div').find('img').get(0);

        ancora.href = imgClicada.src;
        img.src = imgClicada.src;

    });
    $(".btn-adiciona").click(function (event) {
        event.preventDefault();
        removeMsgErro();
        var produtoId = $(this).parent().find(".produto-id").val();
        $.ajax({
            method: "GET",
            url: "/carrinhocompra/adicionaritem?id=" + produtoId,
            success: function () {

            },
            error: function (data) {
                mostraMsgErro(data.responseJSON.mensagem);
                window.location = "#";
                window.scrollBy(0, 200);
            }
        })
    })
});

function mostraMsgErro(msg) {
    var msgCampo = $(".msg-error").get(0);
    msgCampo.style.display = "block";
    msgCampo.innerHTML = msg;
}

function removeMsgErro() {
    var msgCampo = $(".msg-error").get(0);
    msgCampo.style.display = "none";
}

function resetaCamposEndereco() {
    $("#Estado").val("");
    $("#Cidade").val("");
    $("#Rua").val("");
    $("#Bairro").val("");
}