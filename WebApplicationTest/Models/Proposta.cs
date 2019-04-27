using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Proposta
    {
        public int Id { get; set; }
        public string CodigoProposta { get; set; }
        public Cliente Cliente { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public List<ItemProposta> ItensProposta { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}