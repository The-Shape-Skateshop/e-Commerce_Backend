﻿namespace e_Commerce.API.ViewModel.ModuloAuth
{
    public class TokenViewModel
    {
        public string Chave { get; set; }
        public DateTime DataExpiracao { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }

    }
}
