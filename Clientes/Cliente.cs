using ShopSharp.Clientes;
using ShopSharp.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Clientes
{
    public class Cliente
    {
        // Atributos comuns a todos os tipos de clientes
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public string Morada { get; set; }
        public string NIF { get; set; }

        // Construtor
        public Cliente(int clienteId, string nome, string email, string contacto, string morada, string nif)
        {
            ClienteId = clienteId;
            Nome = nome;
            Email = email;
            Contacto = contacto;
            Morada = morada;
            NIF = nif;
        }
    }

    public class ClientePrivado : Cliente
    {
        // Atributos específicos para clientes privados
        public string CartaoCredito { get; set; }

        // Construtor
        public ClientePrivado(int clienteId, string nome, string email, string contacto, string morada, string nif, string cartaoCredito)
            : base(clienteId, nome, email, contacto, morada, nif)
        {
            CartaoCredito = cartaoCredito;
        }
    }

    public class ClienteEmpresarial : Cliente
    {
        // Atributos específicos para clientes empresariais
        public string NomeResponsavel { get; set; }

        // Construtor
        public ClienteEmpresarial(int clienteId, string nome, string email, string contacto, string morada, string nif, string nomeResponsavel)
            : base(clienteId, nome, email, contacto, morada, nif)
        {
            NomeResponsavel = nomeResponsavel;
        }
    }
}
