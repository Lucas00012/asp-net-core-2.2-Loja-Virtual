$(document).ready(function ($) {
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.peso').mask('000.000.000.000.000,000', { reverse: true });
    var imagens = document.getElementsByClassName("img-select");

    $(".btn-danger").click(function (event) {
        var res = confirm("Deseja realizar essa ação?");
        if (!res) {
            event.preventDefault();
            event.stopImmediatePropagation();
        }
    })
    $(".img-add-file").change(function () {
        //PEGA O CONTEUDO (CÓDIGO) DA IMAGEM SELECIONADA
        //O files[0] É NECESSÁRIO POIS MAIS DE UMA IMAGEM PODE SER SELECIONADA
        //$(this)[0] acessa o input file
        var ImagemBinario = $(this)[0].files[0];
        var ImageAddress = this.parentNode.childNodes[7];
        var ImageDisplay = this.parentNode.childNodes[3].childNodes[1];
        var RemoveButton = this.parentNode.childNodes[5];

        var Formulario = new FormData();
        Formulario.append("file", ImagemBinario);

        $.ajax({
            type: "POST",
            url: "/colaborador/imagem/armazenar",
            contentType: false,
            //TRANSFORMA OQ FOI PASSADO EM QUERYSTRING. POR ISSO false
            processData: false,
            data:Formulario,
            error: function () {
                alert("Erro ao enviar a imagem!");
            },
            success: function (data) {
                ImageAddress.value = "\\"+data.caminho;
                ImageDisplay.src = "\\" + data.caminho;
                RemoveButton.setAttribute("class", "btn-imagens btn-danger");
                RemoveButton.removeAttribute("disabled");
            }
        })
    })
    $(".btn-imagens").click(function () {
        var ImageAddress = this.parentNode.childNodes[7];
        var ImageFile = this.parentNode.childNodes[1];
        var ImageDisplay = this.parentNode.childNodes[3].childNodes[1];
        var directory = ImageAddress.value.split('\\');
        var RemoveButton = this.parentNode.childNodes[5];

        
        if (directory[2] == "temp") {
            $.ajax({
                type: "GET",
                url: "/colaborador/imagem/deletar?caminho=" + ImageAddress.value,
                contentType: false,
                processData: false,
                error: function () {
                    alert("Erro ao excluir a imagem!");
                },
            })
        }
        ImageAddress.value = "";
        ImageFile.value = "";
        ImageDisplay.src = "/img/img-padrao.png";
        RemoveButton.setAttribute("class", "btn-imagens btn-danger btn-red");
        RemoveButton.setAttribute("disabled", "disabled");
        
    })
    function AddImage() {
        var inputFile = this.parentNode.parentNode.children[0];
        inputFile.click();
    }
    for (var i = 0; i < imagens.length; i++) {
        imagens[i].addEventListener("click", AddImage);
    }
});
/*
 *     var btn = document.getElementsByClassName("btn btn-danger");
 *  for (var i = 0; i < btn.length; i++) {
        btn[i].addEventListener("click", deletar);
    }
*/

