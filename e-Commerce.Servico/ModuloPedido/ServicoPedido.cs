using e_Commerce.Dominio.ModuloPedido;

namespace e_Commerce.Servico.ModuloPedido
{
    public class ServicoPedido : ServicoBase<Pedido, ValidadorPedido>, IServicoBase<Pedido>
    {
        readonly IRepositorioPedido repPedido;
        readonly IContextoPersistencia ctxPersistencia;
        readonly IGeradorPDF geradorPdf;
        readonly IGeradorEmail geradorEmail;


        public ServicoPedido(IRepositorioPedido repPedido, IContextoPersistencia ctxPersistencia, IGeradorPDF geradorPdf, IGeradorEmail geradorEmail)
        {
            this.repPedido = repPedido;
            this.ctxPersistencia = ctxPersistencia;
            this.geradorPdf = geradorPdf;
            this.geradorEmail = geradorEmail;
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

            Log.Logger.Information($"Enviando email ao {registro.Usuario.Nome}...");




            return Result.Ok(registro);
        }

        public async Task<Result<Pedido>> MandarEmail(Pedido registro)
        {
            Log.Logger.Information($"Enviando email ao {registro.Usuario.Nome}...");

            var anexo = geradorPdf.GerarPdfEmail(registro);

            string msg;

            if (anexo == null)
            {
                msg = "Falha ao gerar PDF";

                Log.Error(msg);

                return Result.Fail(msg);
            }

            var statusEnvio = geradorEmail.EnviarEmail(registro, anexo);

            if (statusEnvio.IsFailed)
            {
                msg = "Falha ao tentar enviar email";

                Log.Error(msg + " {aluguel}", registro);

                return Result.Fail(statusEnvio.Reasons.Select(i => i.Message));
            }

            msg = "Email enviado com sucesso";

            Log.Debug(msg + " {Pedido}", registro);

            return Result.Ok();
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
    }
}
