using FIPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIPE.Repository
{
    public class AnoRepository
    {
        public static List<Ano> ListarAno(string TipoVeiculo, string Fabricante, string Modelo)
        {
            var url = $@"https://parallelum.com.br/fipe/api/v1/{TipoVeiculo}/marcas/{Fabricante}/modelos/{Modelo}/anos";
            var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url);

            List<Ano> ano = JsonSerializer.Deserialize<List<Ano>>(resposta.Result);

            return ano;
        }
    }
}
