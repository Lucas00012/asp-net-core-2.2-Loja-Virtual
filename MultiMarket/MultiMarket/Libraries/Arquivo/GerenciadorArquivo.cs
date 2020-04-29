using Microsoft.AspNetCore.Http;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Arquivo
{
    public class GerenciadorArquivo
    {
        public static String CadastrarImagensProduto(IFormFile file)
        {
            //GUARDA O NOME DO ARQUIVO ATRAVES DO METODO Path.GetFileName(). NECESSARIO POIS O NOME PODE TER "IMPUREZAS"
            string NomeArquivo = Path.GetFileName(file.FileName);

            //GERA UM CAMINHO DE DIRETORIO ATRAVES DOS VARIOS ARGUMENTOS PASSADOS
            //Directory.GetCurrentDirectory() OBTEM O DIRETORIO ATUAL
            string Caminho = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads","temp",NomeArquivo);

            //CRIA UM ARQUIVO ATRAVES DO FileStream 
            //FileMode.Create indica que será criado um arquivo
            //A PALAVRA CHAVE using SE ENCARREGA DE UTILIZAR O METODO QUE FECHA O ARQUIVO
            using (var stream = new FileStream(Caminho, FileMode.Create)) 
            {
                file.CopyTo(stream);
            }
            //QUANTO O SITE ESTA HOSPEDADO NO SERVIDOR, A PASTA wwwroot NAO EXISTE! O ACESSO É DIRETO
            //----> www.dominio.com/uploads/temp/imagem
            return Path.Combine("uploads", "temp", NomeArquivo);
        }
        public static bool ExcluirImagensProduto(string caminho)
        {
            //lojavirtual/wwwroot//uploads/temp/nomearquivo ---> É NECESSÁRIO REMOVER ESSA BARRA !!!
            string Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminho.TrimStart('\\'));

            //VE SE O CAMINHO EXISTE
            if (File.Exists(Caminho))
            {
                File.Delete(Caminho);
                return true;
            }
            return false;
        }
        public static List<Imagem> MoverImagensProduto(List<string> CaminhosTempWeb,int ProdutoId)
        {
            List<Imagem> imagens = new List<Imagem>();
            string CaminhoDef = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",ProdutoId.ToString());
            string CaminhoTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","uploads","temp");

            string CaminhoWeb = Path.Combine("uploads", ProdutoId.ToString());

            if (!Directory.Exists(CaminhoDef)) Directory.CreateDirectory(CaminhoDef);

            foreach(string Caminho in CaminhosTempWeb)
            {
                if (!string.IsNullOrEmpty(Caminho))
                {
                    string NomeArquivo = Path.GetFileName(Caminho);
                    string Destino = Path.Combine(CaminhoDef, NomeArquivo);
                    string Origem = Path.Combine(CaminhoTemp, NomeArquivo);

                    string DestinoWeb = "\\"+Path.Combine(CaminhoWeb, NomeArquivo);
                    imagens.Add(new Imagem { Caminho = DestinoWeb, ProdutoId = ProdutoId });
                    if (File.Exists(Origem) && !File.Exists(Destino))
                    {
                        File.Move(Origem, Destino);
                    }

                }
            }
            return imagens;
        }
        public static void RemoverPasta(int Id)
        {
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", Id.ToString());
            if(Directory.Exists(folder)) Directory.Delete(folder,true);
        }
        public static void AnalisaDiretorio(List<Imagem> imagens,int ProdutoId)
        {
            string CaminhoDef = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",ProdutoId.ToString());
            string[] ArquivosCaminhoDef = Directory.GetFiles(CaminhoDef);

            bool igual;
            foreach (string arquivo in ArquivosCaminhoDef)
            {
                igual = false;
                foreach (Imagem imagem in imagens)
                {
                    string arquivoImagem = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagem.Caminho.TrimStart('\\'));
                    if (arquivo == arquivoImagem) igual = true;
                }
                if (!igual) File.Delete(arquivo);
            }

        }
    }
}
