using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSharp.Produtos
{
    public abstract class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Stock { get; set; }
        public Marca Marca { get; set; }
        public int GarantiaMeses { get; set; }
        public TipoProduto Tipo { get; set; }

        // Construtor
        protected Produto(int produtoId, string nome, decimal preco, int stock, Marca marca, int garantiaMeses, TipoProduto tipo)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Preco = preco;
            Stock = stock;
            Marca = marca;
            GarantiaMeses = garantiaMeses;
            Tipo = tipo;
        }
    }

    public class ProdutoHardware : Produto
    {
        // Propriedades específicas para hardware
        public string TipoHardware { get; set; }

        // Construtor
        public ProdutoHardware(int produtoId, string nome, decimal preco, int stock, Marca marca, int garantiaMeses, string tipoHardware)
            : base(produtoId, nome, preco, stock, marca, garantiaMeses, TipoProduto.Hardware)
        {
            TipoHardware = tipoHardware;
        }
    }

    public class ProdutoSoftware : Produto
    {
        // Propriedades específicas para software
        public string Versao { get; set; }

        // Construtor
        public ProdutoSoftware(int produtoId, string nome, decimal preco, int stock, Marca marca, int garantiaMeses, string versao)
            : base(produtoId, nome, preco, stock, marca, garantiaMeses, TipoProduto.Software)
        {
            Versao = versao;
        }
    }

    public class ProdutoGadgetEletronico : Produto
    {
        // Propriedades específicas para gadgets eletrónicos
        public string Funcao { get; set; }

        // Construtor
        public ProdutoGadgetEletronico(int produtoId, string nome, decimal preco, int stock, Marca marca, int garantiaMeses, string funcao)
            : base(produtoId, nome, preco, stock, marca, garantiaMeses, TipoProduto.GadgetEletronico)
        {
            Funcao = funcao;
        }
    }

    public enum TipoProduto
    {
        Hardware,
        Software,
        GadgetEletronico
    }

    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nome { get; set; }
    }

}
