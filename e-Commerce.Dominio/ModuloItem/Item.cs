﻿using e_Commerce.Dominio.ModuloPedido;
using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.Dominio.ModuloItem
{
    public class Item : EntidadeBase<Item>
    {
        #region Atributos que serão mapeados
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
        public int Qtd_Produto {  get; set; }
        #endregion

        public Guid Id_Pedido
        {
            get
            {
                return Pedido.Id;
            }
            set { }
        }
        public Guid Id_Produto
        {
            get
            {
                return Produto.Id;
            }
            set { }
        }

        public Item()
        {
           
        }

        public Item(Pedido pedido, int qtd_Produto) : this()
        {
            Pedido = pedido;
            Qtd_Produto = qtd_Produto;
        }

        public Item(Guid id, Pedido pedido, int qtd_Produto) : this(pedido, qtd_Produto)
        {
            Id = id;
        }
    }
}