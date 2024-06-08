using FIPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIPE.Repository
{
    public class ModelosRepository
    {
        public static List<Modelos> ListarModelos(string TipoVeiculo, string Fabricante)
        {
            var url = $@"https://parallelum.com.br/fipe/api/v1/{TipoVeiculo}/marcas/{Fabricante}/modelos";
            var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url).Result;

            // Verificar se a resposta não está vazia
            if (!string.IsNullOrEmpty(resposta))
            {
                // Desserializar o JSON para um objeto ModelosResponse
                var modelosResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelosResponse>(resposta);

                // Retornar a lista de modelos
                return modelosResponse.modelos;
            }
            else
            {
                Console.WriteLine("Resposta vazia da API");
                return null;
            }
        }
    }
}
