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

        /// <summary>
        /// Lê os clientes do armazenamento persistente.
        /// </summary>
        /// <returns>Uma lista de objetos Cliente.</returns>
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

        /// <summary>
        /// Grava os clientes no armazenamento persistente.
        /// </summary>
        /// <param name="clientes">A lista de clientes a ser gravada.</param>
        public void GravarClientes(List<Cliente> clientes)
        {
            string jsonConteudo = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText(clienteFilePath, jsonConteudo);
        }
    }
}