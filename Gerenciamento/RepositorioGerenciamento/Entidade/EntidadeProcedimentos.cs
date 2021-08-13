using Newtonsoft.Json;
using System;

namespace RepositorioGerenciamento.Entidade
{
    public class EntidadeProcedimentos
    {
        [JsonProperty(PropertyName="id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "Nome")]
        public string Nome { get; set; }
        [JsonProperty(PropertyName = "Descricao")]
        public string Descricao { get; set; }
        [JsonProperty(PropertyName = "Especialidade")]
        public string Especialidade { get; set; }
        [JsonProperty(PropertyName = "Observacao")]
        public string Observacao { get; set; }
        [JsonProperty(PropertyName = "DataCadastro")]
        public DateTime DataCadastro { get; set; }


    }
}
