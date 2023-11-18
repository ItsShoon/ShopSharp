using ShopSharp.Clientes;
using ShopSharp.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Produtos
{
    public class ProdutoBLL
    {
        private readonly ProdutoDAL produtoDAL;

        /// <summary>
        /// Construtor da classe ProdutoBLL.
        /// </summary>
        /// <param name="produtoDAL">Instância da classe ProdutoDAL.</param>
        public ProdutoBLL(ProdutoDAL produtoDAL)
        {
            this.produtoDAL = produtoDAL;
        }

        /// <summary>
        /// Lista todos os produtos existentes no sistema.
        /// </summary>
        /// <returns>Uma lista de objetos Produto.</returns>
        public List<Produto> ListarProdutos()
        {
            return produtoDAL.LerProdutos();
        }

        /// <summary>
        /// Adiciona um novo produto ao sistema.
        /// </summary>
        /// <param name="novoProduto">O produto a ser adicionado.</param>
        public void AdicionarProduto(Produto novoProduto)
        {
            List<Produto> produtos = produtoDAL.LerProdutos();
            produtos.Add(novoProduto);
            produtoDAL.GravarProdutos(produtos);
        }

        /// <summary>
        /// Edita um produto existente no sistema.
        /// </summary>
        /// <param name="produtoId">O ID do produto a ser editado.</param>
        /// <param name="produtoEditado">O produto com as alterações.</param>
        public void EditarProduto(int produtoId, Produto produtoEditado)
        {
            List<Produto> produtos = produtoDAL.LerProdutos();

            Produto produtoExistente = produtos.Find(p => p.ProdutoId == produtoId);

            if (produtoExistente != null)
            {
                // Atualiza os atributos do produto existente com os do produto editado
                produtoExistente.Nome = produtoEditado.Nome;
                produtoExistente.Preco = produtoEditado.Preco;
                produtoExistente.Stock = produtoEditado.Stock;
                produtoExistente.Marca = produtoEditado.Marca;
                produtoExistente.GarantiaMeses = produtoEditado.GarantiaMeses;
                produtoExistente.Tipo = produtoEditado.Tipo;


                produtoDAL.GravarProdutos(produtos);
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        /// <summary>
        /// Remove um produto do sistema com base no ID.
        /// </summary>
        /// <param name="produtoId">O ID do produto a ser removido.</param>
        public void RemoverProduto(int produtoId)
        {
            List<Produto> produtos = produtoDAL.LerProdutos();

            Produto produtoParaRemover = produtos.Find(p => p.ProdutoId == produtoId);

            if (produtoParaRemover != null)
            {
                produtos.Remove(produtoParaRemover);
                produtoDAL.GravarProdutos(produtos);
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

    }
}