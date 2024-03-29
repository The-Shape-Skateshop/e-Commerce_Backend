using e_Commerce.Dominio.ModuloProduto;

namespace e_Commerce.Servico.ModuloProduto
{
    public class ServicoProduto : ServicoBase<Produto, ValidadorProduto>, IServicoBase<Produto>
    {
        readonly IRepositorioProduto repProduto;
        readonly IContextoPersistencia ctxPersistencia;

        public ServicoProduto(IRepositorioProduto repProduto, IContextoPersistencia ctxPersistencia)
        {
            this.repProduto = repProduto;
            this.ctxPersistencia = ctxPersistencia;
        }

        public async Task<Result<Produto>> EditarAsync(Produto registro)
        {
            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repProduto.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Produto {registro.Id} editada com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result> DeletarPorIdAsync(Guid id)
        {
            var resultado = await SelecionarPorIdAsync(id);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            return await DeletarPorRegistroAsync(resultado.Value);
        }

        public async Task<Result> DeletarPorRegistroAsync(Produto registro)
        {
            repProduto.Deletar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Produto {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Produto>> InserirAsync(Produto registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            await this.repProduto.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Produto {registro.Descricao} inserido com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result<Produto>> SelecionarPorIdAsync(Guid id)
        {
            var produto = await repProduto.SelecionarPorIdAsync(id);

            if (produto == null)
            {
                Log.Logger.Warning($"Produto {id} não encontrado");

                return Result.Fail("Produto não encontrado");
            }

            Log.Logger.Information($"Produto {id} selecionado com sucesso");

            return Result.Ok(produto);
        }

        public async Task<Result<List<Produto>>> SelecionarPorNome(string nomeProduto)
        {
            var produtos = await repProduto.SelecionarPorNome(nomeProduto);

            Log.Logger.Information("Produtos selecionados por nome com sucesso!");

            return Result.Ok(produtos);
        }

        public async Task<Result<List<Produto>>> SelecionarTodosAsync()
        {
            var produtos = await repProduto.SelecionarTodosAsync();

            Log.Logger.Information("Produtos selecionados com sucesso!");

            return Result.Ok(produtos);
        }
    }
}
