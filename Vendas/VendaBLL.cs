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

        /// <summary>
        /// Construtor da classe VendaBLL.
        /// </summary>
        /// <param name="vendaDAL">Instância da classe VendaDAL.</param>
        public VendaBLL(VendaDAL vendaDAL)
        {
            this.vendaDAL = vendaDAL;
        }

        /// <summary>
        /// Lista todas as vendas existentes no sistema.
        /// </summary>
        /// <returns>Uma lista de objetos Venda.</returns>
        public List<Venda> ListarVendas()
        {
            return vendaDAL.LerVendas();
        }

        /// <summary>
        /// Adiciona uma nova venda ao sistema.
        /// </summary>
        /// <param name="novaVenda">A venda a ser adicionada.</param>
        /// <remarks>
        /// Este método realiza as seguintes operações:
        /// - Obtém a lista atual de vendas do armazenamento.
        /// - Adiciona a nova venda à lista existente.
        /// - Grava a lista atualizada de volta no armazenamento.
        /// </remarks>
        public void AdicionarVenda(Venda novaVenda)
        {
            List<Venda> vendas = vendaDAL.LerVendas();
            vendas.Add(novaVenda);
            vendaDAL.GravarVendas(vendas);
        }
    }
}