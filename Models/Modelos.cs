using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPE.Models
{
    public class ModelosResponse
    {
        public List<Modelos> modelos { get; set; }
    }

    public class Modelos 
    {
        public string codigo { get; set; }
        public string nome { get; set; }
    }


}
