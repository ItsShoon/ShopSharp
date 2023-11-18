using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ShopSharp.Clientes
{
    public class ClienteDAL
    {
        private const string clienteFilePath = "clientes.json";

        public List<Cliente> LerClientes()
        {
            List<Cliente> clientes;

            if (File.Exists(clienteFilePath))
            {
                string jsonConteudo = File.ReadAllText(clienteFilePath);
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonConteudo);
            }
            else
            {
                clientes = new List<Cliente>();
            }

            return clientes;
        }

        public void GravarClientes(List<Cliente> clientes)
        {
            string jsonConteudo = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText(clienteFilePath, jsonConteudo);
        }
    }
}