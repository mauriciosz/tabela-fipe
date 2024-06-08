using FIPE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPE.Repository
{
    internal class VeiculosRepository
    {
        public static List<Veiculos> ListarVeiculos()
        {
            List<Veiculos> veiculos = new List<Veiculos>()
            {
                new Veiculos() {Id = 1, Tipo = "carros",    Descricao = "Carros" },
                new Veiculos() {Id = 2, Tipo = "motos",     Descricao = "Motos"},
                new Veiculos() {Id = 3, Tipo = "caminhoes", Descricao = "Caminhões"  }
            };
            return veiculos;
        }
    }
}
