using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RepositorioGerenciamento.Entidade;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

using System.Data;
using System.Collections.ObjectModel;

namespace Gerenciamento.ConexaoAPI
{
    public class ExecutarAPI
    {

        const string _conexaoAPI = "http://localhost:62217/";

        public HttpResponseMessage ExecutarPOST(Object Entidade, string _url)
        {
            string requestMessage;
            StringContent content;
            HttpResponseMessage responseMessage;

            try
            {
                requestMessage = JsonConvert.SerializeObject(Entidade);
                content = new StringContent(requestMessage, Encoding.UTF8, "application/json");

                using (var cliente = new HttpClient())
                {
                    responseMessage = cliente.PostAsync(_conexaoAPI + _url, content).Result;

                    if (!responseMessage.IsSuccessStatusCode)
                        throw new Exception("Erro retorno API:" + _conexaoAPI + _url);
                }

                return responseMessage;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                requestMessage = null;
                content = null;
                responseMessage = null;
            }
            
        }


        public HttpResponseMessage ExecutarGET(Object Entidade, string _url)
        {
            HttpResponseMessage responseMessage;
            string requestMessage;
            StringContent content;

            try
            {

                requestMessage = JsonConvert.SerializeObject(Entidade);
                content = new StringContent(requestMessage, Encoding.UTF8, "application/json");

                using (var cliente = new HttpClient())
                {
                    responseMessage = cliente.PostAsync(_conexaoAPI + _url, content).Result;

                }

                return responseMessage;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                responseMessage = null;
                requestMessage = null;
                content = null;
            }

        }
    }
}
