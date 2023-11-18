using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Produtos
{
    public class ProdutoDAL
    {
        private const string produtoFilePath = "produtos.json";

        /// <summary>
        /// Lê os produtos do armazenamento persistente.
        /// </summary>
        /// <returns>Uma lista de objetos Produto.</returns>
        public List<Produto> LerProdutos()
        {
            List<Produto> produtos;

            if (File.Exists(produtoFilePath))
            {
                string jsonConteudo = File.ReadAllText(produtoFilePath);
                produtos = JsonConvert.DeserializeObject<List<Produto>>(jsonConteudo);
            }
            else
            {
                produtos = new List<Produto>();
            }

            return produtos;
        }

        /// <summary>
        /// Grava os produtos no armazenamento persistente.
        /// </summary>
        /// <param name="produtos">A lista de produtos a ser gravada.</param>
        public void GravarProdutos(List<Produto> produtos)
        {
            string jsonConteudo = JsonConvert.SerializeObject(produtos, Formatting.Indented);
            File.WriteAllText(produtoFilePath, jsonConteudo);
        }
    }
}
