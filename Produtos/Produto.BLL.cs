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

        public ProdutoBLL(ProdutoDAL produtoDAL)
        {
            this.produtoDAL = produtoDAL;
        }

        public List<Produto> ListarProdutos()
        {
            return produtoDAL.LerProdutos();
        }

        public void AdicionarProduto(Produto novoProduto)
        {
            List<Produto> produtos = produtoDAL.LerProdutos();
            produtos.Add(novoProduto);
            produtoDAL.GravarProdutos(produtos);
        }

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