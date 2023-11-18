using ShopSharp.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Clientes
{
    public class ClienteBLL
    {
        private readonly ClienteDAL clienteDAL;

        /// <summary>
        /// Construtor da classe ClienteBLL.
        /// </summary>
        /// <param name="clienteDAL">Instância da classe ClienteDAL.</param>
        public ClienteBLL(ClienteDAL clienteDAL)
        {
            this.clienteDAL = clienteDAL;
        }

        /// <summary>
        /// Lista todos os clientes existentes no sistema.
        /// </summary>
        /// <returns>Uma lista de objetos Cliente.</returns>
        public List<Cliente> ListarClientes()
        {
            return clienteDAL.LerClientes();
        }

        /// <summary>
        /// Adiciona um novo cliente ao sistema.
        /// </summary>
        /// <param name="novoCliente">O cliente a ser adicionado.</param>
        public void AdicionarCliente(Cliente novoCliente)
        {
            List<Cliente> clientes = clienteDAL.LerClientes();
            clientes.Add(novoCliente);
            clienteDAL.GravarClientes(clientes);
        }

        /// <summary>
        /// Edita um cliente existente no sistema.
        /// </summary>
        /// <param name="clienteId">O ID do cliente a ser editado.</param>
        /// <param name="clienteEditado">O cliente com as alterações.</param>
        public void EditarCliente(int clienteId, Cliente clienteEditado)
        {
            List<Cliente> clientes = clienteDAL.LerClientes();

            Cliente clienteExistente = clientes.Find(c => c.ClienteId == clienteId);

            if (clienteExistente != null)
            {
                clienteExistente.Nome = clienteEditado.Nome;
                clienteExistente.Email = clienteEditado.Email;
                clienteExistente.Contacto = clienteEditado.Contacto;
                clienteExistente.Morada = clienteEditado.Morada;
                clienteExistente.NIF = clienteEditado.NIF;


                clienteDAL.GravarClientes(clientes);
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        /// <summary>
        /// Remove um cliente do sistema com base no ID.
        /// </summary>
        /// <param name="clienteId">O ID do cliente a ser removido.</param>
        public void RemoverCliente(int clienteId)
        {
            List<Cliente> clientes = clienteDAL.LerClientes();

            Cliente clienteParaRemover = clientes.Find(c => c.ClienteId == clienteId);

            if (clienteParaRemover != null)
            {
                clientes.Remove(clienteParaRemover);
                clienteDAL.GravarClientes(clientes);
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

    }
}