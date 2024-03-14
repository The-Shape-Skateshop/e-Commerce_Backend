using e_Commerce.Dominio.ModuloCarrinho;
using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.Dominio.ModuloItem
{
    public class Item : EntidadeBase<Item>
    {
        #region Atributos que serão mapeados
        public Carrinho Carrinho { get; set; }
        public List<Produto> Produtos { get; set; }
        public int Qtd_Produto {  get; set; }
        #endregion

        public Guid Id_Carrinho
        {
            get
            {
                return Carrinho.Id;
            }
        }
        public List<Guid> Id_Produtos
        {
            get
            {
                return Produtos.Select(p => p.Id).ToList<Guid>();
            }
        }

        public Item()
        {
            Produtos = new List<Produto>();
        }

        public Item(Carrinho carrinho, int qtd_Produto) : this()
        {
            Carrinho = carrinho;
            Qtd_Produto = qtd_Produto;
        }

        public Item(Guid id, Carrinho carrinho, int qtd_Produto) : this(carrinho, qtd_Produto)
        {
            Id = id;
        }
    }
}
