using e_Commerce.Dominio.Compartilhado;
using e_Commerce.Dominio.ModuloCliente;

namespace e_Commerce.Servico.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente, ValidadorCliente>, IServicoBase<Cliente>
    {
        readonly IRepositorioCliente repCliente;
        readonly IContextoPersistencia ctxPersistencia;

        public ServicoCliente(IRepositorioCliente repCliente, IContextoPersistencia ctxPersistencia)
        {
            this.repCliente = repCliente;
            this.ctxPersistencia = ctxPersistencia;
        }

        public async Task<Result<Cliente>> EditarAsync(Cliente registro)
        {
            var resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repCliente.Editar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Cliente {registro.Id} editada com sucesso");

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

        public async Task<Result> DeletarPorRegistroAsync(Cliente registro)
        {
            repCliente.Deletar(registro);

            await ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Cliente {registro.Id} excluido com sucesso");

            return Result.Ok();
        }

        public async Task<Result<Cliente>> InserirAsync(Cliente registro)
        {
            Result resultado = Validar(registro);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            await this.repCliente.InserirAsync(registro);

            await this.ctxPersistencia.GravarDadosAsync();

            Log.Logger.Information($"Cliente {registro.Nome} inserido com sucesso");

            return Result.Ok(registro);
        }

        public async Task<Result<Cliente>> SelecionarPorIdAsync(Guid id)
        {
            var Cliente = await repCliente.SelecionarPorIdAsync(id);

            if (Cliente == null)
            {
                Log.Logger.Warning($"Cliente {id} não encontrado");

                return Result.Fail("Cliente não encontrado");
            }

            Log.Logger.Information($"Cliente {id} selecionado com sucesso");

            return Result.Ok(Cliente);
        }

        public async Task<Result<List<Cliente>>> SelecionarTodosAsync()
        {
            var Clientes = await repCliente.SelecionarTodosAsync();

            Log.Logger.Information("Clientes selecionados com sucesso!");

            return Result.Ok(Clientes);
        }
    }
}
