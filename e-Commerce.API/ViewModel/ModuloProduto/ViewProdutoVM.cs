﻿using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.API.ViewModel.ModuloProduto
{
    public class ViewProdutoVM : ViewBase<ViewProdutoVM>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public string Tamanho { get; set; }
    }
}
