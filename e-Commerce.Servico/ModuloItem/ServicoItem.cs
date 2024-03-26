using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloItem;

namespace e_Commerce.Servico.ModuloItem
{
    public class ServicoItem : ServicoBase<Item, ValidadorItem>, IServicoBase<Item>
    {
        readonly IRepositorioItem repItem;
        readonly IContextoPersistencia ctxPersistencia;

        public ServicoItem(IRepositorioItem repItem, IContextoPersistencia ctxPersistencia)
        {
            this.repItem = repItem;
            this.ctxPersistencia = ctxPersistencia;
        }

        public async Task<Result<Item>> EditarAsync(Item registro)
        {
            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repItem.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Item {registro.Id} editada com sucesso");

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

        public async Task<Result> DeletarPorRegistroAsync(Item registro)
        {
            repItem.Deletar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Item {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Item>> InserirAsync(Item registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            await this.repItem.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Item {registro.Id} inserido com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result<Item>> SelecionarPorIdAsync(Guid id)
        {
            var Item = await repItem.SelecionarPorIdAsync(id);

            if (Item == null)
            {
                Log.Logger.Warning($"Item {id} não encontrado");

                return Result.Fail("Item não encontrado");
            }

            Log.Logger.Information($"Item {id} selecionado com sucesso");

            return Result.Ok(Item);
        }

        public async Task<Result<List<Item>>> SelecionarTodosAsync()
        {
            var Items = await repItem.SelecionarTodosAsync();

            Log.Logger.Information("Items selecionados com sucesso!");

            return Result.Ok(Items);
        }
    }
}
