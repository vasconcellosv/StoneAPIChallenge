using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIChallenge
{
    public static class ReceitaUtils
    {
        public static Estabelecimento obterEstabelecimentoReceita(string cnpj)
        {
            string receitaws = "https://www.receitaws.com.br/v1/cnpj/";
            string url = receitaws + cnpj;
            Estabelecimento stab = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = request.GetResponseAsync().Result;

            //Task.WaitAll(response);

            using (System.IO.Stream s = response.GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    stab = JsonConvert.DeserializeObject<Estabelecimento>(jsonResponse);
                    if (stab.Cnpj == null)
                    {
                        throw new Exception();
                    }
                }
            }
            return stab;
        }
    }
}
