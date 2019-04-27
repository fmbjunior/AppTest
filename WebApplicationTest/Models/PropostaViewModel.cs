using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationTest.Models
{
    public class PropostaViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem> ListItemsClientes { get; set; }
        public List<SelectListItem> ListItemsFornecedores { get; set; }
        public int ClienteId { get; set; }
        public int FornecedorId { get; set; }
        public List<ItemProposta> ItensProposta { get; set; }
        public ItemProposta ItemProposta { get; set; }
    }
}