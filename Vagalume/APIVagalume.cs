using Newtonsoft.Json;
using OrganizadorApolo.Models;
using OrganizadorApolo.Vagalume.JSON;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace OrganizadorApolo.Vagalume
{
    public class APIVagalume
    {
        public string RetornaLetraPorArtistaETitulo(string _artista, string _titulo)
        {
            string str = "";

            //g10030370343227
            //var requisicaoWeb = WebRequest.CreateHttp("https://api.vagalume.com.br/search.php?art=U2&mus=one&apikey={g10030370343227}");
            var requisicaoWeb = WebRequest.CreateHttp("https://api.vagalume.com.br/search.php?art=" + _artista + "&mus=" + _titulo + "&apikey={g10030370343227}");
            requisicaoWeb.Method = "POST";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                Root post = JsonConvert.DeserializeObject<Root>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();

                switch (post.Type)
                {
                    case "exact":
                        str = post.Mus[0].text;
                        break;

                    case "notfound":
                        break;

                    case "song_notfound":
                        break;

                    default:
                        break;
                }
            }

            return str;
        }

        //public static void EnviaRequisicaoPOST()
        //{
        //    string dadosPOST = "title=macoratti";
        //    dadosPOST = dadosPOST + "&body=teste de envio de post";
        //    dadosPOST = dadosPOST + "&userId=1";
        //    var dados = Encoding.UTF8.GetBytes(dadosPOST);
        //    var requisicaoWeb = WebRequest.CreateHttp("http://jsonplaceholder.typicode.com/posts");
        //    requisicaoWeb.Method = "POST";
        //    requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
        //    requisicaoWeb.ContentLength = dados.Length;
        //    requisicaoWeb.UserAgent = "RequisicaoWebDemo";
        //    //precisamos escrever os dados post para o stream
        //    using (var stream = requisicaoWeb.GetRequestStream())
        //    {
        //        stream.Write(dados, 0, dados.Length);
        //    }
        //    //ler e exibir a resposta
        //    using (var resposta = requisicaoWeb.GetResponse())
        //    {
        //        var streamDados = resposta.GetResponseStream();
        //        StreamReader reader = new StreamReader(streamDados);
        //        object objResponse = reader.ReadToEnd();
        //        var post = JsonConvert.DeserializeObject<Root>(objResponse.ToString());
        //        Console.WriteLine(post.Badwords);
        //        streamDados.Close();
        //        resposta.Close();
        //    }
        //    Console.ReadLine();
        //}

    }
}
