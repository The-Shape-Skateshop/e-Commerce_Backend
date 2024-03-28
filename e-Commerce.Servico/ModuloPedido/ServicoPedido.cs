using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.Servico.ModuloPedido
{
    public class ServicoPedido : ServicoBase<Pedido, ValidadorPedido>, IServicoBase<Pedido>
    {
        readonly IRepositorioPedido repPedido;
        readonly IContextoPersistencia ctxPersistencia;

        public ServicoPedido(IRepositorioPedido repPedido, IContextoPersistencia ctxPersistencia)
        {
            this.repPedido = repPedido;
            this.ctxPersistencia = ctxPersistencia;
        }

        public async Task<Result<Pedido>> EditarAsync(Pedido registro)
        {
            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repPedido.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Pedido {registro.Id} editada com sucesso");

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

        public async Task<Result> DeletarPorRegistroAsync(Pedido registro)
        {
            repPedido.Deletar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Pedido {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Pedido>> InserirAsync(Pedido registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            await this.repPedido.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Pedido {registro.Id} inserido com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result<Pedido>> SelecionarPorIdAsync(Guid id)
        {
            var pedidos = await repPedido.SelecionarPorIdAsync(id);

            if (pedidos == null)
            {
                Log.Logger.Warning($"Pedido {id} não encontrado");

                return Result.Fail("Pedido não encontrado");
            }

            Log.Logger.Information($"Pedido {id} selecionado com sucesso");

            return Result.Ok(pedidos);
        }

        public async Task<Result<List<Pedido>>> SelecionarTodosAsync()
        {
            var pedidos = await repPedido.SelecionarTodosAsync();

            Log.Logger.Information("Pedidos selecionados com sucesso!");

            return Result.Ok(pedidos);
        }

        public async Task<Result<List<Pedido>>> SelecionarTodosPedidoDoCliente(Guid idCliente)
        {
            var pedidos = await repPedido.SelecionarTodosPedidoDoCliente(idCliente);

            Log.Logger.Information($"Pedidos do cliente {idCliente} selecionados com sucesso!");

            return Result.Ok(pedidos);
        }
    }
}
