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

        public void GravarProdutos(List<Produto> produtos)
        {
            string jsonConteudo = JsonConvert.SerializeObject(produtos, Formatting.Indented);
            File.WriteAllText(produtoFilePath, jsonConteudo);
        }
    }
}
