using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Vendas
{
    public class VendaDAL
    {
        private const string vendaFilePath = "vendas.json";

        /// <summary>
        /// Lê as vendas do armazenamento.
        /// </summary>
        /// <returns>Uma lista de objetos Venda.</returns>
        public List<Venda> LerVendas()
        {
            List<Venda> vendas;

            if (File.Exists(vendaFilePath))
            {
                string jsonConteudo = File.ReadAllText(vendaFilePath);
                vendas = JsonConvert.DeserializeObject<List<Venda>>(jsonConteudo);
            }
            else
            {
                vendas = new List<Venda>();
            }

            return vendas;
        }

        /// <summary>
        /// Grava as vendas no armazenamento.
        /// </summary>
        /// <param name="vendas">A lista de vendas a ser gravada.</param>
        public void GravarVendas(List<Venda> vendas)
        {
            string jsonConteudo = JsonConvert.SerializeObject(vendas, Formatting.Indented);
            File.WriteAllText(vendaFilePath, jsonConteudo);
        }
    }
}