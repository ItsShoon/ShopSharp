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

        public void GravarVendas(List<Venda> vendas)
        {
            string jsonConteudo = JsonConvert.SerializeObject(vendas, Formatting.Indented);
            File.WriteAllText(vendaFilePath, jsonConteudo);
        }
    }
}