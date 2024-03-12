﻿using e_Commerce.Dominio.ModuloCarrinho;

namespace e_Commerce.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        #region Atributos que serão mapeados
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        #endregion

        public List<Carrinho> ListaCarrinhos { get; set; }
        public List<Guid> Id_Carrinhos
        {
            get
            {
                return ListaCarrinhos.Select(c => c.Id).ToList<Guid>();
            }
        }

        public Produto()
        {
            ListaCarrinhos = new List<Carrinho>();
        }

        public Produto(string nome, string descricao, decimal valor, string imagem) : this()
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Imagem = imagem;
        }

        public Produto(Guid id, string nome, string descricao, decimal valor, int qtdEstoque, string imagem) 
            : this(nome, descricao, valor, imagem)
        {
            Id = id;
        }
    }
}
