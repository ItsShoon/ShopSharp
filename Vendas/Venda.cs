using ShopSharp.Clientes;
using ShopSharp.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Vendas
{
    public class Venda
    {
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public Cliente Cliente { get; set; }
        public Produto ProdutoVendido { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
    }
}
