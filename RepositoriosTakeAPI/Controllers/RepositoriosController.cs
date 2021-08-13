using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoriosTakeAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RepositoriosTakeAPI.Controllers
{
    [Route("api/repositoriostake")]
    [ApiController]
    public class RepositoriosController : ControllerBase
    {
        [HttpGet]
        public async Task<List<RepositorioVM>> Get()
        {
            using (var client = new HttpClient())
            {
                var repositorios = new List<RepositorioVM>();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                var baseUrl = "https://api.github.com/users/takenet/repos";

                try
                {
                    var response = client.GetStringAsync(baseUrl).Result;
                    var responseList = JsonConvert.DeserializeObject<List<RepositorioVM>>(response);

                    repositorios = responseList
                        .Where(x => !string.IsNullOrEmpty(x.Linguagem) && x.Linguagem.Equals("C#", System.StringComparison.OrdinalIgnoreCase))
                        .OrderBy(x => x.DataCriacao).ToList();

                    if (repositorios.Count() == 0)
                    {
                        throw new Exception("Não existem repositórios a serem exibidos.");

                    }

                    return repositorios;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
