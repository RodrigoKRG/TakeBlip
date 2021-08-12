using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoriosTakeAPI.ViewModels
{
    public class RepositorioVM
    {
        [JsonProperty("full_name")]
        public string NomeRepositorio { get; set; }

        [JsonProperty("description")]
        public string Descricao { get; set; }

        [JsonProperty("created_at")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("language")]
        public string Linguagem { get; set; }

        [JsonProperty("owner")]
        public ImagemVM Imagem { get; set; }
    }

    public class ImagemVM
    {
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
    }
}
