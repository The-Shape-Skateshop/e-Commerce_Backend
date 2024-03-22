﻿namespace e_Commerce.API.ViewModel.ModuloCliente
{
    public class ViewClienteVM : ViewBase<ViewClienteVM>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}