using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Vendas
{
    public class VendaBLL
    {
        private readonly VendaDAL vendaDAL;

        public VendaBLL(VendaDAL vendaDAL)
        {
            this.vendaDAL = vendaDAL;
        }

        public List<Venda> ListarVendas()
        {
            return vendaDAL.LerVendas();
        }

        public void AdicionarVenda(Venda novaVenda)
        {
            List<Venda> vendas = vendaDAL.LerVendas();
            vendas.Add(novaVenda);
            vendaDAL.GravarVendas(vendas);
        }
    }
}
