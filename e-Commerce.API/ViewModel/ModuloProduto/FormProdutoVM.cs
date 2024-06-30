namespace e_Commerce.API.ViewModel.ModuloProduto
{
    public class FormProdutoVM : FormBase<FormProdutoVM>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public string Tamanho { get; set; }
    }
}
