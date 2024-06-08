using FIPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIPE.Repository
{
    public class PesquisaPrecoRepository
    {
        public static PesquisaPreco RetornaVeiculo(string TipoVeiculo, string Fabricante, string Modelo, string Ano)
        {
            var url = $@"https://parallelum.com.br/fipe/api/v1/{TipoVeiculo}/marcas/{Fabricante}/modelos/{Modelo}/anos/{Ano}";
            var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url);

            PesquisaPreco psq = JsonSerializer.Deserialize<PesquisaPreco>(resposta.Result);

            return psq;
        }
    }
}
