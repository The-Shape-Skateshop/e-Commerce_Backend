using e_Commerce.Dominio.ModuloItem;

namespace e_Commerce.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        #region Atributos que serão mapeados
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Imagem { get; set; }
        public decimal? Valor { get; set; }
        public string? Tamanho { get; set; }
        #endregion

        public List<Item>? Itens { get; set; }
        public List<Guid>? Id_Itens
        {
            get
            {
                return Itens.Select(c => c.Id).ToList<Guid>();
            }
        }

        public Produto()
        {
            Itens = new List<Item>();
        }

        public Produto(string nome, string descricao, decimal valor, string imagem) : this()
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Imagem = imagem;
        }

        public Produto(Guid id, string nome, string descricao, decimal valor, string imagem) 
            : this(nome, descricao, valor, imagem)
        {
            Id = id;
        }
    }
}
