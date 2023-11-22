using ShopSharp.Clientes;
using ShopSharp.Produtos;
using ShopSharp.Vendas;

internal class Program
{
    #region MainMenu

    static void Main(string[] args)
    {
        var produtoBLL = new ProdutoBLL(new ProdutoDAL());
        var clienteBLL = new ClienteBLL(new ClienteDAL());
        var vendaBLL = new VendaBLL(new VendaDAL());

        // Cria uma lista de marcas
        List<Marca> marcas = new List<Marca>();

        while (true)
        {
            Console.WriteLine("----- Menu Principal -----");
            Console.WriteLine("1. Menu de Clientes");
            Console.WriteLine("2. Menu de Produtos");
            Console.WriteLine("3. Menu de Vendas");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    MenuClientes(clienteBLL);
                    break;
                case 2:
                    MenuProdutos(produtoBLL, marcas);
                    break;
                case 3:
                    MenuVendas(vendaBLL, clienteBLL, produtoBLL);
                    break;

                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    #endregion

    #region MenuClientes

    static void MenuClientes(ClienteBLL clienteBLL)
    {
        while (true)
        {
            Console.WriteLine("----- Menu de Clientes -----");
            Console.WriteLine("1. Listar Clientes");
            Console.WriteLine("2. Adicionar Cliente");
            Console.WriteLine("3. Editar Cliente");
            Console.WriteLine("4. Remover Cliente");
            Console.WriteLine("0. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ListarClientes(clienteBLL);
                    break;
                case 2:
                    AdicionarCliente(clienteBLL);
                    break;
                case 3:
                    EditarCliente(clienteBLL);
                    break;
                case 4:
                    RemoverCliente(clienteBLL);
                    break;
                case 0:
                    return; // Retorna ao menu principal
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    #endregion

    #region MenuProdutos
    static void MenuProdutos(ProdutoBLL produtoBLL, List<Marca> marcas)
    {
        while (true)
        {
            Console.WriteLine("----- Menu de Produtos -----");
            Console.WriteLine("1. Listar Produtos");
            Console.WriteLine("2. Adicionar Produto");
            Console.WriteLine("3. Editar Produto");
            Console.WriteLine("4. Remover Produto");
            Console.WriteLine("0. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ListarProdutos(produtoBLL);
                    break;
                case 2:
                    AdicionarProduto(produtoBLL, marcas);
                    break;
                case 3:
                    EditarProduto(produtoBLL, marcas);
                    break;
                case 4:
                    RemoverProduto(produtoBLL);
                    break;
                case 0:
                    return; // Retorna ao menu principal
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    #endregion

    #region MenuVendas

    static void MenuVendas(VendaBLL vendaBLL, ClienteBLL clienteBLL, ProdutoBLL produtoBLL)
    {
        while (true)
        {
            Console.WriteLine("----- Menu de Vendas -----");
            Console.WriteLine("1. Listar Vendas");
            Console.WriteLine("2. Adicionar Venda");
            Console.WriteLine("0. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ListarVendas(vendaBLL.ListarVendas());
                    break;
                case 2:
                    AdicionarVenda(vendaBLL, clienteBLL, produtoBLL);
                    break;
                case 0:
                    return; // Retorna ao menu principal
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    #endregion

    #region OperaçõesDeClientes

    // Métodos de operações para Clientes
    static void ListarClientes(ClienteBLL clienteBLL)
    {
        Console.WriteLine("----- Lista de Clientes -----");
        List<Cliente> clientes = clienteBLL.ListarClientes();

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.ClienteId}");
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"Contacto: {cliente.Contacto}");
            Console.WriteLine($"Morada: {cliente.Morada}");
            Console.WriteLine($"NIF: {cliente.NIF}");

            Console.WriteLine(); // Adiciona uma linha em branco
        }
    }

    static void AdicionarCliente(ClienteBLL clienteBLL)
    {
        Console.WriteLine("----- Adicionar Cliente -----");
        Cliente novoCliente = CriarNovoCliente();
        clienteBLL.AdicionarCliente(novoCliente);
        Console.WriteLine("Cliente adicionado com sucesso!");
    }

    static void EditarCliente(ClienteBLL clienteBLL)
    {
        Console.WriteLine("----- Editar Cliente -----");
        Console.Write("Insira o ID do cliente a ser editado: ");
        int clienteId = int.Parse(Console.ReadLine());

        Cliente clienteEditado = CriarNovoCliente();
        clienteBLL.EditarCliente(clienteId, clienteEditado);
        Console.WriteLine("Cliente editado com sucesso!");
    }

    static void RemoverCliente(ClienteBLL clienteBLL)
    {
        Console.WriteLine("----- Remover Cliente -----");
        Console.Write("Insira o ID do cliente a ser removido: ");
        int clienteId = int.Parse(Console.ReadLine());

        clienteBLL.RemoverCliente(clienteId);
        Console.WriteLine("Cliente removido com sucesso!");
    }

    static Cliente CriarNovoCliente()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Contacto: ");
        string contacto = Console.ReadLine();

        Console.Write("Morada: ");
        string morada = Console.ReadLine();

        Console.Write("NIF: ");
        string nif = Console.ReadLine();

        // Permite escolher entre ClientePrivado e ClienteEmpresarial
        Console.Write("Tipo de cliente (P para privado, E para empresarial): ");
        char tipoCliente = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (tipoCliente == 'P')
        {
            Console.Write("Cartão de Crédito: ");
            string cartaoCredito = Console.ReadLine();
            return new ClientePrivado(0, nome, email, contacto, morada, nif, cartaoCredito);
        }
        else if (tipoCliente == 'E')
        {
            Console.Write("Nome do Responsável: ");
            string nomeResponsavel = Console.ReadLine();
            return new ClienteEmpresarial(0, nome, email, contacto, morada, nif, nomeResponsavel);
        }
        else
        {
            Console.WriteLine("Tipo de cliente inválido. Será adicionado como Cliente.");
            return new Cliente(0, nome, email, contacto, morada, nif);
        }
    }

    #endregion

    #region OperaçõesDeProdutos

    // Métodos de operações para Produtos
    static void ListarProdutos(ProdutoBLL produtoBLL)
    {
        var produtos = produtoBLL.ListarProdutos();

        Console.WriteLine("----- Lista de Produtos -----");

        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.ProdutoId}, Nome: {produto.Nome}, Preço: {produto.Preco:C}, Stock: {produto.Stock}");
        }
    }

    static void AdicionarProduto(ProdutoBLL produtoBLL, List<Marca> marcas)
    {
        Console.WriteLine("----- Adicionar Produto -----");
        Produto novoProduto = CriarNovoProduto(marcas);
        produtoBLL.AdicionarProduto(novoProduto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void EditarProduto(ProdutoBLL produtoBLL, List<Marca> marcas)
    {
        Console.WriteLine("----- Editar Produto -----");
        Console.Write("ID do Produto a ser editado: ");
        int produtoId = int.Parse(Console.ReadLine());

        Produto produtoEditado = CriarNovoProduto(marcas);
        produtoBLL.EditarProduto(produtoId, produtoEditado);
        Console.WriteLine("Produto editado com sucesso!");
    }

    static void RemoverProduto(ProdutoBLL produtoBLL)
    {
        Console.WriteLine("----- Remover Produto -----");
        Console.Write("ID do Produto a ser removido: ");
        int produtoId = int.Parse(Console.ReadLine());

        produtoBLL.RemoverProduto(produtoId);
        Console.WriteLine("Produto removido com sucesso!");
    }

    static Produto CriarNovoProduto(List<Marca> marcas)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        Console.Write("Stock: ");
        int stock = int.Parse(Console.ReadLine());

        Console.Write("Garantia (meses): ");
        int garantiaMeses = int.Parse(Console.ReadLine());

        Console.WriteLine("----- Selecionar ou Adicionar Marca -----");
        Console.Write("ID da Marca existente ou 0 para adicionar uma nova: ");
        int marcaId = int.Parse(Console.ReadLine());

        Marca marcaSelecionada = null;

        if (marcaId == 0)
        {
            Console.Write("Nome da Nova Marca: ");
            string nomeNovaMarca = Console.ReadLine();
            marcaSelecionada = new Marca { MarcaId = marcas.Count + 1, Nome = nomeNovaMarca };
            marcas.Add(marcaSelecionada);
        }
        else
        {
            marcaSelecionada = marcas.Find(m => m.MarcaId == marcaId);
        }

        Console.Write("Tipo (H para Hardware, S para Software, G para Gadget Eletrónico): ");
        char tipoProduto = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        TipoProduto tipo;

        switch (tipoProduto)
        {
            case 'H':
                Console.Write("Tipo de Hardware: ");
                string tipoHardware = Console.ReadLine();
                return new ProdutoHardware(0, nome, preco, stock, marcaSelecionada, garantiaMeses, tipoHardware);
            case 'S':
                Console.Write("Versão do Software: ");
                string versao = Console.ReadLine();
                return new ProdutoSoftware(0, nome, preco, stock, marcaSelecionada, garantiaMeses, versao);
            case 'G':
                Console.Write("Função do Gadget Eletrónico: ");
                string funcao = Console.ReadLine();
                return new ProdutoGadgetEletronico(0, nome, preco, stock, marcaSelecionada, garantiaMeses, funcao);
            default:
                Console.WriteLine("Tipo de produto inválido. Será adicionado como Hardware.");
                return new ProdutoHardware(0, nome, preco, stock, marcaSelecionada, garantiaMeses, "N/A");
        }
    }

    #endregion

    #region OperaçõesDeVendas

    // Métodos de operações para Vendas
    static void ListarVendas(List<Venda> vendas)
    {
        Console.WriteLine("----- Lista de Vendas -----");

        foreach (var venda in vendas)
        {
            Console.WriteLine($"ID da Venda: {venda.VendaId}");
            Console.WriteLine($"Data da Venda: {venda.DataVenda}");
            Console.WriteLine($"Cliente: {venda.Cliente.Nome}");
            Console.WriteLine($"Produto Vendido: {venda.ProdutoVendido.Nome}");
            Console.WriteLine($"Quantidade: {venda.Quantidade}");
            Console.WriteLine($"Total: {venda.Total:C}");
            Console.WriteLine(); // Adiciona uma linha em branco
        }
    }

    // Método para adicionar venda
    static void AdicionarVenda(VendaBLL vendaBLL, ClienteBLL clienteBLL, ProdutoBLL produtoBLL)
    {
        Console.WriteLine("----- Adicionar Venda -----");

        // Obter informações necessárias para criar uma nova venda
        Console.Write("ID do Cliente: ");
        int clienteId = int.Parse(Console.ReadLine());
        Cliente cliente = clienteBLL.ObterClientePorId(clienteId);

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return;
        }

        Console.Write("ID do Produto: ");
        int produtoId = int.Parse(Console.ReadLine());
        Produto produto = produtoBLL.ObterProdutoPorId(produtoId);

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        // Criar a nova venda
        Venda novaVenda = new Venda
        {
            Cliente = cliente,
            ProdutoVendido = produto,
            Quantidade = quantidade,
            DataVenda = DateTime.Now,
            Total = produto.Preco * quantidade
        };

        vendaBLL.AdicionarVenda(novaVenda);

        Console.WriteLine("Venda adicionada com sucesso!");
    }


    #endregion
}

