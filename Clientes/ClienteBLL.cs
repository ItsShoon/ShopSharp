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

        public ClienteBLL(ClienteDAL clienteDAL)
        {
            this.clienteDAL = clienteDAL;
        }

        public List<Cliente> ListarClientes()
        {
            return clienteDAL.LerClientes();
        }

        public void AdicionarCliente(Cliente novoCliente)
        {
            List<Cliente> clientes = clienteDAL.LerClientes();
            clientes.Add(novoCliente);
            clienteDAL.GravarClientes(clientes);
        }

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

        public void RemoverCliente(int clienteId)
        {
            // Aqui você pode adicionar lógica de validação antes de remover o cliente
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