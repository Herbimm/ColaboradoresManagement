using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Domain.Entity
{
    public class Colaborador
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
    }
}
