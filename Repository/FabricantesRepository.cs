using FIPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIPE.Repository
{
    public class FabricantesRepository
    {
        public static List<Fabricantes> ListarFabricantes(string TipoVeiculo) 
        {
            var url = $@"https://parallelum.com.br/fipe/api/v1/{TipoVeiculo}/marcas";
            var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url);

            List<Fabricantes> fabricantes = JsonSerializer.Deserialize<List<Fabricantes>>(resposta.Result);

            return fabricantes;

        }
    }
}
